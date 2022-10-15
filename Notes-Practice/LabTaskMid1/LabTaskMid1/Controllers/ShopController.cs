using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LabTaskMid1.DB;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LabTaskMid1.Controllers
{
   

    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            //var db = new ShopEntities1();

            //var p = new Product();
            //p.Name = "Y68 Smart Watch";
            //p.Price = "500";
            //p.Qty = "10";
            //db.Products.Add(p);
        
            //db.SaveChanges();

            return View();
        }

      
        public ActionResult Products()
        {
            var db = new ShopEntities1();

            var productList = db.Products.ToList();

            if (Session["Cart"] != null)
            {
                string json = Session["Cart"].ToString();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Cart = products;
            }
            

            
            return View(productList);
        }

  
        public ActionResult AddToCart(int id)
        {

            var JSON = "";
            List<Product> products = new List<Product>();
            Product product = new Product();

            var db = new ShopEntities1();
            var p = db.Products.Where(i => i.Id == id).SingleOrDefault();

            if (Session["Cart"] == null)
            {
                product.Id = p.Id;
                product.Name = p.Name;
                product.Price = p.Price;
                product.Qty = p.Qty;
                products.Add(product);
                JSON = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = new JavaScriptSerializer().Serialize(products);
               
                products.Clear();
            } else
            {
                //string json = "{\"Id\":0,\"Name\":\"M10\",\"Price\":\"1000\",\"Qty\":\"20\"}";
                //products.Add(new JavaScriptSerializer().Deserialize<Product>(json));

                string json = Session["Cart"].ToString();
                products = JsonConvert.DeserializeObject<List<Product>>(json);

                product.Id = p.Id;
                product.Name = p.Name;
                product.Price = p.Price;
                product.Qty = p.Qty;
                products.Add(product);

                JSON = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = JSON;
                products.Clear();
            }
            return RedirectToAction("Products");
        }

        public ActionResult ClearCart()
        {
            Session["Cart"] = null;
            return RedirectToAction("Products");
        }

        public ActionResult Checkout()
        {
            if (Session["Cart"] != null)
            {
                string json = Session["Cart"].ToString();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Cart = products;

            }


            return View();
        }

        public ActionResult AddOrder()
        {
            var db = new ShopEntities1();

            string json = Session["Cart"].ToString();
            var order = new Order();
            order.Orders = json;

            db.Orders.Add(order);

            db.SaveChanges();

            Session["Cart"] = null;
            TempData["MSG"] = "YOUR ORDER HAS BEEN CONFIRMED!";
            return RedirectToAction("Products");
        }



    }
}
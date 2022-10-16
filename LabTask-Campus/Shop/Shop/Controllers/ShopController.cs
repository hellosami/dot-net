using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Products_()
        {
            var db = new ShopDbEntities();

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

            var db = new ShopDbEntities();
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
            }
            else
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
            return RedirectToAction("Products_");
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
            var db = new ShopDbEntities();

            string json = Session["Cart"].ToString();
            var order = new Order();
            order.Orders = json;

            db.Orders.Add(order);

            db.SaveChanges();

            Session["Cart"] = null;
            TempData["MSG"] = "YOUR ORDER HAS BEEN CONFIRMED!";
            return RedirectToAction("Products_");
        }

        public ActionResult ClearCart()
        {
            Session["Cart"] = null;
            return RedirectToAction("Products_");
        }

       
    }
}
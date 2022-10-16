using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DB;
using Newtonsoft.Json;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var db = new ShopDbEntities();

            var productList = db.Products.ToList();

            return View(productList);
           
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            var db = new ShopDbEntities();

            //var p = new Product();
            p.Name = p.Name;
            p.Price = p.Price;
            p.Qty = p.Qty;
            db.Products.Add(p);

            db.SaveChanges();
            TempData["MSG_ADMIN"] = "PRODUCT HAS BEED ADDED SUCCESSFULY!";
            return RedirectToAction("AddProduct");
        }

        
   
        public ActionResult DeleteProduct(int id)
        {
            var db = new ShopDbEntities();

            //var p = new Product();
            var a = db.Products.Where(i => i.Id == id).SingleOrDefault();
            db.Products.Remove(a);

            db.SaveChanges();
            TempData["MSG_ADMIN"] = "PRODUCT HAS BEED DELETED SUCCESSFULY!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var db = new ShopDbEntities();

            //var p = new Product();
            var a = db.Products.Where(i => i.Id == id).SingleOrDefault();
  
            
       
            return View(a);
        }


        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            var db = new ShopDbEntities();

            //var p = new Product();
            var a = db.Products.Where(i => i.Id == p.Id).SingleOrDefault();
            a.Name = p.Name;
            a.Price = p.Price;
            a.Qty = p.Qty;

            db.SaveChanges();
            TempData["MSG_ADMIN"] = "PRODUCT HAS BEED UPDATED SUCCESSFULY!";
            return RedirectToAction("Index");
        }


    }
}
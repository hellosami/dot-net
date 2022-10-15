using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF2.DB;

namespace EF2.Controllers
{
    public class HospitalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new HospitalEntities();
            //var blogs = db.Blogs.ToList().OrderBy(f => f.Price).ToList();
            //var blogs = db.Blogs.ToList().OrderByDescending(f => f.Price).ToList();
            var blogs = db.Blogs.ToList().Where(f => f.Price > 10 && f.Author == "This is an author").ToList();
            double TotalPrice = db.Blogs.ToList().Sum(t => t.Price);

            double TotalPrice2 = db.Blogs.ToList().Where(f => f.Price == 10).Sum(t => t.Price);
            Debug.WriteLine($"SUM: {TotalPrice2}");

            //Console.WriteLine($"Hello {variable}");
            return View(blogs);
        }

        [HttpPost]
        public ActionResult Index(Blog blog)
        {
            var db = new HospitalEntities();

            db.Blogs.Add(blog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
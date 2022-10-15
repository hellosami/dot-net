using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Db;

namespace EntityFramework.Controllers
{
    public class LibraryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Blog blog)
        {
            var db = new BookListRazorEntities1();
            db.Blogs.Add(blog);
            db.SaveChanges();

            return View();
        }
    }
}
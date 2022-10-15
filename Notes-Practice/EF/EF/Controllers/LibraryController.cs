using EF.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library

        public ActionResult Index()
        {
            return View();
        }

 
        public void Create()
        {   var blog = new Blog();
            var db = new LibraryEntities();
            blog.Title = "Humayun Ahmed";
            blog.Author = "Humayun Ahmed";
            blog.Publisher = "Humayun Ahmed";
            blog.Price = 100.0f;
            db.Blogs.Add(blog);
            db.SaveChanges();
     
        }
    }
}
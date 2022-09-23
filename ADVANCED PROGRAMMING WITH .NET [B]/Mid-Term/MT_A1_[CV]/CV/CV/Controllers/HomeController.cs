using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.FullName = "Adnan Sami";
            ViewBag.ID = "19-39676-1";
            ViewBag.Section = "B";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
     
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
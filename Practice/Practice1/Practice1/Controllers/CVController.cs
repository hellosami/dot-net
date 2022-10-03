using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice1.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Job() {
            ViewBag.Job = "";
            return View();
        }

        public ActionResult Education() {
            ViewBag.Education = "";
            return View();


        }

        public ActionResult Publication()
        {
            ViewBag.Title = "The detection of monkeypox in humans in the Western Hemisphere.";

            String[] _authors = { "Reed", "Kurt D." }; 
            ViewBag.Authors = _authors;
            ViewBag.PublishYear = "2004";
            return View();
        }
    }
}
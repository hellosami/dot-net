using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        public ActionResult Index()
        {
            ViewBag.UniversityName = "American International University – Bangladesh (AIUB)";
            return View();
        }
    }
}
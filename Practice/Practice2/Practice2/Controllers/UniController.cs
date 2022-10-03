using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice2.Controllers
{
    public class UniController : Controller
    {
        // GET: Uni
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admission()
        {
            ViewData["OnlineAdmission"] = "August 28, 2022";
            ViewData["TimeWrittenExam"] = "12:00 PM";
            ViewData["VivaSchedule"] = "03:00 PM";

            return View();
        }
    }
}
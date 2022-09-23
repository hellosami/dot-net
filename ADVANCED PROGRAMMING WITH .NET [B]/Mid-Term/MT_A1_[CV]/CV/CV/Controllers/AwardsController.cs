using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class AwardsController : Controller
    {
        // GET: Awards
        public ActionResult Index()
        {
            return View();
        }
    }
}
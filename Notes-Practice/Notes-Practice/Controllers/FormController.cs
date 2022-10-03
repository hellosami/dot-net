using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notes_Practice.Models;

namespace Notes_Practice.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Success(Profile p)
        {

            ViewBag.FirstName = p.FirstName;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Profile p)
        {
            if(ModelState.IsValid)
            {

           
                TempData["Message"] = "Success!";
                return RedirectToAction("Success", p);
            }
            return View();
        }


    }
}
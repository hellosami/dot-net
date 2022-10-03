using Notes_Practice.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notes_Practice.Controllers
{
    public class PassDataController : Controller
    {
        // GET: PassData
        public ActionResult Index()
        {

            return View();
        }



        public ActionResult PDViewBag()
        {
            ViewBag.StudentName = "Adnan Sami";
            ViewBag.ID = "19-39676-1";
            ViewBag.BirthYear = "1999";
            ViewBag.CourseList = new String[] { "English", "Bangla", "Math", "Science", "Social Science" };
            return View();
        }

        public ActionResult PDViewData()
        {
            ViewData["CourseName"] = "ADVANCED PROGRAMMING WITH .NET [B]";
            ViewData["RoomNo"] = "DS0405";
            ViewData["Mentors"] = new String[] {"Sabbir", "Jamshed", "Rakib", "Arif", "Islam"};
            return View();
        }

        public ActionResult Message()
        {
                
            return View();
        }

        public ActionResult PDTempData()
        {
            TempData["Message"] = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";

            return RedirectToAction("Message");
        }

        public ActionResult Profile()
        {
            List<Fruit> fruits = new List<Fruit>();
            Fruit f1 = new Fruit()
            {
                Id = 1,
                Name = "Apple",
                Price = "500",
                Qty = "100"
            };

            fruits.Add(f1);

            Fruit f2 = new Fruit()
            {
                Id = 2,
                Name = "Jackfruit",
                Price = "1000",
                Qty = "10"
            };

            fruits.Add(f2);

            
            return View(fruits);
        }
    }
}
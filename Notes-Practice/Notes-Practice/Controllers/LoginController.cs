using Newtonsoft.Json.Linq;
using Notes_Practice.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notes_Practice.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection conn = new SqlConnection("data source=DESKTOP-TCMP1I1; database=BookListRazor; integrated security = SSPI;");
        
        
        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login L)
        {
            if(ModelState.IsValid)
            {
                conn.Open();
                string query = "SELECT * FROM LOGIN WHERE USERNAME = '"+L.UserName+"' AND PASSWORD = '"+L.Password+"';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read() )
                {
                    System.Diagnostics.Debug.WriteLine("LOGGED IN!");
                   

                } else
                {
                    System.Diagnostics.Debug.WriteLine("NOT FOUND!");
                
                }
                conn.Close();

                
                
            }
            return View();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using Notes_Practice.Models;
using Newtonsoft.Json;
using System.Web.DynamicData;

namespace Notes_Practice.Controllers
{
    public class TestLoginController : Controller
    {
        // GET: TestLogin
        public ActionResult Index()
        {
            string connectionString = "Data Source=DESKTOP-TCMP1I1; Initial Catalog=BookListRazor; Integrated Security=true;";
            TestLogin T = new TestLogin();

            string foo = "Hello";
            DataTable dataTable = new DataTable();



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        string query = "SELECT * FROM BLOG WHERE TITLE = 'Title1';";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader dr = cmd.ExecuteReader();

                     


                        dataTable.Load(dr);

                        ViewBag.Result = JsonConvert.SerializeObject(dataTable);

                        //while (dr.Read())
                        //{
                        //    Debug.WriteLine(dr["Title"] + " " + dr["Excerpt"] + " " + dr["Image"] + " " + dr["Posted"]);
                        //    ViewBag.Title = dr["Title"];
                        //}



                    }
                }
                catch(SqlException ex)
                {
                    Debug.WriteLine("My Exception: " + ex.Message);
                }
            }

   
            return View();
            //try
            //{
            //    conn.Open();

            //    Debug.WriteLine(conn.State);
            //} catch (SqlException ex)
            //{

            //}





            /*
                SqlConnection();
                SqlConnection(String);
                SqlCOnnection(String, SqlCredential)
             */

        }
    }
}
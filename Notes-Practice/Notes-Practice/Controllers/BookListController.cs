using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notes_Practice.Controllers
{
    public class BookListController : Controller
    {
        SqlConnection conn = new SqlConnection("data source=DESKTOP-TCMP1I1; database=BookListRazor; integrated security = SSPI;");
        // GET: BookList
        public ActionResult Index()
        {
            //List<String> container = new List<String>();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            conn.Open();
            string query = "SELECT * FROM BOOK;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();

            if (dr.HasRows)
            {
                dataTable.Load(dr);
                ViewBag.dt = dataTable;
                //while (dr.Read())
                //{
                //    System.Diagnostics.Debug.WriteLine(dr["Name"].ToString() + "/n");

                //    dic.Add(dr["Id"].ToString(), dr["Name"].ToString());
                //}
            }

            conn.Close();

            //ViewBag.dic = dic;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Notes_Practice.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        SqlConnection conn = new SqlConnection("data source=DESKTOP-TCMP1I1; database=BookListRazor; integrated security = SSPI;");
        // GET: BookList

        public ActionResult Index() {
            ViewBag.Result = JsonConvert.DeserializeObject(JTest());
            return View();
        }
        public string JTest()
        {
            //List<String> container = new List<String>();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            conn.Open();
            string query = "SELECT * FROM BLOG;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();

            if (dr.HasRows)
            {
                dataTable.Load(dr);
                return JsonConvert.SerializeObject(dataTable);
                //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(dataTable));

                //while (dr.Read())
                //{
                //    System.Diagnostics.Debug.WriteLine(dr["Name"].ToString() + "/n");

                //    dic.Add(dr["Id"].ToString(), dr["Name"].ToString());
                //}
            }

            conn.Close();
            return "[]";
            //ViewBag.dic = dic;
            //return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Data;

namespace Notes_Practice.Controllers

{
    public class AccountController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public void Connection()
        {

            //string connectionString = "Data Source=DESKTOP-TCMP1I1; Initial Catalog=BookListRazor; Integrated Security=true;";
            
        
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (conn.State.ToString() == "Open")
                    {
                        Debug.WriteLine("Hello!");
                    }
                }




            }
            catch(Exception ex)
            {
                Debug.WriteLine("MY EXCEPTION: " + ex.Message);
            }

            //conn.Close();
        }

        public void Select()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    //string query = "";
                    //SqlCommand command = new SqlCommand(); // prepare sql statement
                    //command.CommandText = "SELECT * FROM BLOGS;";
                    //command.Connection = conn;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SPGETBLOG";
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();
             
                    Debug.WriteLine(dr["Posted"]);
         



                }




            }
            catch (Exception ex)
            {
                Debug.WriteLine("MY EXCEPTION: " + ex.Message);
            }
        }


        public void Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    //string query = "";
                    //SqlCommand command = new SqlCommand(); // prepare sql statement
                    //command.CommandText = "SELECT * FROM BLOG;";
                    //command.Connection = conn;
                    string title = "the subtle art of not giving a f*ck";
                    string author = "mark manson";
                    string publisher = "self help book";
                    float price = 10.0f;

                    string query = "INSERT INTO BLOGS VALUES (@Title, @Author, @Publisher, @Price);INSERT INTO BLOGS VALUES (@Title, @Author, @Publisher, @Price);INSERT INTO BLOGS VALUES (@Title, @Author, @Publisher, @Price);";


                    SqlCommand command = new SqlCommand(query, conn);


                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Publisher", publisher);
                    command.Parameters.AddWithValue("@Price", price);


                    
                    conn.Open();
                  
                    int result = command.ExecuteNonQuery();
                    Debug.WriteLine(result);
                    if (result > 0) // result can return greater than 3 if i write three statements in query. it is possible to write three statements together using ;
                    {
                        Debug.WriteLine("INSERTED");
                    }


                }




            }
            catch (Exception ex)
            {
                Debug.WriteLine("MY EXCEPTION: " + ex.Message);
            }
        }

        public void Update()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int ID = 1;
                string query = "UPDATE BLOGS SET AUTHOR = 'HONEY' WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                int result = command.ExecuteNonQuery();
                Debug.WriteLine("Update" + result);
                if(result > 0)
                {
                    Debug.WriteLine("UPDATED");
                }


            }
        }
    }
}
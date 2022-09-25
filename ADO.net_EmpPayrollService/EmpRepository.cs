using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_EmpPayrollService
{
    public class EmpRepository
    {
        //UC1 Create Database
        public static void CreateDataBase()
        {

            SqlConnection con = new SqlConnection(@"Data Source=ITS-HEMANT-PC\SQLEXPRESS; Initial Catalog=master;Integrated Security=True");

            try
            {
                //Using block is used to close the connection without using close property
                using(con)
                {
                    //Writing SQL query
                    string query = "Create database EmpPayroll_Service";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //Opening Connection
                    con.Open();
                    //Executing SQL query
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Database Created Successfully");

                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Something Went Wrong..."+e.Message);
            }

        }
    }
}

       
   
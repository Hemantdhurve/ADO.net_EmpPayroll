using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //UC2 Retrieve the Employee Payroll from the database
        //1st need to create Table

        public static void CreateTable()
        {

            try
            {
                using (con)
                {

                    //writing sql query
                    string query = "Create table EmployeePayroll(EmployeeID int primary key identity(1,1),EmployeeName varchar(255),PhoneNumber varchar(255)," +
                        "Address varchar(255),Department varchar(255),Gender char(1),BasicPay float,Deductions float,TaxablePay float,Tax float," +
                        "NetPay float,StartDate datetime,City varchar(255),Country varchar(255))";
                    SqlCommand cm = new SqlCommand(query, con);

                    //opening connection
                    con.Open();

                    //ExecuteNonQuery() function is used to execute our insert query
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Table created Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Went Wrong" + e.Message);
            }
        }

        //I made SqlConnection as a static so that we use it every methods
        public static SqlConnection con = new SqlConnection(@"Data Source=ITS-HEMANT-PC\SQLEXPRESS; Initial Catalog=EmpPayroll_Service;Integrated Security=True");
        public void GetAllEmployees()
        {
            try
            {
                EmpModel model = new EmpModel();
                using (con)
                {
                    //string query = @"Select EmployeeID,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deductions,TaxablePay,Tax,Income_Tax,NetPay,StartDate,City,Country from EmpPayroll_Service";
                    string query = @"Select * from dbo.EmployeePayroll";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    //SqlDatareader class reads the query and Executereader class Executes the query
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Checking for the records
                    if (reader.HasRows)
                    {
                        using (con)
                        {

                            while (reader.Read())
                            {
                                model.EmployeeID = reader.GetInt32(0);
                                model.EmployeeName = reader.GetString(1);
                                model.PhoneNumber = reader.GetString(2);
                                model.Address = reader.GetString(3);
                                model.Department = reader.GetString(4);
                                model.Gender = Convert.ToChar(reader.GetString(5));
                                model.BasicPay = reader.GetDouble(6);
                                model.Deductions = reader.GetDouble(7);
                                model.TaxablePay = reader.GetDouble(8);
                                model.Tax=reader.GetDouble(9);
                                model.NetPay = reader.GetDouble(10);
                                model.StartDate = reader.GetDateTime(11);
                                model.City = reader.GetString(12);
                                model.Country = reader.GetString(13);

                                Console.WriteLine("Displaying data:\n" +
                                    "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                                    model.EmployeeID, model.EmployeeName, model.PhoneNumber, model.Address,model.Department,model.Gender, model.BasicPay,model.Deductions,model.TaxablePay,model.Tax,model.NetPay,model.StartDate,model.City,model.Country);
                                Console.WriteLine("\n");

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data Found");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something Went Wrong...." + e.Message);
            }
        }

        //This Method Adds new Employee Details to the table
        public bool AddEmployee(EmpModel model)
        {
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("dbo.Sp_AddEmpDetails", con);             //Created Stored Procedure in SQl
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Department", model.Department);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    cmd.Parameters.AddWithValue("@Deductions", model.Deductions);
                    cmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    cmd.Parameters.AddWithValue("@Tax", model.Tax);
                    cmd.Parameters.AddWithValue("@Netpay", model.NetPay);
                    cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@Country", model.Country);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

       
   
using System;

namespace ADO.net_EmpPayrollService
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Employee Payroll Service ADO.Net");

            Console.WriteLine("Please Select the Options:\n " +
                "1) Database Creation\n " +
                "2) Creating Table\n " +
                "3) Retrieving Data from the Database\n " +
                "4) Adding Employee Method to the database\n " +
                "5) Updating Salary of Employee\n " +
                "6) Get the Updated Salary of Employee\n ");

            int option=Convert.ToInt32(Console.ReadLine());

            EmpModel model = new EmpModel();
            EmpRepository repo = new EmpRepository();
            switch (option)
            {
                case 1:
                    EmpRepository.CreateDataBase();
                    break;

                case 2:
                    EmpRepository.CreateTable();
                    break;

                case 3:
                  
                    repo.GetAllEmployees();
                    Console.WriteLine(":::::::::::::::::::::::::::::");
                    break;

                case 4:
                    Console.WriteLine("Adding Employee Details");

                    model.EmployeeName = "Vicky Singh";
                    model.PhoneNumber = "7485961284";
                    model.Address = "Mumbai";
                    model.Department = "Hr";
                    model.Gender = 'M';
                    model.BasicPay = 3400000.0;
                    model.Deductions = 2500.0;
                    model.TaxablePay = 200.0;
                    model.Tax = 300.0;
                    model.NetPay = 250000.0;
                    model.StartDate = DateTime.Now;
                    model.City = "Mumbai";
                    model.Country = "India";

                    repo.AddEmployee(model);
                    Console.WriteLine(":::::::::::::::::::::::::::::");
                  
                    break;

                case 5:
                    Console.WriteLine("Employee Details updating");
                    model.EmployeeName = "Terisa";
                    model.BasicPay = 3000000.00;
                    repo.UpdateData(model);
                    break;

                case 6:
                    model.EmployeeName = "Terisa";
                    repo.GetUpdatedResultofEmployee(model);
                    break;



                default:
                    Console.WriteLine("Please Enter Proper Option");
                    break;

            }
        }
    }
}
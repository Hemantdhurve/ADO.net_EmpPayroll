using System;

namespace ADO.net_EmpPayrollService
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Employee Payroll Service ADO.Net");

            Console.WriteLine("Please Select the Options:\n " +
                "1) Database Creation\n");

            int option=Convert.ToInt32(Console.ReadLine());

            EmpModel model = new EmpModel();
            EmpRepository repo = new EmpRepository();
            switch (option)
            {
                case 1:
                    EmpRepository.CreateDataBase();
                    break;

                default:
                    Console.WriteLine("Please Enter Proper Option");
                    break;

            }
        }
    }
}
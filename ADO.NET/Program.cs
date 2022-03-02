using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    public class Program
    {
        static void Main(string[] args)
        {

            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.GetAllEmployee();
            Console.ReadLine();
        }
    }
}
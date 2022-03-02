using ADO.NET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    public class EmployeeRepository
    {
        public static string ConnectionString = @"Data Source=DESKTOP-U8F94J3;Initial Catalog=payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    EmployeeModel model = new EmployeeModel();
                    string query = " Select * From  employee_Payroll";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeID = Convert.ToInt32(reader["ID"] == DBNull.Value ? default : reader["ID"]);
                            model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            model.StartDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default : reader["StartDate"]));
                            model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                            model.Phone = Convert.ToInt32(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            model.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            model.Address = reader["address"] == DBNull.Value ? default : reader["Address"].ToString();
                            model.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", model.EmployeeID, model.Name, model.BasicPay, model.StartDate, model.Gender, model.Phone, model.Department, model.TaxablePay, model.Address);
                            Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows Present");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

    }
}
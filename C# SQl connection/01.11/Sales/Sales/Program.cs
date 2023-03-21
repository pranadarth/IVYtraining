using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace Sales
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=master;Integrated Security=True;";
                SqlConnection sql = new SqlConnection(ConnectionString);
                sql.Open();

                Console.WriteLine("Enter the location:");
                string location = Console.ReadLine();
                Console.WriteLine();

                SqlCommand cmd = new SqlCommand("select * from average(@location)", sql);
                cmd.Parameters.Add("@location", System.Data.SqlDbType.NVarChar).Value = location;
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Average amount: ");

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine();
                }
                reader.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Sql Exception");
                Console.WriteLine("Something Got Wrong with DataBase");
                Console.WriteLine(e.Message);
            }

        }
    }
}
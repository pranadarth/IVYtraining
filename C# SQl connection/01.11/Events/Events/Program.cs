using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;";
                SqlConnection sql = new SqlConnection(ConnectionString);
                sql.Open();

                Console.WriteLine("Enter the month of event: ");
                string month = Console.ReadLine();
                Console.WriteLine();

                SqlCommand cmd = new SqlCommand("event_month", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@month", System.Data.SqlDbType.NVarChar).Value = month;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(2));
                    Console.WriteLine(reader.GetString(3));
                    Console.WriteLine(reader.GetString(4));
                    Console.WriteLine(reader.GetInt32(5));
                    Console.WriteLine();
                }
                reader.Close();
                Console.WriteLine("Enter the location of event: ");
                string location = Console.ReadLine();
                Console.WriteLine();

                SqlCommand cmd1 = new SqlCommand("event_location", sql);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("@location", System.Data.SqlDbType.NVarChar).Value = location;
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    Console.WriteLine(reader1.GetInt32(0));
                    Console.WriteLine(reader1.GetString(1));
                    Console.WriteLine(reader1.GetString(2));
                    Console.WriteLine(reader1.GetString(3));
                    Console.WriteLine(reader1.GetString(4));
                    Console.WriteLine(reader1.GetInt32(5));
                    Console.WriteLine();
                }
                reader1.Close();

                SqlCommand cmd2 = new SqlCommand("select * from dbo.event_money()", sql);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                int amount = reader2.GetInt32(0);
                reader2.Close();

                Console.WriteLine("Highest amount of in the event: ");

                SqlCommand cmd3 = new SqlCommand("max_amount", sql);
                cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                cmd3.Parameters.Add("@amount", System.Data.SqlDbType.Int).Value = amount;
                SqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    Console.WriteLine(reader3.GetInt32(0));
                    Console.WriteLine(reader3.GetString(1));
                    Console.WriteLine(reader3.GetString(2));
                    Console.WriteLine(reader3.GetString(3));
                    Console.WriteLine(reader3.GetString(4));
                    Console.WriteLine(reader3.GetInt32(5));
                    Console.WriteLine();
                }
                reader3.Close();
                
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
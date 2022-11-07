using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace Studentmarks
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

                Console.WriteLine("Enter Student id:");
                int id = Convert.ToInt32(Console.ReadLine());


                SqlCommand cmd = new SqlCommand("total_marks", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                Console.WriteLine("Entered Student Total: " + (reader.GetInt32(1)));
                reader.Close();

                reader = cmd.ExecuteReader();
                Console.WriteLine("\nStudents Below the entered Candidate.... ");
                Console.WriteLine("Id and total mark: ");
                int i = 0;
                while (reader.Read())
                {
                    if (i > 0)
                    {
                        Console.Write(reader.GetInt32(0) + " ");
                        Console.Write(reader.GetInt32(1) + "\n");
                    }
                    i++;
                    
                }

                Console.WriteLine("Sucessfully displayed");
                sql.Close();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace movies
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

                Console.WriteLine("Enter the Movie genre : ");
                string genre = Console.ReadLine();
                Console.WriteLine();

                SqlCommand cmd = new SqlCommand("select * from dbo.movie_info(@genre)", sql);
                cmd.Parameters.Add("@genre", System.Data.SqlDbType.VarChar).Value = genre;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) );
                }
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
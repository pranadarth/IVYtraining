//Write a C# program to display Account details and Customer information of users 
//(Account number, Customer name, Aadhar number, Account opened date, date of last transaction, etc) 
//whose account balance is greater than 200000. Pull information from 2 tables,
//Use UDF and display information on screen.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace accountdetails
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

                Console.WriteLine("Enter the account balance : ");
                long bal = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine();

                SqlCommand cmd = new SqlCommand("select * from dbo.account_details(@bal)", sql);
                cmd.Parameters.Add("@bal", System.Data.SqlDbType.BigInt).Value = bal;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetInt64(2));
                    Console.WriteLine(reader.GetDateTime(3));
                    Console.WriteLine(reader.GetDateTime(4));
                    Console.WriteLine(reader.GetInt64(5));
                    Console.WriteLine();
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
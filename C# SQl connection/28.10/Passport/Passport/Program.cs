//Write a C# program to get a list of values from the user. 
//(Passport information: passport number, candidate name, passport expiry date, years of validity, applied through channel 
//(Normal, Priority),etc) for atleast 10 candidates.Create a table and upload
// this information to the table using a Stored Procedure.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace passport
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

                int i = 0;
                while (i < 10)
                {
                    Console.Write("Enter Passport.no : ");
                    int passportNo = int.Parse(Console.ReadLine());

                    Console.Write("Enter Candidate name: ");
                    string Candidatename = Console.ReadLine();

                    Console.Write("Enter the Expiry Date: ");
                    string expirydate = Console.ReadLine();

                    Console.Write("Enter the years of validity: ");
                    int validity = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the Channel: ");
                    string Channel = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand("passport_data", sql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@p_no", System.Data.SqlDbType.Int).Value = passportNo;
                    cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = Candidatename;
                    cmd.Parameters.Add("@e_date", System.Data.SqlDbType.Date).Value = expirydate;
                    cmd.Parameters.Add("@vali", System.Data.SqlDbType.Int).Value = validity;
                    cmd.Parameters.Add("@channel", System.Data.SqlDbType.VarChar).Value = Channel;
                    cmd.ExecuteNonQuery();
                    i++;
                }

                Console.WriteLine("Data is uploaded successfully");
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
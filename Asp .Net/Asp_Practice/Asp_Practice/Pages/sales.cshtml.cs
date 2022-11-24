using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Asp_Practice.Pages
{
    public class salesModel : PageModel
    {
        public List<sales_table> List_sales = new List<sales_table>();
            
        public void OnGet()
        {
            try
            {
                string connect = "Data Source=INLPF3KSCQM;Initial Catalog=master;Integrated Security=True;";
                //string connection = _configuration.GetConnectionString("DefaultConnection");
                SqlConnection sqlcon = new SqlConnection(connect);
                sqlcon.Open();

                SqlCommand cmd = new SqlCommand("sale", sqlcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sales_table info = new sales_table();
                    info.name = reader.GetString(1);
                    info.city = reader.GetString(3);
                    info.amount = reader.GetInt32(2);

                    List_sales.Add(info);
                }
                List_sales.ForEach(x => Console.WriteLine(x.name+" "+x.amount+" "+x.city));
                sqlcon.Close();
            }
            catch( SqlException se)
            { Console.WriteLine("Sql Expection: " + se.Message); }
            catch( Exception E)
            { Console.WriteLine("General Expection: " + E.Message); }
        }
    }

    public class sales_table
    {
       public string name, city;
       public int amount;
    }

}


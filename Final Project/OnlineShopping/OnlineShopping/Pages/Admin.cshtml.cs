using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class AdminModel : PageModel
    {
       public int prodCount = 0;
       public int totalcount = 0,stock=0,sold=0;
     

        public void OnGet()
        {
            try
            {

                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=OnlineShopping;Integrated Security=True;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select prod_count,sale_count from products";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                   stock = stock + reader.GetInt32(0);
                   sold = sold + reader.GetInt32(1);    
                    prodCount++;

                }
               totalcount = sold + stock;
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
            }
        }

    }

   
}

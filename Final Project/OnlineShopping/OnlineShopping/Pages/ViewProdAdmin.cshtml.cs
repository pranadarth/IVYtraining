using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class ViewProdAdminModel : PageModel
    {
        public List<Prod_info> list_name = new List<Prod_info>();

        public void OnGet()
        {
            try
            {

                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=OnlineShopping;Integrated Security=True;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select * from products";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_info info = new Prod_info();
                    info.p_id = reader.GetInt32(0);
                    info.p_name = reader.GetString(1);
                    info.cat = reader.GetString(2);
                    info.amount = reader.GetInt32(3);
                    info.count = reader.GetInt32(4);

                    list_name.Add(info);


                }
                
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

    public class Prod_info
    {
        public int p_id;
        public string p_name, cat, meta1, meta2;
        public int amount, count;

    }

}

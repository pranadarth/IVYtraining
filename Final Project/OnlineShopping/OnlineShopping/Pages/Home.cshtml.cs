using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace OnlineShopping.Pages
{
    public class HomeModel : PageModel
    {
        public List<Prod_info> main_list = new List<Prod_info>();
       public Customer_info get = new Customer_info();
        public string message="Not";
        public void OnGet()
        {
            
           
            try
            {
                
                get.c_email = Request.Query["E_Id"];
                message = Request.Query["mess"];
                if(message != "Success") { message = "Not"; }
                else { message= "1 item added to the cart Successfully!"; }
                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select prod_name,price,meta_data1,meta_data2 from products";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prod_info main = new Prod_info();

                    main.p_name =  reader.GetString(0);
                    main.amount =  reader.GetInt32(1);
                    main.meta1 = reader.GetString(2);
                    main.meta2 = reader.GetString(3);

                    main_list.Add(main);

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
}

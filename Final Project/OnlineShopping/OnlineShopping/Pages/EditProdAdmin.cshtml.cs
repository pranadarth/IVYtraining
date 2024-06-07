using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class EditProdAdminModel : PageModel
    {
        public List<Prod_info> list_name = new List<Prod_info>();
        public Prod_info update = new Prod_info();
        public string success_msg = "";
        public string error_msg = "";
        public void OnGet()
        {

            try
            {
                update.p_id = Convert.ToInt32(Request.Query["id"]);

                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select prod_name,category,price,prod_count from products where prod_Id=@id";


                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = update.p_id;
                

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    update.p_name = reader.GetString(0);
                    update.cat = reader.GetString(1);
                    update.amount = reader.GetInt32(2);
                    update.count = reader.GetInt32(3);

                }
                
                //Console.Log(list_name);
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
                error_msg = ex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
                error_msg = ex.Message;
            }
        }


        public void OnPost()
        {
            try
            {
                update.p_id = Convert.ToInt32(Request.Query["id"]);
                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);


               
                update.amount = Convert.ToInt32(Request.Form["amount"]);
                update.count = Convert.ToInt32(Request.Form["count"]);

                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("editProd", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@p_id", System.Data.SqlDbType.NVarChar).Value = update.p_id;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = update.amount;
                cmd.Parameters.Add("@count", System.Data.SqlDbType.Int).Value = update.count;
                Console.WriteLine("Updated: "+update.p_id + " " + update.amount+" " + update.count);
               
                cmd.ExecuteNonQuery();



                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
                error_msg = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
                error_msg = ex.Message;
                return;
            }
            update.p_name = "";
            update.amount = 0;
            update.cat = "";
            update.count = 0;

            success_msg = "Succefully added";
            


        }

    }
}

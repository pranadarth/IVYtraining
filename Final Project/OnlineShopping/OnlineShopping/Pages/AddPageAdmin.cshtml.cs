using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class AddPageAdminModel : PageModel
    {
        public Prod_info infos = new Prod_info();
        public string success_msg = "";
        public string error_msg = "";
        public void OnPost()
        {
            try
            {
                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                

                infos.p_name = Request.Form["name"];
                infos.amount = Convert.ToInt32(Request.Form["amount"]);
                infos.cat = Request.Form["cat"];
                infos.count = Convert.ToInt32(Request.Form["count"]);
                infos.meta1 = Request.Form["meta1"];
                infos.meta2 = Request.Form["meta2"];

               sqlCon.Open();

                SqlCommand cmd = new SqlCommand("addProd", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = infos.p_name;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = infos.amount;
                cmd.Parameters.Add("@cat", System.Data.SqlDbType.NVarChar).Value = infos.cat;
                cmd.Parameters.Add("@count", System.Data.SqlDbType.Int).Value = infos.count;
            cmd.Parameters.Add("@meta1", System.Data.SqlDbType.NVarChar).Value = infos.meta1;
            cmd.Parameters.Add("@meta2", System.Data.SqlDbType.NVarChar).Value = infos.meta2;

            cmd.ExecuteNonQuery();



                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
                error_msg = ex.Message;
                if (ex.Message.Contains("Violation of UNIQUE KEY"))
                    error_msg = "This product already  Exist!!, Please go to 'Product Details' Page to view";
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
                error_msg = ex.Message;
                return;
            }
            infos.p_name = "";
            infos.amount = 0;
            infos.cat = "";
            infos.count = 0;

            success_msg = "Succefully added";

        }
    }
}

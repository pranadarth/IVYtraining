using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class ProfileMainModel : PageModel
    {
       
        public Customer_info update = new Customer_info();
        public string success_msg = "";
        public string error_msg = "";
        public void OnGet()
        {

            try
            {
                update.c_email =    Request.Query["E_Id"];
                Console.WriteLine("Profile Page: "+update.c_email);
                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select UserName,PhoneNumber,PassWord from customers where EmailId = @e_id";


                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = update.c_email;


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    update.c_name = reader.GetString(0);
                    update.c_p_no = reader.GetInt64(1);
                    update.c_pass = reader.GetString(2);

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
                update.c_email = Request.Query["E_Id"];
                string ConnectionString = "Data Source=(localdb)\\localhost;Initial Catalog=OnlineShopping;;User Id=sa;Password=sql@11;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);

              

                sqlCon.Open();

                string query = "select UserName,PhoneNumber,PassWord from customers where EmailId = @e_id";


                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = update.c_email;


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    update.c_name = reader.GetString(0);
                    update.c_pass = reader.GetString(2);

                }
                string defaultPass = update.c_pass;
                sqlCon.Close();
                sqlCon.Open();
                update.c_p_no = Convert.ToInt64(Request.Form["phone"]);
                update.c_pass = Request.Form["ChangePassword"];

                SqlCommand cmd1 = new SqlCommand("EditCustomer", sqlCon);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                cmd1.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = update.c_email;
                cmd1.Parameters.Add("@phone", System.Data.SqlDbType.BigInt).Value = update.c_p_no;
                if (update.c_pass != "")
                    cmd1.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = update.c_pass;
                else
                {
                    update.c_pass = defaultPass;
                    Console.WriteLine("Updating only phone number, Default password: "+ update.c_pass);
                    cmd1.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = update.c_pass;
                }
                cmd1.ExecuteNonQuery();

                Console.WriteLine("Updated: " + update.c_email + " " + update.c_p_no + " " + update.c_pass);

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
           
            

            success_msg = "Succefully added";
            



        }
    }
}

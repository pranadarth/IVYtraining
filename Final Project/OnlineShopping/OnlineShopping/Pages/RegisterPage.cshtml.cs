using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class RegisterPageModel : PageModel
    {
        Customer_info info = new Customer_info();
        public string Re_pass="";
        public string success = "";
        public void OnPost()
        {
            try
            {
                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=OnlineShopping;Integrated Security=True;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);

            info.c_name = Request.Form["name"];
            info.c_p_no = Convert.ToInt64(Request.Form["phone"]);
            string temp_pass1 = Request.Form["psw"];
            string temp_pass2= Request.Form["psw-repeat"];
                if (temp_pass1 == temp_pass2)
                    info.c_pass = Request.Form["psw"];
                else
                {
                    Re_pass = "Re_Entered Password is not matching!!!";
                    Console.WriteLine(Re_pass);
                   
                }
            info.c_email = Request.Form["email"];



            sqlCon.Open();

            SqlCommand cmd = new SqlCommand("Register", sqlCon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = info.c_name;
            cmd.Parameters.Add("@phone", System.Data.SqlDbType.BigInt).Value = info.c_p_no;
            cmd.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = info.c_email;
            cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = info.c_pass;

            cmd.ExecuteNonQuery();



            sqlCon.Close();

                success = "Registered Successfully";
                Console.WriteLine("Registered Successfully, Now you can Login !");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
                if (ex.Message.Contains("Violation of UNIQUE KEY"))
                     Re_pass = "User Already Exist, Please Login!!";
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
                return;
            }
            info.c_name = "";
            info.c_p_no = 0;
            info.c_pass = "";
            info.c_email = "";

        }
    }
}

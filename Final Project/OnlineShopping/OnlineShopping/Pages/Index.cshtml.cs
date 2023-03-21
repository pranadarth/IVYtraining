using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
 using System.Data.SqlClient;


namespace OnlineShopping.Pages
{
    public class IndexModel : PageModel
    {
        Customer_info info = new Customer_info();
        public string error = "";
        public void OnPost()
        {
            try
            {
                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=OnlineShopping;Integrated Security=True;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);

                info.c_email = Request.Form["uname"];
                string temp_pass = Request.Form["psw"];

                if(info.c_email == "admin@gmail.com" && temp_pass=="admin1234")
                {
                    Thread.Sleep(1000);
                    Response.Redirect("/Admin");
                }

                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("UserLogin", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = info.c_email;

                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                info.c_pass = reader.GetString(0);

                sqlCon.Close();
                Console.WriteLine(temp_pass + " "+ info.c_pass);
                if (temp_pass == info.c_pass)
                {
                    Console.WriteLine("Login Success");
                    Response.Redirect("/Home?E_Id=" + info.c_email);
                }
                else
                {
                    Console.WriteLine("Login Failed");
                    error = "Entered Password is Invalid ";
                }
            }
            catch (SqlException ex)
            { 
                Console.WriteLine("Sql related problem: ");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("C# related problem: ");
                Console.WriteLine(ex.Message);
                if(ex.Message=="Invalid attempt to read when no data is present.")
                error = "User Doesn't exist, Please SignUp for Login";
            }
        }
    }
}
public class Customer_info
{
    public int c_id;
    public string c_name, c_email, c_pass;
    public long c_p_no;
    


}
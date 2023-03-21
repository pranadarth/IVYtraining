using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace OnlineShopping.Pages
{
    public class CartModel : PageModel
    {
        public List<CartInfo> Cartlist = new List<CartInfo>();
        public List<CartInfo> list = new List<CartInfo>();
        public CartInfo info1 = new CartInfo();
        public int cartCount = 0,cartPrice = 0;
        public void OnGet()
        {
            try
            {
                info1.c_email = Request.Query["E_Id"];
                string ConnectionString = "Data Source=INLPF3KSCQM;Initial Catalog=OnlineShopping;Integrated Security=True;";
                SqlConnection sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();
                string query = "select * from MyCart where Customer_Email = @e_id order by ProductName";

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.Add("@e_id", System.Data.SqlDbType.NVarChar).Value = info1.c_email;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CartInfo info = new CartInfo();
                    info.p_name = reader.GetString(1);
                    info.amount = reader.GetInt32(2);
                    info.meta1 = reader.GetString(3);
                    info.count = 0;

                    cartPrice += info.amount;
                    Cartlist.Add(info);


                }

                sqlCon.Close();

                
                int t=1;
                foreach(var x in Cartlist)
                {
                    sqlCon.Open();
                    if (t == 1)
                    {
                        string query1 = "select count(*) from MyCart where ProductName = @prod_name and Customer_Email = @c_email";

                        SqlCommand cmd1 = new SqlCommand(query1, sqlCon);
                        cmd1.Parameters.Add("@prod_name", System.Data.SqlDbType.NVarChar).Value = x.p_name;
                        cmd1.Parameters.Add("@c_email", System.Data.SqlDbType.NVarChar).Value = info1.c_email;
                        SqlDataReader reader1 = cmd1.ExecuteReader();

                        reader1.Read();
                        x.count = reader1.GetInt32(0);

                        if(x.count > 1) { t = x.count; }

                        list.Add(x);
                        
                    }
                    else
                    {
                        t--;
                    }
                    sqlCon.Close();
                }
                
                foreach (var x in list)
                {
                    Console.WriteLine(x.p_name+" "+x.count);
                    cartCount++;

                }

                   
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

    public class CartInfo
    {
        public string p_name,meta1,c_email;
        public int amount,count;

    }

}

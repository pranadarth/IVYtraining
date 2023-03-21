using System.Data.SqlClient;
class pratice
{
    public static void Main( string[] args)
    {
        string connection = "Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlcon = new SqlConnection(connection);
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Effects;

namespace TabularMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
       
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshdata();
        }

       

        private void Refresh(object sender, RoutedEventArgs e)
        {
            refreshdata();
        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {
            BlurEffect bg = new BlurEffect();
            bg.Radius = 30;

            MainContent.Effect = bg;

            EditPg.Visibility = Visibility.Visible;
            MainContent.IsEnabled = false;

            DataRowView dg = dataG.SelectedItems[0] as DataRowView;

            EditId.Text = dg[0].ToString();
           EditName.Text = dg[1].ToString();
          EditDesign.Text = dg[2].ToString(); 

            EditName.SelectAll();
            EditName.Focus();
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            DataRowView dg = (DataRowView)dataG.SelectedItems[0];
           

            SqlConnection con = new SqlConnection(@"Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteOfficeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eId", SqlDbType.BigInt).Value = long.Parse(dg[0].ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            refreshdata();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("EditOfficeData", con);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@eId", SqlDbType.BigInt).Value =long.Parse(EditId.Text);
           cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = EditName.Text;
           cmd.Parameters.AddWithValue("@Desig", SqlDbType.NVarChar).Value = EditDesign.Text;
           cmd.ExecuteNonQuery();
            con.Close();

            EditPg.Visibility = Visibility.Collapsed;
            MainContent.Effect = null;
            MainContent.IsEnabled = true;

            refreshdata();
        }

        public void refreshdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from officeData Order by EmpId", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "office");

            Console.WriteLine(ds.Tables[0]);
            if (ds.Tables[0].Rows.Count > 0)
                dataG.ItemsSource = ds.Tables["office"].DefaultView;

            con.Close();
        }


    }
}

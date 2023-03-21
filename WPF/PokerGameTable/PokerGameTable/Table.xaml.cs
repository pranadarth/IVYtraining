using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokerGameTable
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        SoundPlayer mp = new SoundPlayer("C:\\Users\\suresh.pranadarth\\source\\repos\\IVYtraining\\WPF\\PokerGameTable\\PokerGameTable\\Sounds\\global backgroundmusic.wav");
        public Table()
        {
            InitializeComponent();
            refreshdata();
            

        }

        public void startmusic()
        {
           
            
           
            mp.PlayLooping();
        }

        public void stopmusic()
        {
            mp.Stop();
        }

        public void refreshdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=INLPF3KSCQM;Initial Catalog=Practice;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Games", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataG.ItemsSource = ds.Tables[0].DefaultView;
            }
            con.Close();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            LaunchWindow lw = new LaunchWindow();
            this.Close();
            lw.PlayBtn.Content = "Continue";
            lw.Show();

        }

        private void PlayBtn(object sender, RoutedEventArgs e)
        {
            Thread newWindowThread = new Thread(new ThreadStart(LaunchWindow));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();


        }

        private void LaunchWindow()
        {
            ControlWindow cw = new ControlWindow();
            cw.Show();
            
            System.Windows.Threading.Dispatcher.Run();
        }
    }
}

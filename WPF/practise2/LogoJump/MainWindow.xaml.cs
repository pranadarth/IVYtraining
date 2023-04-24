using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LogoJump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double h, w;
        Storyboard sb;

        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            h = System.Windows.SystemParameters.PrimaryScreenWidth;
            w = System.Windows.SystemParameters.PrimaryScreenHeight;

            sb = this.FindResource("jump") as Storyboard;
            sb.Completed += new EventHandler(logic);
            RandomFunc();

        }

        

        private void logic(object sender, EventArgs e)
        {
            RandomFunc();
        }

       

        private void RandomFunc()
        {
            Random rd= new Random();
            int ht = Int32.Parse(Math.Round(h).ToString());
            int wd = Int32.Parse(Math.Round(w).ToString());
            double x = double.Parse(rd.Next(1,ht-50 ).ToString());
           double y = double.Parse(rd.Next(1,wd -50).ToString());
            this.Resources["margin"] = new Thickness(x, y,0,0);
           

            sb.Begin(this);

            /* MessageBox.Show(x+" "+y);*/

            //this.Resources["margin"] = new Thickness(double.Parse(rd.Next(1, Int32.Parse(Math.Round(h).ToString())).ToString()) - 50,
            //                                         double.Parse(rd.Next(1, Int32.Parse(Math.Round(w).ToString())).ToString()) - 50, 0, 0);

        }
    }
}

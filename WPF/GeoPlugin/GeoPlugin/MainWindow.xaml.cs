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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calc;
using System.Device.Location;
using System.Data.SqlClient;
using MyGeoLocator;
using FilePathFinder;

namespace GeoPlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>n
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //UserControl1 ul = new UserControl1();
            //LayoutRoot.Children.Add(ul);
            
        }
        Location loco = new Location();
        private void LoginBtn(object sender, RoutedEventArgs e)
        {

            if (loco.LocationCheck(10))
            {
                Result.Content = "Welcome Back";
                Result.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                Result.Content = "Sorry!!..Not Yet Available \n in your country";
                Result.Background = new SolidColorBrush(Colors.IndianRed);
            }
        }
               
    }
}

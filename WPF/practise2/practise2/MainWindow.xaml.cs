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
using System.Timers;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows.Markup;

using System.ComponentModel;
using Microsoft.Win32;

namespace practise2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            //animationStoryboard = FindResource("AnimationStoryboard") as Storyboard;
            DataContext = this;
            ColorCode = null;

        }

        private string colorcode;

        public string ColorCode
        {
            get { return colorcode; }
            set { colorcode = value; }
        }




        /* private void element_Click(object sender, RoutedEventArgs e)
         {
             double angleInDegrees = 0;
             double centerX = element.ActualWidth / 2;
             double centerY = element.ActualHeight / 2;
             double radiusX = ellipse.ActualWidth / 2;
             double radiusY = ellipse.ActualHeight / 2;
             double angleInRadians = angleInDegrees * (Math.PI / 180);

             double x = centerX + radiusX * Math.Cos(angleInRadians);
             double y = centerY + radiusY * Math.Sin(angleInRadians);
             Console.WriteLine(x + " " + y);
             // Set the Margin of the element to position it on the ellipse
             element.Margin = new Thickness(x, y, 0, 0);
         }*/

        //private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    // Set the desired angle in degrees
        //    double angleInDegrees =  Double.Parse(Angle.Text);

        //    // Calculate the coordinates based on the angle
        //    double centerX = ellipse.ActualWidth / 2;
        //    double centerY = ellipse.ActualHeight / 2;
        //    double radiusX = ellipse.ActualWidth / 2;
        //    double radiusY = ellipse.ActualHeight / 2;
        //    double angleInRadians = angleInDegrees * (Math.PI / 180);

        //    double x = radiusX * Math.Cos(angleInRadians);
        //    double y = radiusY * Math.Sin(angleInRadians);
        //    Console.WriteLine(x + " " + y);
        //    // Set the Margin of the element to position it on the ellipse
        //    element.X = x;
        //    element.Y = y;
        //}
    }
}

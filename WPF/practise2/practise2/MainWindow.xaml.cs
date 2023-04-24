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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Foundation;
using WpfCamera;

namespace practise2
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();
          

           
           
        }

        

        private void enterKey(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
               

                TextBlock txtb = new TextBlock();
                txtb.Text = Type.Text;
                txtb.FontWeight = FontWeights.Bold;
                txtb.MaxWidth = 200;
                txtb.MaxHeight= 50;
                txtb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#50EFF9"));
                txtb.FontSize = 12;
                txtb.FontFamily = new FontFamily("Saira");
                txtb.Padding = new Thickness(10, 0, 10, 0);
                txtb.TextWrapping = TextWrapping.Wrap;
                txtb.Margin = new Thickness(0,6,0,6);
                /*txtb.VerticalAlignment= VerticalAlignment.Top;
                txtb.HorizontalAlignment= HorizontalAlignment.Left;*/
                 if(i++ % 2 == 0)
                { Wrap1.Children.Add(txtb); } 
                 else
                { Wrap2.Children.Add(txtb); }
                
                
               


            }
            else if(e.Key==Key.Escape)
            {
                Wrap.Children.Clear();
            }

        }


    }
}

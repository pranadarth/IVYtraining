using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokerGameTable
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        ControlWindow cx;
        public int ck = 0;
        public double amount = 0.00;
        public ControlWindow( )
        {
            InitializeComponent();
            
            
        }
        public  void Setobj(ControlWindow Cw)
        { cx = Cw; }
       


        private void Start(object sender, RoutedEventArgs e)
        {

            if (((bool)TwoCk.IsChecked == true || (bool)FourCk.IsChecked == true))
                {
                if ((bool)TwoCk.IsChecked)
                    ck = 1;
                else
                    ck = 0;
                amount = slider1.Value;

                this.Close();
                Table tb = new Table();
                tb.stopmusic();
                GameWindow GW = new GameWindow(ck, amount);
                GW.Show();
            }
            else 
            {

                MessageBox.Show("Invalid Input");

            }

        }
       

        private void Plus(object sender, RoutedEventArgs e)
        {
            slider1.Value += 0.50;
        }

        private void Minus(object sender, RoutedEventArgs e)
        {
            slider1.Value -= 0.50;
        }

        private void Max(object sender, RoutedEventArgs e)
        {
            slider1.Value = 10;
        }

        private void Min(object sender, RoutedEventArgs e)
        {
            slider1.Value = 1;
        }
        private void Back(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            
            
        }

        
    }
}

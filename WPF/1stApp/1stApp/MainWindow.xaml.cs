using System;
using System.Collections.Generic;
using System.IO;
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

namespace _1stApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> data = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = uName.Text;
            string email = EID.Text;
            bool m = (bool)male.IsChecked;
            bool f = (bool)female.IsChecked;
            bool n = (bool)NA.IsChecked;
            if (name == "" || email == "" || !(m == true || f == true || n == true))
                MessageBox.Show("INVALID Input !!");
            else
            {
                string form = string.Format("\nName: " + name + " \nEmailID: " + email + "\nMale: {0}  Female: {1}  NA: {2}", m, f, n);


                if (MessageBox.Show(form,"Check!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    
                }
                else
                {
                    return;
                }

                fileadd(form);
                uName.Text = "";
                EID.Text = "";
                male.IsChecked = false;
                female.IsChecked = false;
                NA.IsChecked = false;
                MessageBox.Show("Details Entered Succesfully");
            }

        }

        private void fileadd(string da)
        {
            data.Add(da);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = File.AppendText("data.txt");
            foreach (string s in data)
            {
                sw.WriteLine(s);
            }
            sw.Close();
            Close();
        }
    }
}

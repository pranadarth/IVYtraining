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
using System.Windows.Shapes;
using TabularMvvm.ViewModel;

namespace TabularMvvm.View
{
    /// <summary>
    /// Interaction logic for OfficeData.xaml
    /// </summary>
    public partial class OfficeData : Window
    {
       
        public OfficeData()
        {
            InitializeComponent();
            //this.DataContext=new EmployeeViewModel();
            //Loaded += OfficeData_Loaded;
        }

     



        //private void OfficeData_Loaded(object sender, RoutedEventArgs e)
        //{
        //     viewModel = new EmployeeViewModel();  
        //     DataContext = viewModel;
        //}
    }
}

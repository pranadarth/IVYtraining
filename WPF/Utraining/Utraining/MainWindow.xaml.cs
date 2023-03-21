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

namespace Utraining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mp =new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            mp.Open(new Uri("C:\\Users\\suresh.pranadarth\\source\\repos\\IVYtraining\\WPF\\PokerGameTable\\PokerGameTable\\Sounds\\global backgroundmusic.wav"));
            mp.Play();
           mp.MediaEnded += new EventHandler(Media_Ended);

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mp.Volume= slider.Value;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
              mp.Position = TimeSpan.Zero;
            mp.Play();
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace ImageAnimations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // Anime();
            DataContext= this;
           //ImgSrc = new BitmapImage(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\ImageAnimations\ImageAnimations\Images\T Clock_Smoke_White_Loop0000.png"));

           ChangeSmokeImg();
        }
        /* private async void Anime()
         {
             Storyboard sb = new Storyboard();



             ObjectAnimationUsingKeyFrames imgAnime = new ObjectAnimationUsingKeyFrames();
             imgAnime.Duration = new Duration(TimeSpan.FromSeconds(5));

             DiscreteObjectKeyFrame imgKey = new DiscreteObjectKeyFrame();


             BitmapImage bitmap = new BitmapImage();


             double second = 0.2;

             for (int i = 10; i <= 47; i++) 
             {

                 imgKey.KeyTime = TimeSpan.FromSeconds(second + 0.2);
                 bitmap.UriSource = new Uri($@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\ImageAnimations\ImageAnimations\Images\T Clock_Smoke_White_Loop00{i}.png");
                 imgKey.Value = bitmap;
                 imgAnime.KeyFrames.Add(imgKey);
             }



            Smoke.BeginAnimation(Image.SourceProperty, imgAnime);


         }*/

        DispatcherTimer timer;
        
        void ChangeSmokeImg()
        {
            ImgSrc = new BitmapImage(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\ImageAnimations\ImageAnimations\Images\T Clock_Smoke_White_Loop0000.png"));

            int i = 1;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.03);
            timer.Tick += (s, a) =>
            {
                if (i > 47)
                {
                    timer.Stop();
                    ChangeLoadingImg();
                }
                else
                    ImgSrc = new BitmapImage(new Uri($@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\ImageAnimations\ImageAnimations\Images\T Clock_Smoke_White_Loop00{i++:00}.png"));
            };
            timer.Start();
        }

        void ChangeLoadingImg()
        {
            
            int i = 10;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.03);
            timer.Tick += (s, a) =>
            {
                if (i > 399)
                {
                    timer.Stop();
                    ChangeSmokeImg();
                }
                else
                    ImgSrc = new BitmapImage(new Uri($@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\ImageAnimations\ImageAnimations\Images\Tourney Clock_White_60FPS_{i++:000}.png"));
            };
            timer.Start();
        }








        private BitmapImage imgSrc ;
        public BitmapImage ImgSrc 
        { get { return imgSrc; }
            set {  imgSrc = value; OnPropertyChange(nameof(ImgSrc)); } 
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

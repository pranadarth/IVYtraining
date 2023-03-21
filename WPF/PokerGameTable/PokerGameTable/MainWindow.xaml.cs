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

namespace PokerGameTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> Points1 = new List<Point>();
        Storyboard sb, sb1, sb2;
        MediaPlayer mp = new MediaPlayer();
        MediaPlayer mp1 = new MediaPlayer();
        LaunchWindow lw = new LaunchWindow();
        public MainWindow()
        {
            InitializeComponent();
            Points1.Add(new Point(460, 120)); //Start for point1.Add
                                              //Points1.Add(new Point(470, 130));

            Points1.Add(new Point(580, 240));

            Points1.Add(new Point(300, 110)); //rev to initial Point1
            Points1.Add(new Point(460, 120));
            mp.Open(new Uri("C:\\Users\\suresh.pranadarth\\Downloads\\WpfApp8\\WpfApp8\\Sound\\wrong-place-129242 (mp3cut.net).mp3"));

            mp.MediaEnded += new EventHandler(Continue);
            mp.Play();
            InitAnimation();
            InitAnime();
        }

        public void Continue(object sender, EventArgs e)
        {
            mp1.Open(new Uri("C:\\Users\\suresh.pranadarth\\Downloads\\WpfApp8\\WpfApp8\\Sound\\mixkit-bonus-extra-in-a-video-game-2064.wav"));
            mp1.Play();
        }
        public void InitAnime()
        {
            sb= new Storyboard();
            sb.Name = "stright";
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.To = 0;
            sb.Children.Add(da);
            Storyboard.SetTargetProperty(da, new PropertyPath(ScaleTransform.ScaleXProperty));
            Storyboard.SetTargetName(da, "bottomAnime");

            DoubleAnimation da1 = new DoubleAnimation();
            da1.Duration = new Duration(TimeSpan.FromSeconds(3));
            da1.To = 0;
            sb.Children.Add(da1);
            Storyboard.SetTargetProperty(da1, new PropertyPath(ScaleTransform.ScaleYProperty));
            Storyboard.SetTargetName(da1, "topAnime");

            sb.Begin(this);
        }
        public void InitAnimation()
        {
            sb1 = new Storyboard();
            

            for (int i = 0; i < Points1.Count - 1; ++i)
            {
                //new line for current line segment
                var l = new Line();
                l.Stroke = Brushes.Red;
                l.StrokeThickness = 3;


                //data from list
                var startPoint = Points1[i];
                var endPoint = Points1[i + 1];


                l.X1 = startPoint.X;
                l.Y1 = startPoint.Y;
                l.X2 = startPoint.X;
                l.Y2 = startPoint.Y;
                lineCanvas.Children.Add(l);


                var daX = new DoubleAnimation(endPoint.X, new Duration(TimeSpan.FromMilliseconds(1000)));
                var daY = new DoubleAnimation(endPoint.Y, new Duration(TimeSpan.FromMilliseconds(1000)));
                //begin time,sum of durations of earlier animations + 10 ms delay for each
                daX.BeginTime = TimeSpan.FromMilliseconds(i * 1010);
                daY.BeginTime = TimeSpan.FromMilliseconds(i * 1010);

                sb1.Children.Add(daX);
                sb1.Children.Add(daY);

                //Set the targets for the animations
                Storyboard.SetTarget(daX, l);
                Storyboard.SetTarget(daY, l);
                Storyboard.SetTargetProperty(daX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(daY, new PropertyPath(Line.Y2Property));
            }
            sb1.Completed += new EventHandler(NxtAnime);
            sb1.Begin(this);

        }
        public void NxtAnime(object sender, EventArgs e)
        {
            sb2 = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0.0;
            da.To = 1.0;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            sb2.Children.Add(da);
            Storyboard.SetTargetProperty(da, new PropertyPath(Rectangle.OpacityProperty));
            Storyboard.SetTargetName(da, "Glow");

            DoubleAnimation da1 = new DoubleAnimation();

            da1.To = 0.0;
            da1.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            da1.BeginTime = TimeSpan.FromSeconds(0.7);
            sb2.Children.Add(da1);
            Storyboard.SetTargetProperty(da1, new PropertyPath(Rectangle.OpacityProperty));
            Storyboard.SetTargetName(da1, "Glow");

            sb2.Completed += new EventHandler(NxtPage);
            sb2.Begin(this);

        }

        private void NxtPage (object sender, EventArgs e)
        {
            this.Close();
            lw.Show();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
          RemoveStoryboard rsb = new RemoveStoryboard();
            rsb.BeginStoryboardName = "stright" ;
           sb.Remove();
            sb1.Remove();
            sb2.Remove();

        }

       
    }
}

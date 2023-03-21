using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PokerGameTable
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
   
    public partial class GameWindow : Window
    {
       
        int nplayer = 4;
        int twoid = 0;
        int fourid = 2;
        int fourTemp= 3;
        int TimerCount = 1,checkcls = 0;
        System.Windows.Threading.DispatcherTimer dt;
        public List<string> cards = new List<string>{  "black_jokerDrawingImage",  "_2_of_spadesDrawingImage",  "queen_of_hearts2DrawingImage","queen_of_diamonds2DrawingImage","_4_of_spadesDrawingImage",
                                                    "_9_of_spadesDrawingImage","ace_of_clubsDrawingImage", "_6_of_heartsDrawingImage","jack_of_hearts2DrawingImage","_6_of_diamondsDrawingImage",
                                                    "_4_of_diamondsDrawingImage", "_6_of_clubsDrawingImage","_7_of_clubsDrawingImage","_10_of_diamondsDrawingImage","_10_of_spadesDrawingImage",
                                                    "_7_of_heartsDrawingImage", "_9_of_clubsDrawingImage","king_of_spades2DrawingImage","_4_of_heartsDrawingImage","_4_of_clubsDrawingImage",
                                                    "ace_of_spades2DrawingImage" ,"_10_of_clubsDrawingImage","_7_of_spadesDrawingImage","_5_of_diamondsDrawingImage","_8_of_diamondsDrawingImage",
                                                    "_8_of_heartsDrawingImage","_3_of_diamondsDrawingImage","_8_of_spadesDrawingImage","_2_of_clubsDrawingImage","jack_of_clubs2DrawingImage",
                                                    "_2_of_diamondsDrawingImage","ace_of_diamondsDrawingImage", "_6_of_spadesDrawingImage","_3_of_spadesDrawingImage","_3_of_heartsDrawingImage",
                                                    "_5_of_clubsDrawingImage" , "queen_of_spades2DrawingImage","_3_of_clubsDrawingImage","ace_of_heartsDrawingImage","_10_of_heartsDrawingImage",
                                                    "jack_of_diamonds2DrawingImage","king_of_hearts2DrawingImage","king_of_diamonds2DrawingImage","_9_of_diamondsDrawingImage","red_jokerDrawingImage",
                                                    "_2_of_heartsDrawingImage","_5_of_spadesDrawingImage","jack_of_spades2DrawingImage","king_of_clubs2DrawingImage", "_5_of_heartsDrawingImage",
                                                    "queen_of_clubs2DrawingImage","_7_of_diamondsDrawingImage","_9_of_heartsDrawingImage","_8_of_clubsDrawingImage"};

        public DispatcherTimer _timer;

        //MediaPlayer sound = new MediaPlayer();
      //  MediaPlayer bg = new MediaPlayer();
      /*  BlurEffect effect;*/
        DoubleAnimation daDepth, daBlur;
        Storyboard sb2;
        Lazy<MediaPlayer> sound = new Lazy<MediaPlayer>();
        Lazy<MediaPlayer> bg = new Lazy<MediaPlayer>();
        Lazy<BlurEffect> effect ;
        //  Lazy<DoubleAnimation> daDepth,daBlur = new Lazy<DoubleAnimation>();    
        //  Lazy<Storyboard> sb2 = new Lazy<Storyboard>();       



        void Countdown(int count, TimeSpan interval, Action<int> ts, int i)
        {
            this.Resources["innerCircle"] = $"innerCircleBrush{i}";
            Storyboard sb = this.FindResource("TimerAnime") as Storyboard;
            sb.Begin();
            dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = interval;
            dt.Tick += (_, a) =>
            {
                if (count-- == 0)
                {
                    TimerStop(i);
                    
                }
                else
                    ts(count);
            };
            ts(count);
            dt.Start();
            this.Resources[$"timer{i}"] = 1.0;
        }
        void TimerStop(int i)
        {
            dt.Stop();
            this.Resources[$"timer{i}"] = 0.0;
            startAnimation();
            if (TimerCount <= 4)
            {
                if (nplayer == 2)
                {
                    if (twoid % 2 == 0)
                        Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber1.Content = cur.ToString(), 1);
                    else
                    { 
                        Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber3.Content = cur.ToString(), 3);
                        TimerCount++;
                    }
                }
                else
                    switch (fourid)
                    {
                        case 1:
                            Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber4.Content = cur.ToString(), 4);
                            TimerCount++; break;
                        case 2: Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber1.Content = cur.ToString(), 1); break;
                        case 3: Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber2.Content = cur.ToString(), 2); break;
                        case 4: Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber3.Content = cur.ToString(), 3); break;
                    }
            }
            else
            {
                GameOver.Visibility = Visibility.Visible;
               
                image1.Visibility = Visibility.Collapsed;
                image2.Visibility = Visibility.Collapsed;
                image3.Visibility = Visibility.Collapsed;
                image4.Visibility = Visibility.Collapsed;
                image5.Visibility = Visibility.Collapsed;
                
                sound.Value.Open(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\PokerGameTable\PokerGameTable\Sounds\GameOverSound.mp3"));
               
                sound.Value.Play();
                sound.Value.MediaEnded  += new EventHandler(AtEnd);
            }
        }

        private void AtEnd(object sender, EventArgs e)
        {
            if(checkcls == 0)
            dispose();

        }

        public void dispose()
        {
            checkcls = 1;

            sound = null;
            bg.Value.Stop();
            dt.Stop();
            bg = null;
            _timer = null;
            Player1Shadow.Visibility = Visibility.Collapsed;
            daBlur = daDepth = null;
            sb2 = null;
           
        }

        public GameWindow(int y, double x)
        {
            InitializeComponent();


            bg.Value.Open(new Uri("C:\\Users\\suresh.pranadarth\\source\\repos\\IVYtraining\\WPF\\PokerGameTable\\PokerGameTable\\Sounds\\Song.mp3"));
            bg.Value.Play();
            bg.Value.MediaEnded += new EventHandler(playagain);

            for (int i = 1; i <= 5; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(cards.Count);

                this.Resources[$"img{i}"] = this.Resources[cards[index]];
                this.Resources[$"timer{i}"] = 0.0;
                cards.RemoveAt(index);
            }
            this.Resources["player1"] = 1.0;

            if (y == 1)
            {
                this.Resources["player2"] = 0.0;
                this.Resources["player4"] = 0.0;
                player3.Text = "Player 2";
                Player3Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\Girl.png"));
                nplayer = 2;

            }
            else
            {
                this.Resources["player2"] = 0.6;
                this.Resources["player4"] = 0.6;

            }

            BetMoney.Text = "$ " + string.Format("{0:0.00}", x); ;


            this.Resources["player3"] = 0.6;

            for (int i = 1; i <= 4; i++)
            {
                if (1 == i)
                {
                    this.Resources[$"player{i}"] = 1.0;
                }
                else
                {
                   this.Resources[$"player{i}Shadow"] = 0.0;
                }


            }

            effect = new Lazy<BlurEffect>();
            effect.Value.Radius = 40;
            effect.Value.KernelType = KernelType.Box;
           
            Player1Shadow.Effect = effect.Value;
            Player1Shadow.Visibility = Visibility.Visible;

            

           daDepth = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.5)));
            daDepth.AutoReverse = true;
            daDepth.RepeatBehavior = RepeatBehavior.Forever;

            daBlur = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.5)));
            daBlur.AutoReverse = true;
            daBlur.RepeatBehavior = RepeatBehavior.Forever;

            /*Storyboard sb = new Storyboard();
            sb.Children.Add(daBlur);
            Storyboard.SetTargetProperty(daBlur, new PropertyPath(Image.EffectProperty));
            Storyboard.SetTargetName(daBlur, $"Player{i}Img");*/

           Player1Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth);
           
            Countdown(10, TimeSpan.FromSeconds(1), cur => TimerNumber1.Content = cur.ToString(), 1);
            sound.Value.Open(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\PokerGameTable\PokerGameTable\Sounds\GameStartSound.wav"));
            sound.Value.Play();
        }

        private void playagain(object sender, EventArgs e)
        {
            bg.Value.Position = TimeSpan.Zero;
            bg.Value.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sound.Value.Open(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\PokerGameTable\PokerGameTable\Sounds\ButtonClick.wav"));
            sound.Value.Play();
            //timer();
            //if()
            if(nplayer == 2) 
            {
                
                if (twoid % 2 == 0)
                {
                    TimerStop(1);
                }
                else
                    TimerStop(3);

            }
            else
            {
                int temp = fourid - 1;
                if (temp == 0)
                    temp = 4;
                TimerStop(temp);
            }
            

        }

        public void startAnimation()
        {
            if (nplayer == 2)
            {



                if (twoid % 2 == 0)
                {
                    this.Resources[$"player{1}"] = 0.6;
                    this.Resources[$"player{3}"] = 1.0;
                    twoid = twoid + 1;



                    
                    Player1Shadow.Visibility = Visibility.Collapsed;
                    Player3Shadow.Visibility = Visibility.Visible;
                    Player3Shadow.Effect = effect.Value;
                    effect.Value.BeginAnimation(DropShadowEffect.BlurRadiusProperty, daBlur);
                    Player3Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth);

                }
                else
                {
                    this.Resources[$"player{3}"] = 0.6;
                    this.Resources[$"player{1}"] = 1.0;

                    Player3Shadow.Visibility = Visibility.Collapsed;
                    Player1Shadow.Visibility = Visibility.Visible;
                    Player1Shadow.Effect = effect.Value;
                    Player1Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth);

                    if (twoid == 1)
                    {
                        Double bTime = 0;
                        Double bTime2 = 0;
                        DoubleAnimation da1 = new DoubleAnimation();
                        da1.From = 0;
                        da1.To = 200;
                        for (int i = 1; i <= 3; i++)
                        {
                            DoubleAnimation da2 = new DoubleAnimation();

                            da2.From = 0.0;
                            da2.To = 1.0;
                            da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                             sb2 = new Storyboard();
                            
                            Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                            Storyboard.SetTargetName(da2, $"Cover{i}");
                           

                           

                            da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                            da1.BeginTime = TimeSpan.FromSeconds(bTime2);
                           
                           

                            Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                            Storyboard.SetTargetName(da1, $"CoverTransform{4 - i}");

                           


                            bTime = bTime + 0.25;
                            DoubleAnimation da = new DoubleAnimation();
                            da.From = 0.0;
                            da.To = 1.0;
                            da.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                            da.BeginTime = TimeSpan.FromSeconds(bTime + 0.7);

                            
                            Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                            Storyboard.SetTargetName(da, $"image{4 - i}");

                            sb2.Children.Add(da2);
                            sb2.Children.Add(da1);
                            sb2.Children.Add(da);
                            sb2.Begin(this);
                            bTime2 = bTime2 + 0.20;
                            da1.To = da1.To - 100;

                        }

                    }
                    else if (twoid == 3)
                    {
                        DoubleAnimation da2 = new DoubleAnimation();

                        da2.From = 0.0;
                        da2.To = 1.0;
                        da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        sb2 = new Storyboard();
                        
                        Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da2, $"Cover{4}");
                        

                        DoubleAnimation da1 = new DoubleAnimation();
                        da1.From = 0;
                        da1.To = 300;

                        da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        

                        Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                        Storyboard.SetTargetName(da1, $"CoverTransform{4}");


                        

                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 0.0;
                        da.To = 1.0;
                        da.Duration = new Duration(TimeSpan.FromSeconds(1));
                        da.BeginTime = TimeSpan.FromSeconds(0.8);
                       
                        Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da, $"image{4}");

                        sb2.Children.Add(da2);
                        sb2.Children.Add(da1);
                        sb2.Children.Add(da);
                        sb2.Begin(this);


                    }
                    else if (twoid == 5)
                    {
                        DoubleAnimation da2 = new DoubleAnimation();

                        da2.From = 0.0;
                        da2.To = 1.0;
                        da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        sb2 = new Storyboard();

                        Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da2, $"Cover{5}");


                        DoubleAnimation da1 = new DoubleAnimation();
                        da1.From = 0;
                        da1.To = 300;

                        da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));


                        Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                        Storyboard.SetTargetName(da1, $"CoverTransform{5}");




                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 0.0;
                        da.To = 1.0;
                        da.Duration = new Duration(TimeSpan.FromSeconds(1));
                        da.BeginTime = TimeSpan.FromSeconds(0.8);

                        Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da, $"image{5}");

                        sb2.Children.Add(da2);
                        sb2.Children.Add(da1);
                        sb2.Children.Add(da);
                        sb2.Begin(this);

                    }
                    twoid = twoid + 1;
                }


            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {


                   
                    if (fourid == i)
                    {
                        this.Resources[$"player{i}"] = 1.0;
                      

                        switch (i)
                        {
                            case 1: 
                                Player1Shadow.Effect = effect.Value;
                                Player1Shadow.Visibility = Visibility.Visible;
                                Player1Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth); break;
                            case 2:
                                
                                Player2Shadow.Effect = effect.Value;
                                Player2Shadow.Visibility = Visibility.Visible;
                                Player2Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth); break;
                            case 3:
                                Player3Shadow.Effect = effect.Value;
                                Player3Shadow.Visibility = Visibility.Visible;
                                Player3Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth); break;
                            case 4:
                                Player4Shadow.Effect = effect.Value;
                                Player4Shadow.Visibility = Visibility.Visible;
                                Player4Shadow.BeginAnimation(Ellipse.OpacityProperty, daDepth); break;
                        }

                        
                      
                       


                    }
                    else
                    {
                        this.Resources[$"player{i}"] = 0.6;


                        switch (i)
                        {
                            case 1: Player1Shadow.Visibility = Visibility.Collapsed; break;
                            case 2: Player2Shadow.Visibility = Visibility.Collapsed; break;
                            case 3: Player3Shadow.Visibility = Visibility.Collapsed; break;
                            case 4: Player4Shadow.Visibility = Visibility.Collapsed; break;
                        }


                    }
                }


                if (fourid == 1 && fourTemp == 3)
                {
                    Double bTime = 0;
                    Double bTime2 = 0;
                    DoubleAnimation da1 = new DoubleAnimation();
                    da1.From = 0;
                    da1.To = 200;
                    for (int i = 1; i <= 3; i++)
                    {
                        DoubleAnimation da2 = new DoubleAnimation();

                        da2.From = 0.0;
                        da2.To = 1.0;
                        da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        sb2 = new Storyboard();

                        Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da2, $"Cover{i}");




                        da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        da1.BeginTime = TimeSpan.FromSeconds(bTime2);



                        Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                        Storyboard.SetTargetName(da1, $"CoverTransform{4 - i}");




                        bTime = bTime + 0.25;
                        DoubleAnimation da = new DoubleAnimation();
                        da.From = 0.0;
                        da.To = 1.0;
                        da.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                        da.BeginTime = TimeSpan.FromSeconds(bTime + 0.7);


                        Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                        Storyboard.SetTargetName(da, $"image{4 - i}");

                        sb2.Children.Add(da2);
                        sb2.Children.Add(da1);
                        sb2.Children.Add(da);
                        sb2.Begin(this);
                        bTime2 = bTime2 + 0.20;
                        da1.To = da1.To - 100; //sb1.Completed += (o, s) => MessageBox.Show("check point");


                    }
                    fourTemp++;
                }
                else if (fourid == 1 && fourTemp == 4)
                {
                    DoubleAnimation da2 = new DoubleAnimation();

                    da2.From = 0.0;
                    da2.To = 1.0;
                    da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                    sb2 = new Storyboard();

                    Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                    Storyboard.SetTargetName(da2, $"Cover{4}");


                    DoubleAnimation da1 = new DoubleAnimation();
                    da1.From = 0;
                    da1.To = 300;

                    da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));


                    Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                    Storyboard.SetTargetName(da1, $"CoverTransform{4}");




                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 0.0;
                    da.To = 1.0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    da.BeginTime = TimeSpan.FromSeconds(0.8);

                    Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                    Storyboard.SetTargetName(da, $"image{4}");

                    sb2.Children.Add(da2);
                    sb2.Children.Add(da1);
                    sb2.Children.Add(da);
                    sb2.Begin(this);

                    fourTemp++;
                }
                else if (fourid == 1 && fourTemp == 5)
                {
                    DoubleAnimation da2 = new DoubleAnimation();

                    da2.From = 0.0;
                    da2.To = 1.0;
                    da2.Duration = new Duration(TimeSpan.FromSeconds(0.75));
                    sb2 = new Storyboard();

                    Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));
                    Storyboard.SetTargetName(da2, $"Cover{5}");


                    DoubleAnimation da1 = new DoubleAnimation();
                    da1.From = 0;
                    da1.To = 300;

                    da1.Duration = new Duration(TimeSpan.FromSeconds(0.75));


                    Storyboard.SetTargetProperty(da1, new PropertyPath(TranslateTransform.XProperty));
                    Storyboard.SetTargetName(da1, $"CoverTransform{5}");




                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 0.0;
                    da.To = 1.0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    da.BeginTime = TimeSpan.FromSeconds(0.8);

                    Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                    Storyboard.SetTargetName(da, $"image{5}");

                    sb2.Children.Add(da2);
                    sb2.Children.Add(da1);
                    sb2.Children.Add(da);
                    sb2.Begin(this);

                    fourTemp++;
                }
                fourid = fourid + 1;

                if (fourid == nplayer + 1)
                {
                    fourid = 1;


                }

            }
        }

        private void settings(object sender, RoutedEventArgs e)
        {
            BlurEffect ba = new BlurEffect();
            ba.Radius = 50;

            Everything.Effect = ba;
            overallImg.Effect = ba;

            this.Resources["PlayBtn"] = this.Resources["btn2"];
            this.Resources["PauseBtn"] = this.Resources["btn1"];
            set.Visibility= Visibility.Visible;
        }
        private void setclose(object sender, RoutedEventArgs e)
        {
            set.Visibility = Visibility.Collapsed;

            Everything.Effect = null;
            overallImg.Effect = null;
        }
        private void setplay(object sender, RoutedEventArgs e)
        {
            this.Resources["PlayBtn"] = this.Resources["btn2"];
            this.Resources["PauseBtn"] = this.Resources["btn1"];
           bg.Value.Play();
        }
        private void setpause(object sender, RoutedEventArgs e)
        {
            this.Resources["PlayBtn"] = this.Resources["btn1"];
            this.Resources["PauseBtn"] = this.Resources["btn2"];
            bg.Value.Pause();
        }
        private void setgirl(object sender, RoutedEventArgs e)
        {
            Player1Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\Girl.png"));
        }
        private void setboy(object sender, RoutedEventArgs e)
        {
            Player1Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\Boy.png"));
        }

        private void EffectSound(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double temp = Effects.Value / 10.0;
            sound.Value.Volume = 1.0 - temp;
           
        }

        private void MusicSound(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double temp = Music.Value / 10.0;
            bg.Value.Volume = 1.0 - temp;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //bg.Stop();
            //sound.Stop();
           
            if(checkcls == 0)
          dispose();
            checkcls = 1;
        }

    }
}

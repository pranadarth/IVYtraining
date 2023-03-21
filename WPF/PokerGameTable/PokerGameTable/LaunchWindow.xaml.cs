using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Threading;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace PokerGameTable
{
    /// <summary>
    /// Interaction logic for LaunchWindow.xaml
    /// </summary>
    public partial class LaunchWindow : Window
    {
        public LaunchWindow()
        {
            InitializeComponent();
            initAnimation();   
        }

        ControlWindow cw = new ControlWindow();
        Table tb = new Table();
        Storyboard sb,sb1;
        private void Quit(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
            App.Current.Shutdown();
        }

        public void Play(object sender, RoutedEventArgs e)
        {
           
           
            SystemSounds.Hand.Play();
            this.Close();
            tb.Show();
            tb.startmusic();
            /*cw.Setobj(cw);
            cw.Show();*/
        }

        protected void initAnimation()
        {
            sb = new Storyboard();

            DoubleAnimation db = new DoubleAnimation();
            db.From = 0;
            db.To = 6;
            db.Duration = TimeSpan.FromSeconds(1);
            db.RepeatBehavior = RepeatBehavior.Forever;
            db.AutoReverse= true;

            Storyboard.SetTargetName(db, "QuitTransform");
            Storyboard.SetTargetProperty(db, new PropertyPath(TranslateTransform.YProperty));

            /*DoubleAnimation db1 = new DoubleAnimation();
            db1.From = 0;
            db1.To = 6;
            db1.Duration = TimeSpan.FromMilliseconds(1);
            db1.RepeatBehavior = RepeatBehavior.Forever;
            db1.AutoReverse = true;
            
            

            Storyboard.SetTargetName(db1, "PlayTransform");
            Storyboard.SetTargetProperty(db1, new PropertyPath(TranslateTransform.YProperty));*/

            sb.Children.Add(db);
            sb1 = this.FindResource("playAnime") as Storyboard;
            sb1.Begin(this);
            sb.Begin(this);
          
        }
      
        protected override void OnClosed(EventArgs e)
        {
            sb.Remove();
            sb1.Remove();
        }
    }
}

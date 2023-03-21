using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer Sound1 = new MediaPlayer();
       
        public MainWindow()
        {
            InitializeComponent();
            game.Background = Brushes.LightGreen;

            Sound1.Open(new Uri(@"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\TicTacToe\TicTacToe\Mp3\Song.mp3"));
            Sound1.Play();

        }
        public int turn, p1, p2 = 0;
        private void Logout(object sender, RoutedEventArgs e)
        {
             App.Current.Shutdown();
           // mediaPlayer.Stop();
            //this.Close();

        }

        private void Button(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn % 2 == 0)
            {
                btn.Content = "X";
                Turn.Text = "Turn: Player 2";
                game.Background = Brushes.LightBlue;
            }
            else
            {
                btn.Content = "O";
                Turn.Text = "Turn: Player 1";
                game.Background = Brushes.LightGreen;
            }
            btn.IsEnabled = false;
            turn++;
            check(btn.Content.ToString());

        }

        private void ResetBtn(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            foreach (Button btn in box.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
            Turn.Text = "Turn: Player 1";
            turn = 0;
            game.Background = Brushes.LightGreen;
        }

        private void check(string btnContent)
        {
            if ((Button1.Content == btnContent & Button2.Content == btnContent &
                 Button3.Content == btnContent)
               | (Button1.Content == btnContent & Button4.Content == btnContent &
                 Button7.Content == btnContent)
               | (Button1.Content == btnContent & Button5.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button2.Content == btnContent & Button5.Content == btnContent &
                 Button8.Content == btnContent)
               | (Button3.Content == btnContent & Button6.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button4.Content == btnContent & Button5.Content == btnContent &
                 Button6.Content == btnContent)
               | (Button7.Content == btnContent & Button8.Content == btnContent &
                 Button9.Content == btnContent)
               | (Button3.Content == btnContent & Button5.Content == btnContent &
                 Button7.Content == btnContent))
            {
                if (btnContent == "X")
                {

                    MessageBox.Show("PLAYER 1 WINS");
                    p1++;
                    score1.Text = p1.ToString();
                    Reset();

                }
                else if (btnContent == "O")
                {
                    MessageBox.Show("PLAYER 2 WINS");
                    p2++;
                    score2.Text = p2.ToString();
                    Reset();
                }
                //disablebuttons();
            }

            else
            {
                foreach (Button btn in box.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("GAME OVER NO ONE WINS");
                Reset();
            }
        }
    }

}


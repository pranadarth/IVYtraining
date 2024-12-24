using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Game
{
    public partial class MainWindow : Window
    {
        private enum Direction { Left, Right, Down, Up, None };
        private bool gameOver = false;
        private bool canStop = false;
        private Direction currentDirection = Direction.None;
        private int speed = 1;
        private Thread gameThread;
        private Window currentWindow;

        public MainWindow()
        {
            InitializeComponent();
            currentWindow = Application.Current.MainWindow;
            StartGameThread();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                currentDirection = Direction.Right;
            }
            else if (e.Key == Key.Left)
            {
                currentDirection = Direction.Left;
            }
            else if (e.Key == Key.Down)
            {
                currentDirection = Direction.Down;
            }
            else if (e.Key == Key.Up)
            {
                currentDirection = Direction.Up;
            }
            else if (e.Key == Key.Escape)
            {
                gameOver = true;
            }
            else if (e.Key == Key.Space)
            {
                canStop = !canStop; 
            }
        }

        private void StartGameThread()
        {
            gameThread = new Thread(GameLoop);
            gameThread.IsBackground = true;
            gameThread.Start();
        }

        private void GameLoop()
        {
            while (true)
            {
                if (gameOver)
                {
                    Dispatcher.Invoke(() => ResetGame());
                }

                if (!canStop)
                {
                    Dispatcher.Invoke(() =>  Movement());
                }

                Thread.Sleep(10); // Controls the update rate (20 FPS)
            }
        }

        private void Movement()
        {
            switch (currentDirection)
            {
                case Direction.Left:
                    PlayerMovement.X -= speed;
                    PlayerAngle.Angle = -90;
                    break;
                case Direction.Right:
                    PlayerMovement.X += speed;
                    PlayerAngle.Angle = 90;
                    break;
                case Direction.Up:
                    PlayerMovement.Y -= speed;
                    PlayerAngle.Angle = 0;
                    break;
                case Direction.Down:
                    PlayerMovement.Y += speed;
                    PlayerAngle.Angle = 180;
                    break;
                default:
                    break;
            }


            Check();
        }

        private void Check()
        {
           
            Double checkHeight = Wall.ActualHeight / 2;
            Double checkWidth = Wall.ActualWidth / 2;

            double CurrenXposition = Math.Abs(PlayerMovement.X) + player.Height / 2;
            double CurrenYposition = Math.Abs(PlayerMovement.Y) + player.Height / 2;

            if (checkHeight < CurrenYposition || checkWidth < CurrenXposition)
            {
                MessageBox.Show("GameOver");
                ResetGame();

                //ChangeDIR();
            }
        }

        private void ChangeDIR() 
        {
            switch (currentDirection)
            {
                case Direction.Left:
                    currentDirection = Direction.Right;
                    break;
                case Direction.Right:
                    currentDirection = Direction.Left;
                    break;
                case Direction.Up:
                    currentDirection = Direction.Down;
                    break;
                case Direction.Down:
                    currentDirection = Direction.Up;
                    break;
                default:
                    break;
            }
        }

        private void ResetGame()
        {
            PlayerMovement.X = 0;
            PlayerMovement.Y = 0;
            PlayerAngle.Angle = 0;
            gameOver = false;
            currentDirection = Direction.None;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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
        private List<Rectangle> blocks = new List<Rectangle>();
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            currentWindow = Application.Current.MainWindow;
            StartGameThread();
            GenerateBlocks();
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

        private void GenerateBlocks()
        {
            for (int i = 0; i < 5; i++) // Add 5 blocks
            {
                Rectangle block = new Rectangle
                {
                    Width = 30,
                    Height = 30,
                    Fill = Brushes.Red
                };

                // Randomize position
                double x = random.Next(0, (int)(gameArea.ActualWidth - 30));
                double y = random.Next(0, (int)(gameArea.ActualHeight - 30));

                Canvas.SetLeft(block, x);
                Canvas.SetTop(block, y);

                gameArea.Children.Add(block);
                blocks.Add(block);
            }
        }
    }
}

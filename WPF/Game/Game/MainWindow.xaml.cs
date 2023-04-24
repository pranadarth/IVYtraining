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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Direction { Left, Right, Down, Up, None };
        private bool GameOver = false;
        Direction currentDirection;
        int start = 0;



        public MainWindow()
        {
            InitializeComponent();
            currentDirection= Direction.None;
           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(Key.Right == e.Key) 
            {
               currentDirection= Direction.Right;
            }
            else if(Key.Left == e.Key)
            {
                currentDirection= Direction.Left;
            }
            else if (Key.Down == e.Key)
            {
                currentDirection = Direction.Down;
            }
            else if (Key.Up == e.Key)
            {
                currentDirection = Direction.Up;
            }
            else if(Key.Escape == e.Key)
            {
                GameOver = true;
            }


            movement();

        }

        public  void movement()
        {
            
               
                    switch (currentDirection)
                    {
                        case Direction.Left:
                            PlayerMovement.Y += 1;
                            PlayerAngle.Angle = 90;
                            break;
                        case Direction.Right:
                            PlayerMovement.Y -= 1;
                            PlayerAngle.Angle = 90;
                            break;
                        case Direction.Up:
                            PlayerMovement.Y -= 1;
                            PlayerAngle.Angle = -0;
                            break;
                        case Direction.Down:
                            PlayerMovement.Y += 1;
                            PlayerAngle.Angle = 0;
                            break;
                        default: break;

                    }
              
            if(GameOver)
            {
                return;
            }
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            movement();
        }
    }
}

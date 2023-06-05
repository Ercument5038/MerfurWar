using LibCharacters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;

namespace Projekt_Merfur_War
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();  
        Player player;
        Enemy enemy;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();

            //backgroundSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/bg.jpg"));
        }

        private void StartGame()
        {
            player = new Player(WorldCanvas, CameraCanvas);
            enemy = new Enemy(WorldCanvas, player);

            timer.Interval = TimeSpan.FromSeconds(1/60);
            timer.Tick += Timer_Tick;
            timer.Start();
            //enemy.Update();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            enemy.Update();
            player.Update();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.Left:
            //    case Key.A:
            //        player.MoveLeft();
            //        break;
            //    case Key.Right:
            //    case Key.D: 
            //        player.MoveRight();
            //        break;
            //    case Key.Up:
            //    case Key.W:
            //        player.MoveUp();
            //        break;
            //    case Key.Down:
            //    case Key.S:
            //        player.MoveDown();
            //        break;
            //}

            if (e.Key == Key.A) 
            {
                player.leftPressed = true;
            }
            if (e.Key == Key.D) 
            {
                player.rightPressed = true;
            }
            if (e.Key == Key.W)
            {
                player.upPressed = true;
            }
            if (e.Key == Key.S) 
            {
                player.downPressed = true;
            }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                player.leftPressed = false;
            }
            if (e.Key == Key.D)
            {
                player.rightPressed = false;
            }
            if (e.Key == Key.W)
            {
                player.upPressed = false;
            }
            if (e.Key == Key.S)
            {
                player.downPressed = false;
            }
        }
    }
}

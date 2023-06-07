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
using System.Timers;

namespace Projekt_Merfur_War
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Player player;
        Enemy enemy;

        public MainWindow()
        {
            InitializeComponent();

            StartWindow startWindow = new StartWindow();
            startWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            player = new Player(WorldCanvas, CameraCanvas);
            enemy = new Enemy(WorldCanvas, player);

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1/30);
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            enemy.Update();
            player.Update();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
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

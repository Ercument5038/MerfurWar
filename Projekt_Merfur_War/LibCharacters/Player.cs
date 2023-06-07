using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibCharacters
{
    public class Player
    {
        
        private Canvas gameCanvas;
        private Canvas camCanvas;

        private Vector vector = new Vector();

        private Point position = new Point(-250,-250);

        private double speed = 0.2;

        private int regeneration = 0;

        private int healtPoints = 100;

        private double damageMutliplier = 1;

        private int highscore; // serialize and deserialize

        Rectangle body = new Rectangle();

        public bool rightPressed { get; set; }

        public bool leftPressed { get; set; }

        public bool upPressed { get; set; }

        public bool downPressed { get; set; } 


        public Player(Canvas gameCanvas, Canvas camCanvas)
        { 
            this.gameCanvas = gameCanvas;
            this.camCanvas = camCanvas;
            DrawPlayer(camCanvas);
        }

        private void DrawPlayer(Canvas camCanvas)
        {
            
            body.Width = 40;
            body.Height = 40;
            body.Fill = Brushes.DarkMagenta;           

            Canvas.SetLeft(body, 230);
            Canvas.SetTop(body, 230);

            camCanvas.Children.Add(body);
            //Canvas.SetLeft(playerCanvas,225);
            //Canvas.SetTop(playerCanvas, 225);

            //gameCanvas.Children.Add(playerCanvas);
        }
        
        private void Move(double x, double y)
        {
            position.Offset(x, y);
            /*
            if (position.X < -1750)
                position = new Point(-1750, position.Y);
            if (position.X > background.ActualWidth - 15)
                position = new Point(background.ActualWidth - 15, position.Y);
            if (position.Y < -1750)
                position = new Point(position.X, -1750);
            if (position.Y > background.ActualHeight - 15)
                position = new Point(position.X, background.ActualHeight - 45);
            */
            // keine abgrenzung  also bg left and top kann auﬂerhalb sein
            
            Canvas.SetLeft(gameCanvas, position.X);
            Canvas.SetTop(gameCanvas, position.Y);
        }

        public void MoveLeft()
        {
            Move(speed, 0);
        }

        public void MoveRight()
        {
            Move(-speed, 0);
        }
        
        public void MoveUp() 
        {
            Move(0, speed);
        }

        public void MoveDown()
        {
            Move(0, -speed);
        }

        public Vector GetCenter()
        {
            Vector center = new Vector();
            center.X = position.X + body.Width / 2;
            center.Y = position.Y + body.Height / 2;
            
            return center;
        }

        public void Update()
        {
            if (leftPressed && !rightPressed)
            {
                MoveLeft();
            }
            if (rightPressed && !leftPressed)
            {
                MoveRight();
            }
            if (upPressed && !downPressed)
            {
                MoveUp();
            }
            if (downPressed && !upPressed)
            {
                MoveDown();
            }
        }
    }
}

using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LibCharacters
{
    public class Enemy    
    {
        private Canvas enemyCanvas = new Canvas();

        private Canvas gameCanvas;

        private Point position = new Point();

        private Vector vector = new Vector();

        private double speed = 0.1;

        private int wave;

        Rectangle body = new Rectangle();

        Player player;

        public Enemy(Canvas gameCanvas, Player player)
        {
            this.gameCanvas = gameCanvas;
            this.player = player;
            DrawPlayer(gameCanvas);
        }

        private void DrawPlayer(Canvas gameCanvas)
        {
            body.Width = 30;
            body.Height = 30;
            body.Fill = Brushes.DarkGreen;

            enemyCanvas.Children.Add(body);

            Random random = new Random();

            vector.X = random.NextDouble() * gameCanvas.ActualHeight;
            vector.Y = random.NextDouble() * gameCanvas.ActualHeight;

            Canvas.SetLeft(enemyCanvas, vector.X);
            Canvas.SetTop(enemyCanvas, vector.Y);
            // rnd mit gameCanvas.actualHeight oder Width machen
            gameCanvas.Children.Add(enemyCanvas);
        }

        private void Move(double x, double y)
        {
            
            //position.Offset(x, y);

            // Speed miteinbeziehen in die Bewegung
            vector.X += x * speed;
            vector.Y += y * speed;

            /*
            if (position.X < -250)
                position = new Point(-250, position.Y);
            if (position.X > gameCanvas.ActualWidth)
                position = new Point(gameCanvas.ActualWidth, position.Y);
            if (position.Y < -250)
                position = new Point(position.X, -250);
            if (position.Y > gameCanvas.ActualHeight)
                position = new Point(position.X, gameCanvas.ActualHeight);
            */

            Canvas.SetLeft(enemyCanvas, vector.X);
            Canvas.SetTop(enemyCanvas, vector.Y);
        }

        public void Update()
        {
            Vector Temp = new Vector();

            // Vektor richtig berechnen (Spitze nach Schaft)
            Temp = player.GetCenter() - GetCenter();

            Temp.Normalize();
            
            Move(Temp.X, Temp.Y);
        }

        public Vector GetCenter()
        {
            Vector center = new Vector();
            center.X = vector.X + body.Width / 2;
            center.Y = vector.Y + body.Height / 2;

            return center;
        }
    }
}

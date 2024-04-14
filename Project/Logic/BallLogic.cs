using Model;
using System.Collections.ObjectModel;
using System;
using System.Threading;

namespace Logic
{
    public class BallLogic
    {
        private readonly ObservableCollection<BallModel> _balls;
        private readonly double _maxWidth;
        private readonly double _maxHeight;
        private readonly Random _random;
        private Timer _timer;

        public BallLogic(ObservableCollection<BallModel> balls, double maxWidth, double maxHeight)
        {
            _balls = balls;
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
            _random = new Random();

            GenerateDirection();
            _timer = new Timer(MoveBalls, null, 0, 10);
        }

        private void GenerateDirection()
        {
            foreach (BallModel ball in _balls)
            {
                ball.A = _random.NextDouble() * 2 - 1;
                ball.B = ball.PosY - (ball.A * ball.PosX);
                int rand = _random.Next(0, 2);
                ball.Direction = rand == 0 ? -1 : 1;
            }
        }

        private void MoveBalls(object state)
        {
            
            foreach (BallModel ball in _balls)
            {
                // Oblicz nowe pozycje piłki na podstawie funkcji liniowej
                double newX = ball.PosX + ball.Direction; // Zwiększamy pozycję X o 1 w każdym kroku
                double newY = ball.A * newX + ball.B;

                // Sprawdź, czy nowa pozycja piłki jest w obrębie Border
                if (newX >= 0 && newX <= _maxWidth && newY >= 0 && newY <= _maxHeight)
                {
                    // Jeśli nowa pozycja jest w obrębie Border, ustaw ją jako nową pozycję piłki
                    ball.PosX = newX;
                    ball.PosY = newY;

                }
                else
                {
                    ball.Direction = -ball.Direction;
                }
            }
           
        }
    }
}

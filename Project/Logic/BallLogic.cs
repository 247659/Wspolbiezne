using Model;
using Data;
using System.Collections.ObjectModel;
using System;
using System.Threading;
using System.Collections.Generic;


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
        
        public void StopTimer()
        {
            _timer.Dispose();
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
            
            var ballsCopy = new List<BallModel>(_balls);

            foreach (BallModel ball in ballsCopy)
            {
                double newX = ball.PosX + ball.Direction * 4; // Increment X position by 1 in each step
                double newY = ball.A * newX + ball.B;

                if (newX >= 0 && newX <= _maxWidth && newY >= 0 && newY <= _maxHeight)
                {
                    ball.PosX = newX;
                    ball.PosY = newY;
                }
                else
                {
                    if (newX < 0 || newX > _maxWidth)
                    {
                        ball.Direction = -ball.Direction;
                    }
                    ball.A = -ball.A;
                    ball.B = ball.PosY - (ball.A * ball.PosX);
                }
            }
           
        }
    }
}

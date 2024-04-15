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
        private ObservableCollection<BallData> _balls;
        private ObservableCollection<BallModel> _ballsModel;
        private double _maxWidth;
        private double _maxHeight;
        private readonly Random _random = new Random();
        private Timer _timer;
        private BallModel _model = new BallModel();

        public BallLogic()
        {
            Balls = new ObservableCollection<BallData>();
            _ballsModel = new ObservableCollection<BallModel>();
        }
        
        public void StopTimer()
        {
            _timer.Dispose();
        }

        private void GenerateDirection()
        {
            foreach (BallData ball in _balls)
            {
                ball.A = _random.NextDouble() * 2 - 1;
                ball.B = ball.PosY - (ball.A * ball.PosX);
                int rand = _random.Next(0, 2);
                ball.Direction = rand == 0 ? -1 : 1;
            }
        }

        private void MoveBalls(object state)
        {
            
            var ballsCopy = new List<BallData>(_balls);
            int counter = 0;

            foreach (BallData ball in ballsCopy)
            {
                double newX = ball.PosX + ball.Direction * 4; // Increment X position by 1 in each step
                double newY = ball.A * newX + ball.B;

                if (newX >= 0 && newX <= _maxWidth && newY >= 0 && newY <= _maxHeight)
                {
                    ball.PosX = newX;
                    ball.PosY = newY;
                    Model.UpdateBall(newX, newY, counter);
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

                counter++;
            }
           
        }

        public void CreateBalls(string ballNumber)
        {
            
            if (_timer != null)
            {
                StopTimer();
            }
            
            Balls.Clear();
            Model.Clear();
            
            int numberOfBalls = Convert.ToInt32(ballNumber);
            _maxWidth = 572; // Szerokość Border
            _maxHeight = 272; // Wysokość Border
            for (int i = 0; i < numberOfBalls; i++)
            {
                BallData ball = new BallData();
                ball.PosX = _random.Next(0, (int)(_maxWidth)); // Szerokość piłki musi być uwzględniona
                ball.PosY = _random.Next(0, (int)(_maxHeight)); // Wysokość piłki musi być uwzględniona
                Balls.Add(ball); // Dodaje piłkę do kolekcj
                Model.AddBall(ball.PosX, ball.PosY);
            }
            GenerateDirection();
            _timer = new Timer(MoveBalls, null, 0, 10);
        }
        
        public ObservableCollection<BallData> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
            }
        }
        
        public BallModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }
        
    }
}

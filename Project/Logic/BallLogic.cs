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
        private ObservableCollection<BallData> Balls;
        private ObservableCollection<BallModel> BallsModel;
        private double _maxWidth = 572;
        private double _maxHeight = 272;
        private readonly Random _random = new Random();
        private Timer _timer;
        private BallModel _model = new BallModel();
        private BallData _data = new BallData();
        private int ballsNumber;

        public BallLogic() {}
        
        public void StopTimer()
        {
            _timer.Dispose();
        }

        private void GenerateDirection()
        {
            Balls = Data.Balls;
            BallsModel = Model.Balls;
            int counter = 0;
            foreach (BallData ball in Balls)
            {
                ball.A = _random.NextDouble() * 2 - 1;
                ball.B = BallsModel[counter].PosY - (ball.A * BallsModel[counter].PosX);
                int rand = _random.Next(0, 2);
                ball.Direction = rand == 0 ? -1 : 1;
                counter++;
            }
            Data.Balls = Balls;
        }

        private void MoveBalls(object state)
        {
            
            Balls = Data.Balls;
            BallsModel = Model.Balls;
            int counter = 0;

            foreach (BallData ball in Balls)
            {
                double newX = BallsModel[counter].PosX + ball.Direction * 4; // Increment X position by 1 in each step
                double newY = ball.A * newX + ball.B;

                if (newX >= 0 && newX <= _maxWidth && newY >= 0 && newY <= _maxHeight)
                {
                    BallsModel[counter].PosX = newX;
                    BallsModel[counter].PosY = newY;
                }
                else
                {
                    if (newX < 0 || newX > _maxWidth)
                    {
                        ball.Direction = -ball.Direction;
                    }
                    ball.A = -ball.A;
                    ball.B = BallsModel[counter].PosY - (ball.A * BallsModel[counter].PosX);
                }
                
                counter++;
            }
            Model.Balls = BallsModel;
            Data.Balls = Balls;
        }

        public void CreateBalls(string ballNumber)
        {
            
            if (_timer != null)
            {
                StopTimer();
            }

            Balls = Data.Balls;
            BallsModel = Model.Balls;
            
            Balls.Clear();
            BallsModel.Clear();
            
            ballsNumber = Convert.ToInt32(ballNumber);
            
            for (int i = 0; i < ballsNumber; i++)
            {
                BallModel ball = new BallModel();
                BallData ballData = new BallData();
                ball.PosX = _random.Next(0, (int)(_maxWidth)); // Szerokość piłki musi być uwzględniona
                ball.PosY = _random.Next(0, (int)(_maxHeight)); // Wysokość piłki musi być uwzględniona
                BallsModel.Add(ball);
                Balls.Add(ballData);
            }

            Model.Balls = BallsModel;
            Data.Balls = Balls;
            GenerateDirection();
            _timer = new Timer(MoveBalls, null, 0, 10);
        }
        
        
        public BallModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }
        
        public BallData Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }
        
    }
}

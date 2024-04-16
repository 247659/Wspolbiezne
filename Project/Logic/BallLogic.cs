using Model;
using Data;
using System.Collections.ObjectModel;
using System;
using System.Threading;
using System.Collections.Generic;


namespace Logic
{
    public interface IBallLogic
    {
        public void CreateBalls();
        DataRepo RepoData { get; set; }
        ModelRepo RepoModel { get; set; }
    }

    public class BallLogic : IBallLogic
    {
        private double _maxWidth = 572;
        private double _maxHeight = 272;
        private readonly Random _random = new Random();
        private Timer _timer;
        private ModelRepo _repoModel = new ModelRepo();
        private DataRepo _repoData = new DataRepo();


        private void GenerateDirection()
        {
            int counter = 0;
            foreach (BallData ball in RepoData.Balls)
            {
                ball.A = _random.NextDouble() * 2 - 1;
                ball.B = RepoModel.Balls[counter].PosY - (ball.A * RepoModel.Balls[counter].PosX);
                int rand = _random.Next(0, 2);
                ball.Direction = rand == 0 ? -1 : 1;
                counter++;
            }
        }

        private void MoveBalls(object state)
        {
            int counter = 0;

            var ballsCopy = new List<BallData>(RepoData.Balls);
            var ballsModelCopy = new List<BallModel>(RepoModel.Balls);

            foreach (BallData ball in ballsCopy)
            {
                double newX = ballsModelCopy[counter].PosX + ball.Direction * 4; // Increment X position by 1 in each step
                double newY = ball.A * newX + ball.B;

                if (newX >= 0 && newX <= _maxWidth && newY >= 0 && newY <= _maxHeight)
                {
                    ballsModelCopy[counter].PosX = newX;
                    ballsModelCopy[counter].PosY = newY;
                }
                else
                {
                    if (newX < 0 || newX > _maxWidth)
                    {
                        ball.Direction = -ball.Direction;
                    }
                    ball.A = -ball.A;
                    ball.B = ballsModelCopy[counter].PosY - (ball.A * ballsModelCopy[counter].PosX);
                }
                
                counter++;
            }
        }

        public void CreateBalls()
        {
            
            if (_timer != null)
            {
                _timer.Dispose();
            }

            RepoData.Balls.Clear();
            RepoModel.Balls.Clear();
            
            int ballsNumber = Convert.ToInt32(RepoModel.BallsNumber);
            
            for (int i = 0; i < ballsNumber; i++)
            {
                BallModel ball = new BallModel();
                BallData ballData = new BallData();
                ball.PosX = _random.Next(0, (int)(_maxWidth)); // Szerokość piłki musi być uwzględniona
                ball.PosY = _random.Next(0, (int)(_maxHeight)); // Wysokość piłki musi być uwzględniona
                RepoModel.Balls.Add(ball);
                RepoData.Balls.Add(ballData);
            }

            GenerateDirection();
            _timer = new Timer(MoveBalls, null, 0, 10);
        }
        
        
        public ModelRepo RepoModel
        {
            get { return _repoModel; }
            set
            {
                _repoModel = value;
            }
        }

        public DataRepo RepoData
        {
            get { return _repoData; }
            set
            {
                _repoData = value;
            }
        }

    }
}

using Model;
using Data;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Logic
{
    public interface IBallLogic
    {
        public Task CreateBalls();
        DataRepo RepoData { get; set; }
        ModelRepo RepoModel { get; set; }
    }

    public class BallLogic : IBallLogic
    {
        private double _maxWidth = 582;
        private double _maxHeight = 282;
        private readonly Random _random = new Random();
        private ModelRepo _repoModel = new ModelRepo();
        private DataRepo _repoData = new DataRepo();
        private List<Task> _tasks = new List<Task>();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private string _logFilePath = "..\\..\\..\\..\\log.json";
       
        private void GenerateDirection(object obj1, object obj2)
        {
            BallModel ball = (BallModel)obj1;
            BallData ballData = (BallData)obj2;
            int rand = _random.Next(0, 2);
            int directionHorizontal = rand == 0 ? -1 : 1;
            int directionVertical = rand == 0 ? -1 : 1; 
            ballData.Weight = _random.Next(1, 4);
            ballData.VelocityX = (_random.NextDouble() + 2) * directionHorizontal;
            ballData.VelocityY = (_random.NextDouble() + 2) * directionVertical;
        }
        

        private async Task MoveBall(BallModel ball, BallData ballData, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                double newX, newY;
                
                await Task.Delay(10, cancellationToken);

                lock (RepoData.Balls)
                {
                    lock (RepoModel.Balls)
                    {
                        lock (ballData)
                        {
                            int counter = 0;
                            foreach (var otherBall in RepoData.Balls)
                            {
                                double distance = Math.Sqrt(Math.Pow((RepoModel.Balls[counter].PosX - ball.PosX), 2)
                                                           + Math.Pow((RepoModel.Balls[counter].PosY - ball.PosY), 2));
                                if (distance < 21 && otherBall != ballData)
                                {
                                    double tempX = (ballData.VelocityX * (ballData.Weight - otherBall.Weight)
                                                    + 2 * otherBall.Weight * otherBall.VelocityX) /
                                                   (ballData.Weight + otherBall.Weight);
                                    double tempY = (ballData.VelocityY * (ballData.Weight - otherBall.Weight)
                                                    + 2 * otherBall.Weight * otherBall.VelocityY) /
                                                   (ballData.Weight + otherBall.Weight);

                                    otherBall.VelocityX = (otherBall.VelocityX * (otherBall.Weight - ballData.Weight)
                                                           + 2 * ballData.Weight * ballData.VelocityX) /
                                                          (ballData.Weight + otherBall.Weight);
                                    otherBall.VelocityY = (otherBall.VelocityY * (otherBall.Weight - ballData.Weight)
                                                           + 2 * ballData.Weight * ballData.VelocityY) /
                                                          (ballData.Weight + otherBall.Weight);

                                    ballData.VelocityX = tempX;
                                    ballData.VelocityY = tempY;
                                    if (distance < 20)
                                    {
                                        newX = ball.PosX + ballData.VelocityX * 2;
                                        newY = ball.PosY + ballData.VelocityY * 2;
                                        if (newX >= 10 && newX <= _maxWidth && newY >= 10 && newY <= _maxHeight)
                                        {
                                            ball.PosX = newX;
                                            ball.PosY = newY;
                                        }
                                    }
                                }

                                counter++;

                            }

                            newX = ball.PosX + ballData.VelocityX;
                            newY = ball.PosY + ballData.VelocityY;
                            if (newX >= 10 && newX <= _maxWidth && newY >= 10 && newY <= _maxHeight)
                            {
                                ball.PosX = newX;
                                ball.PosY = newY;
                            }
                            else
                            {
                                ballData.VelocityY = -ballData.VelocityY;
                                if (newX < 10 || newX > _maxWidth)
                                {
                                    ballData.VelocityX = -ballData.VelocityX;
                                    ballData.VelocityY = -ballData.VelocityY;
                                }
                            }
                        }
                    }
                }
            }
        }
           
        public async Task CreateBalls()
        {
            RepoData.Balls.Clear();
            RepoModel.Balls.Clear();
            ClearLog();
            
            _cancellationTokenSource.Cancel();

            int ballsNumber = Convert.ToInt32(RepoModel.BallsNumber);

            _cancellationTokenSource = new CancellationTokenSource();

            _tasks.Clear();

            for (int i = 0; i < ballsNumber; i++)
            {
                BallModel ball = new BallModel();
                BallData ballData = new BallData();
                ball.PosX = _random.Next(10, (int)(_maxWidth));
                ball.PosY = _random.Next(10, (int)(_maxHeight));
                RepoModel.Balls.Add(ball);
                RepoData.Balls.Add(ballData);
                GenerateDirection(ball, ballData);
                Task task = MoveBall(ball, ballData, _cancellationTokenSource.Token);
                _tasks.Add(task);
            }

            Task.Run(async () => await LogBallData(_cancellationTokenSource.Token));
            Console.WriteLine(_tasks.Count);
        }
        
        public void ClearLog()
        {
            try
            {
                File.WriteAllText(_logFilePath, string.Empty);
            }
            catch (Exception ex)
            {
                // Wypisz wyjątek na konsoli
                Console.WriteLine($"An error occurred while clearing the log file: {ex.Message}");
            }
        }
        
        private async Task LogBallData(CancellationToken cancellationToken)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // To enable pretty print with indents and new lines
            };

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    string jsonString;
                    lock (_repoData)
                    {
                        lock (_repoModel)
                        {
                            var logData = new
                            {
                                Timestamp = DateTime.Now,
                                Balls = _repoData.Balls.Select(b => new
                                {
                                    b.VelocityX,
                                    b.VelocityY,
                                    b.Weight

                                }).ToList()
                            };

                            var logModel = new
                            {
                                Balls = _repoModel.Balls.Select(m => new
                                {
                                    m.PosX,
                                    m.PosY
                                }).ToList()
                            };

                            var combinedLogData = new
                            {
                                logData.Timestamp,
                                Balls = logData.Balls.Zip(logModel.Balls, (b, m) => new
                                {
                                    b.VelocityX,
                                    b.VelocityY,
                                    b.Weight,
                                    m.PosX,
                                    m.PosY
                                }).ToList()
                            };

                            jsonString = JsonSerializer.Serialize(combinedLogData, options);

                            // Dodaj nową linię przed zapisaniem nowego wpisu logu
                            jsonString += Environment.NewLine;

                            // Append the JSON string to the log file

                        }
                    }

                    await File.AppendAllTextAsync(_logFilePath, jsonString + Environment.NewLine,
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    // Wypisz wyjątek na konsoli
                    Console.WriteLine($"An error occurred while writing to the log file: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
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

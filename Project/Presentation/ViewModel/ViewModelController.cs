using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class VievModelController : INotifyPropertyChanged
    {
        private string _ballsNumber;
        private ObservableCollection<BallModel> _balls;

        public ICommand CreateBallCommand { get; set; }

        public VievModelController()
        {
            BallsNumber = "0";
            CreateBallCommand = new RelayCommand(CreateBalls);
            Balls = new ObservableCollection<BallModel>();
        }

        private void CreateBalls(object obj)
        {
            Balls.Clear();
            int numberOfBalls = Convert.ToInt32(BallsNumber);
            Random random = new Random();
            double maxWidth = 600; // Szerokość Border
            double maxHeight = 300; // Wysokość Border
            for (int i = 0; i < numberOfBalls; i++)
            {
                BallModel ball = new BallModel();
                ball.PosX = random.Next(0, (int)(maxWidth - 20)); // Szerokość piłki musi być uwzględniona
                ball.PosY = random.Next(0, (int)(maxHeight - 20)); // Wysokość piłki musi być uwzględniona
                Balls.Add(ball); // Dodaje piłkę do kolekcji
            }
          
        }

        public string BallsNumber
        {
            get { return _ballsNumber; }
            set
            {
                _ballsNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BallModel> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

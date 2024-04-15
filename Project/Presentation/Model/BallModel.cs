using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double _posX;
        private double _posY;
        private ObservableCollection<BallModel> _balls = new ObservableCollection<BallModel>();

        public double PosX
        {
            get { return _posX; }
            set
            {
                _posX = value;
                OnPropertyChanged();
            }
        }

        public double PosY
        {
            get { return _posY; }
            set
            {
                _posY = value;
                OnPropertyChanged();
            }
        }

        public void UpdateBall (double x, double y, int i)
        {
            Balls[i].PosX = x; 
            Balls[i].PosY = y;
        }

        public void AddBall(double x, double y)
        {
            BallModel ball = new BallModel();
            ball.PosX = x;
            ball.PosY = y;
            Balls.Add(ball);
            
        }

        public void Clear()
        {
            Balls.Clear();
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

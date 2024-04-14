using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double _posX;
        private double _posY;
        private double _a;
        private double _b;
        private int _direction;

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

        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
            }
        }

        public int Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

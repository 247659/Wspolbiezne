using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double _posX;
        private double _posY;
        private double velocity;

        public double PosX
        {
            get { return PosX; }
            set
            {
                _posX = value;
                OnPropertyChanged();
            }
        }

        public double PosY
        {
            get { return PosY; }
            set
            {
                _posY = value;
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

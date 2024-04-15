using System;
using System.Collections.ObjectModel;

namespace Data
{
    public class BallData
    {
        private double _a;
        private double _b;
        private int _direction;
        private ObservableCollection<BallData> _balls = new ObservableCollection<BallData>();

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
        
        public ObservableCollection<BallData> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;

namespace Data
{
    public interface IBallData
    {
        public double A { get; set; }
        public double B { get; set; }
        public int Direction { get; set; }
    }

    public class BallData : IBallData
    {
        private double _a;
        private double _b;
        private int _direction;

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
    }
}

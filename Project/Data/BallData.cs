using System;

namespace Data
{
    public class BallData
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
            }
        }

        public double PosY
        {
            get { return _posY; }
            set
            {
                _posY = value;
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
    }
}

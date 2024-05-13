using System;
using System.Collections.ObjectModel;

namespace Data
{
    public interface IBallData
    {
        public double A { get; set; }
        public double B { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
    }

    public class BallData : IBallData
    {
        private double _a;
        private double _b;
        private double _weight;
        private double _velocityX;
        private double _velocityY;

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

        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
            }
        }

        public double VelocityX
        {
            get { return _velocityX; }
            set
            {
                _velocityX = value;
            }
        }
        
        public double VelocityY
        {
            get { return _velocityY; }
            set
            {
                _velocityY = value;
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;

namespace Data
{
    public interface IBallData
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Velocity { get; set; }
    }

    public class BallData : IBallData
    {
        private double _a;
        private double _b;
        private double _weight;
        private double _velocity;

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

        public double Velocity
        {
            get { return _velocity; }
            set
            {
                _velocity = value;
            }
        }
    }
}

using System;

namespace Data
{
    public class Ball
    {
        private double posX;
        private double posY;
        private double a;

        public Ball(double x, double y, int direction)
        {
            this.posX = x;
            this.posY = y;
            this.a = y / x * direction; 
        }

        public double PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public double PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }
    }
}

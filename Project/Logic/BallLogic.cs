using Model;

namespace Logic
{
    public class BallLogic
    {
        public void CreateBall(double x, double y)
        {
            var bal = new BallModel() { PosX = x, PosY = x };
        }
    }
}

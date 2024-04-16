using Data;

namespace Testing
{
    public class BallDataTest
    {

        [Test]
        public void GetDataTest()
        {
            IBallData ball = new BallData();
            ball.A = 0.5;
            ball.Direction = 1;
            ball.B = 12;

            Assert.That(ball.A, Is.EqualTo(0.5));
            Assert.That(ball.Direction, Is.EqualTo(1));
            Assert.That(ball.B, Is.EqualTo(12));
        }
    }
}
using Data;
using Logic;

namespace Testing
{
    public class BallLogicTest
    {
        [Test]
        public void CreateLogicTest()
        {
            var ballLogic = new BallLogic();
            Assert.That(ballLogic, Is.Not.Null);
            
        }

        [Test]
        public void CreateBallTest() 
        {
            var ballLogic = new BallLogic();
            Assert.That(ballLogic.Model.Balls.Count, Is.EqualTo(0));
            Assert.That(ballLogic.Data.Balls.Count, Is.EqualTo(0));

            ballLogic.CreateBalls("5");
            Assert.That(ballLogic.Model.Balls.Count, Is.EqualTo(5));
            Assert.That(ballLogic.Data.Balls.Count, Is.EqualTo(5));

        }
    }
}
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
            IBallLogic ballLogic = new BallLogic();
            /*
            Assert.That(ballLogic.Model.BallsModel.Count, Is.EqualTo(0));
            Assert.That(ballLogic.Repo.Balls.Count, Is.EqualTo(0));

            ballLogic.CreateBalls("5");
            Assert.That(ballLogic.Model.BallsModel.Count, Is.EqualTo(5));
            Assert.That(ballLogic.Repo.Balls.Count, Is.EqualTo(5));

            Assert.IsNotNull(ballLogic.Model.BallsModel[0].PosX);
            Assert.IsNotNull(ballLogic.Model.BallsModel[0].PosY);
            */
        }
        
        [Test]
        public void GenerateDirectionTest()
        {
            IBallLogic ballLogic = new BallLogic();
            ballLogic.CreateBalls("2");

            Assert.IsNotNull(ballLogic.Repo.Balls[0].Direction);
            Assert.IsNotNull(ballLogic.Repo.Balls[0].A);
            Assert.IsNotNull(ballLogic.Repo.Balls[0].B);
        }
    }
}
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
            
            Assert.That(ballLogic.RepoData.Balls.Count, Is.EqualTo(0));
            Assert.That(ballLogic.RepoModel.Balls.Count, Is.EqualTo(0));

            ballLogic.RepoModel.BallsNumber = "5";
            ballLogic.CreateBalls();
            Assert.That(ballLogic.RepoModel.Balls.Count, Is.EqualTo(5));
            Assert.That(ballLogic.RepoData.Balls.Count, Is.EqualTo(5));

            Assert.IsNotNull(ballLogic.RepoModel.Balls[0].PosX);
            Assert.IsNotNull(ballLogic.RepoModel.Balls[0].PosY);
            
        }
        
        [Test]
        public void CreateNewBallsTest()
        {
            IBallLogic ballLogic = new BallLogic();
            ballLogic.RepoModel.BallsNumber = "5";
            ballLogic.CreateBalls();

            ballLogic.RepoModel.BallsNumber = "3";
            ballLogic.CreateBalls();
            Assert.That(ballLogic.RepoModel.Balls.Count, Is.EqualTo(3));
            Assert.That(ballLogic.RepoData.Balls.Count, Is.EqualTo(3));
        }

        [Test]
        public void DirectionBallsTest() 
        {
            IBallLogic ballLogic = new BallLogic();
            ballLogic.RepoModel.BallsNumber = "5";
            ballLogic.CreateBalls();
            Assert.IsNotNull(ballLogic.RepoData.Balls[0].B);
            Assert.IsNotNull(ballLogic.RepoData.Balls[0].A);
            Assert.IsNotNull(ballLogic.RepoData.Balls[0].Direction);
        }

        [Test]
        public void ChangeDirectionAtDimensionXTest()
        {
            IBallLogic ballLogic = new BallLogic();
            ballLogic.RepoModel.BallsNumber = "5";
            ballLogic.CreateBalls();
            ballLogic.RepoData.Balls[0].Direction = 1;
            ballLogic.RepoData.Balls[0].A = 0.5;
            ballLogic.RepoModel.Balls[0].PosX = 574;
            Thread.Sleep(10);
            Assert.That(ballLogic.RepoData.Balls[0].Direction, Is.EqualTo(-1));
            Assert.That(ballLogic.RepoData.Balls[0].A, Is.EqualTo(-0.5));
        }

        [Test]
        public void ChangeDirectionAtDimensionYTest()
        {
            IBallLogic ballLogic = new BallLogic();
            ballLogic.RepoModel.BallsNumber = "5";
            ballLogic.CreateBalls();
            ballLogic.RepoData.Balls[0].Direction = 1;
            ballLogic.RepoData.Balls[0].A = 0.5;
            ballLogic.RepoModel.Balls[0].PosY = 274;
            Thread.Sleep(10);
            Assert.That(ballLogic.RepoData.Balls[0].Direction, Is.EqualTo(1));
            Assert.That(ballLogic.RepoData.Balls[0].A, Is.EqualTo(-0.5));
        }
    }
}
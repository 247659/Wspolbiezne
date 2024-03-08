using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int a = 2;
            int b = 3;
            int result = Program.func(a, b);

            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void Test2()
        {
            int result = 3;
            Assert.AreEqual(3, result);
        }
    }
}
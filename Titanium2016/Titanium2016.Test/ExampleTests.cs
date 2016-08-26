using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class ExampleTests
    {
        private readonly Solution _solution = new Solution();

        private string _s;

        private int _k;

        [Test]
        public void Test1()
        {
            _s = ")()()(";
            _k = 3;

            var actual = _solution.Solve(_s, _k);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            _s = ")))(((";
            _k = 2;

            var actual = _solution.Solve(_s, _k);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            _s = ")))(((";
            _k = 0;

            var actual = _solution.Solve(_s, _k);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
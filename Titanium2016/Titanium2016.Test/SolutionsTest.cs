using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class SolutionsTest
    {
        private readonly Solution _solution = new Solution();

        private string _s;

        private int _k;

        [Test]
        public void Single()
        {
            _s = ")";
            _k = 1;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleValid()
        {
            _s = "()";
            _k = 0;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_OneTurn()
        {
            _s = "((";
            _k = 1;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_TwoTurns()
        {
            _s = "((";
            _k = 2;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_NoTurns()
        {
            _s = "((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }
    }
}
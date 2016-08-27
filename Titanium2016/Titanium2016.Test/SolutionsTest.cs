using System.Linq;
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

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

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
        public void DoubleDoubleValid()
        {
            _s = "(())";
            _k = 0;

            var expected = 4;
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

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

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

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

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

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reflect_NoTurns()
        {
            _s = ")(";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reflect_OneTurn()
        {
            _s = ")(";
            _k = 1;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reflect_TwoTurns()
        {
            _s = ")(";
            _k = 2;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4_Opposite()
        {
            _s = "))))()()";
            _k = 1;

            var expected = 6;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOptimize_OneTurn()
        {
            _s = "(((((";
            _k = 1;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOptimize_TwoTurns()
        {
            _s = "(((((";
            _k = 2;

            var expected = 4;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Premature()
        {
            _s = "(()(()()()(()(()()(()()()(()()";
            _k = 2;

            var expected = 26;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Chain()
        {
            _s = "()()(())()()";
            _k = 2;

            var expected = 12;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random()
        {
            _s = "(()))(((()))(((()()))(";
            _k = 0;

            var expected = 8;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 1;

            expected = 16;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 2;

            expected = 16;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 3;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOnly_Even()
        {
            _s = "((((((((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOnly_Odd()
        {
            _s = "(((((((((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOnly_Even()
        {
            _s = "))))))))";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOnly_Odd()
        {
            _s = ")))))))))";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdjacentSlices()
        {
            _s = "(()())())))(((";
            _k = 0;

            var expected = 8;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }
    }
}
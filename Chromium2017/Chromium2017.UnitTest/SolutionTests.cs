using NUnit.Framework;

namespace Chromium2017.UnitTest
{
    [TestFixture]
    internal class SolutionTests
    {
        private Solution SolutionFactory()
        {
            return new Solution();
        }

        [Test]
        public void Single()
        {
            var solution = SolutionFactory();

            var input = new[] { 0 };

            var actual = solution.Solve(input);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        [TestCase(new[] { 2, 1 }, 3)]
        [TestCase(new[] { 3, 2, 1 }, 6, TestName = "LeftHigher 3.0")]
        [TestCase(new[] { 3, 1, 2 }, 7, TestName = "LeftHigher 3.1")]
        public void LeftHigher(int[] input, int expected)
        {
            var solution = SolutionFactory();

            var actual = solution.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new[] { 1, 2 }, 3)]
        [TestCase(new[] { 1, 2, 3 }, 6, TestName = "RightHigher 3.0")]
        [TestCase(new[] { 2, 1, 3 }, 7, TestName = "RightHigher 3.1")]
        public void RightHigher(int[] input, int expected)
        {
            var solution = SolutionFactory();

            var actual = solution.Solve(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
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
        [TestCase(new[] { 3, 2, 1 }, 7)]
        [TestCase(new[] { 3, 1, 2 }, 7)]
        public void LeftHigher(int[] input, int expected)
        {
            var solution = SolutionFactory();

            var actual = solution.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new[] { 1, 2 }, 3)]
        [TestCase(new[] { 1, 2, 3 }, 7)]
        [TestCase(new[] { 2, 1, 3 }, 7)]
        public void RightHigher(int[] input, int expected)
        {
            var solution = SolutionFactory();

            var actual = solution.Solve(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
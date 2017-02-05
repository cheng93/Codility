using NUnit.Framework;

namespace Chromium2017.UnitTest
{
    [TestFixture]
    public class CodilityTests
    {
        private Solution SolutionFactory()
        {
            return new Solution();
        }

        [Test]
        public void Example1()
        {
            var solution = SolutionFactory();

            var input = new[] {13, 2, 5};

            var actual = solution.Solve(input);
            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Example2()
        {
            var solution = SolutionFactory();

            var input = new[] {4, 6, 2, 1, 5};

            var actual = solution.Solve(input);
            var expected = 23;

            Assert.AreEqual(expected, actual);
        }
    }
}
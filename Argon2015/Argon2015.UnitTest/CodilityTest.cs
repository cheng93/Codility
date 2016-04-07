using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argon2015.UnitTest
{
    [TestClass]
    public class CodilityTest
    {
        private readonly Solution _solution = new Solution();

        [TestMethod]
        public void Example1()
        {
            var a = new[] {1, 1, 0, 1, 0, 0, 1, 1};

            var actual = _solution.Solve(a);
            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var a = new[] { 1, 0 };

            var actual = _solution.Solve(a);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
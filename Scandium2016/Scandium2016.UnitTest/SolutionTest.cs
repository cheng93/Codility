using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scandium2016.UnitTest
{
    [TestClass]
    public class SolutionTest
    {
        private readonly Solution _solution = Solution.Create();
        
        [TestMethod]
        public void Single_Odd()
        {
            var a = new[] { 1 };

            var actual = _solution.Solve(a);
            var expected = "NO SOLUTION";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Single_Even()
        {
            var a = new[] { 2 };

            var actual = _solution.Solve(a);
            var expected = "0,0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Edge()
        {
            var a = new[] { 2, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Edge_Reverse()
        {
            var a = new[] { 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "1,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EarlySlice()
        {
            var a = new[] { 1, 1, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EarlySlice_2()
        {
            var a = new[] { 1, 1, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SmallestAndEarliestSlice()
        {
            var a = new[] { 2, 1, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,2";

            Assert.AreEqual(expected, actual);
        }
    }
}

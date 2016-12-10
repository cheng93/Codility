using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scandium2016.UnitTest
{
    [TestClass]
    public class CodilityTest
    {
        private readonly Solution _solution = Solution.Create();

        [TestMethod]
        public void Example1()
        {
            var a = new[] { 4, 5, 3, 7, 2 };

            var actual = _solution.Solve(a);
            var expected = "1,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var a = new[] { 2, 5, 4 };

            var actual = _solution.Solve(a);
            var expected = "NO SOLUTION";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half1_1()
        {
            var a = new[] { 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "1,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half1_2()
        {
            var a = new[] { 2, 1, 2, 2 };

            var actual = _solution.Solve(a);
            var expected = "2,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half1_3()
        {
            var a = new[] { 2, 1, 2, 2, 2, 2 };

            var actual = _solution.Solve(a);
            var expected = "2,4";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half2_1()
        {
            var a = new[] { 2, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half2_2()
        {
            var a = new[] { 2, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,0";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void one_odd_half2_3()
        {
            var a = new[] { 2, 2, 2, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_1()
        {
            var a = new[] {1, 1, 1};

            var actual = _solution.Solve(a);
            var expected = "0,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_2()
        {
            var a = new[] { 1, 1, 2, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_3()
        {
            var a = new[] { 2, 1, 1, 2, 1 };

            var actual = _solution.Solve(a);
            var expected = "0,3";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_4()
        {
            var a = new[] { 1, 1, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_5()
        {
            var a = new[] { 2, 1, 1, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_6()
        {
            var a = new[] { 1, 2, 1, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,2";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void three_odd_case1_7()
        {
            var a = new[] { 2, 1, 2, 1, 2, 1, 2 };

            var actual = _solution.Solve(a);
            var expected = "0,3";

            Assert.AreEqual(expected, actual);
        }
    }
}
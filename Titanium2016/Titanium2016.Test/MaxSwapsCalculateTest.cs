using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class MaxSwapsCalculateTest
    {
        [Test]
        public void BothEmpty()
        {
            var open = new int[] { };
            var closed = new int[] { };

            var expected = 0;
            var actual = MaxSwaps.Calculate(2, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenSingle_Start()
        {
            var open = new int[] { 0 };
            var closed = new int[] { };

            var expected = 0;
            var actual = MaxSwaps.Calculate(3, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenSingle_End()
        {
            var open = new int[] { 2 };
            var closed = new int[] { };

            var expected = 0;
            var actual = MaxSwaps.Calculate(3, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenSingle_Middle()
        {
            var open = new int[] { 2 };
            var closed = new int[] { };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOdd_NoneAtEnd()
        {
            var open = new int[] { 2, 3, 4 };
            var closed = new int[] { };

            var expected = 2;
            var actual = MaxSwaps.Calculate(7, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOdd_OneAtEnd()
        {
            var open = new int[] { 2, 3, 4 };
            var closed = new int[] { };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOdd_BothSides()
        {
            var open = new int[] { 0, 3, 4 };
            var closed = new int[] { };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenEven()
        {
            var open = new int[] { 2, 3 };
            var closed = new int[] { };

            var expected = 1;
            var actual = MaxSwaps.Calculate(6, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedSingle_Start()
        {
            var open = new int[] { };
            var closed = new int[] { 0 };

            var expected = 0;
            var actual = MaxSwaps.Calculate(3, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedSingle_End()
        {
            var open = new int[] { };
            var closed = new int[] { 2 };

            var expected = 0;
            var actual = MaxSwaps.Calculate(3, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedSingle_Middle()
        {
            var open = new int[] { };
            var closed = new int[] { 2 };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOdd_NoneAtEnd()
        {
            var open = new int[] { };
            var closed = new int[] { 2, 3, 4 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(7, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOdd_OneAtEnd()
        {
            var open = new int[] { };
            var closed = new int[] { 2, 3, 4 };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOdd_BothSides()
        {
            var open = new int[] { };
            var closed = new int[] { 0, 3, 4 };

            var expected = 1;
            var actual = MaxSwaps.Calculate(5, open, closed);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ClosedEven()
        {
            var open = new int[] { };
            var closed = new int[] { 2, 3 };

            var expected = 1;
            var actual = MaxSwaps.Calculate(6, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenClosed_BothEven()
        {
            var open = new int[] { 4, 5 };
            var closed = new int[] { 2, 3 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(8, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenClosed_BothOdd()
        {
            var open = new int[] { 5, 6, 7 };
            var closed = new int[] { 2, 3, 4 };

            var expected = 4;
            var actual = MaxSwaps.Calculate(10, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OddTotal_MoreOpen_NotAtEnd()
        {
            var open = new int[] { 4, 5, 6 };
            var closed = new int[] { 2, 3 };

            var expected = 3;
            var actual = MaxSwaps.Calculate(9, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OddTotal_MoreOpen_OneAtEnd()
        {
            var open = new int[] { 4, 5, 6 };
            var closed = new int[] { 2, 3 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(7, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OddTotal_MoreClosed_NoneAtEnd()
        {
            var open = new int[] { 5, 6 };
            var closed = new int[] { 2, 3, 4 };

            var expected = 3;
            var actual = MaxSwaps.Calculate(9, open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OddTotal_MoreClosed_OneAtEnd()
        {
            var open = new int[] { 5, 6 };
            var closed = new int[] { 0, 3, 4 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(9, open, closed);

            Assert.AreEqual(expected, actual);
        }
    }
}
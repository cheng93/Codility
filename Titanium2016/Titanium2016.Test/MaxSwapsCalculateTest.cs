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
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenOdd()
        {
            var open = new int[] { 2 };
            var closed = new int[] { };

            var expected = 0;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenEven()
        {
            var open = new int[] { 2, 15 };
            var closed = new int[] { };

            var expected = 1;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedOdd()
        {
            var open = new int[] { };
            var closed = new int[] { 3 };

            var expected = 0;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClosedEven()
        {
            var open = new int[] { };
            var closed = new int[] { 2, 8 };

            var expected = 1;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenClosed_BothEven()
        {
            var open = new int[] { 2, 15 };
            var closed = new int[] { 3, 9 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenClosed_BothOdd()
        {
            var open = new int[] { 2, 15, 27 };
            var closed = new int[] { 3, 9, 11 };

            var expected = 4;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OddTotal()
        {
            var open = new int[] { 2, 15, 27 };
            var closed = new int[] { 3, 9 };

            var expected = 2;
            var actual = MaxSwaps.Calculate(open, closed);

            Assert.AreEqual(expected, actual);
        }
    }
}
using System.Collections.Generic;
using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class OutputCalculateTests
    {
        private int _length;

        private IList<int> _openBrackets = new List<int>();

        private IList<int> _closedBrackets = new List<int>();

        [SetUp]
        public void SetUp()
        {
            _length = 6;
            _openBrackets = new List<int>();
            _closedBrackets = new List<int>();
        }

        [Test]
        public void BothEmpty()
        {
            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = _length;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOpen_Start()
        {
            _openBrackets.Add(0);
            _length = 7;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOpen_End()
        {
            _openBrackets.Add(6);
            _length = 7;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoOpen_Short()
        {
            _openBrackets.Add(0);
            _openBrackets.Add(3);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoOpen_Middle()
        {
            _openBrackets.Add(0);
            _openBrackets.Add(5);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoOpen_Long()
        {
            _openBrackets.Add(0);
            _openBrackets.Add(7);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleClosed_Start()
        {
            _closedBrackets.Add(0);
            _length = 7;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleClosed_End()
        {
            _closedBrackets.Add(6);
            _length = 7;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoClosed_Short()
        {
            _closedBrackets.Add(0);
            _closedBrackets.Add(3);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoClosed_Middle()
        {
            _closedBrackets.Add(0);
            _closedBrackets.Add(5);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TwoClosed_Long()
        {
            _closedBrackets.Add(0);
            _closedBrackets.Add(7);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleReflective_Edge()
        {
            _closedBrackets.Add(0);
            _openBrackets.Add(7);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleReflective_Middle()
        {
            _closedBrackets.Add(4);
            _openBrackets.Add(5);
            _length = 10;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleReflective_Inside()
        {
            _closedBrackets.Add(2);
            _openBrackets.Add(5);
            _length = 8;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Open_SameLength()
        {
            _openBrackets.Add(0);
            _openBrackets.Add(1);
            _length = 2;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Closed_SameLength()
        {
            _closedBrackets.Add(0);
            _closedBrackets.Add(1);
            _length = 2;

            var actual = Output.Calculate(_length, _openBrackets, _closedBrackets);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scandium2016.UnitTest
{
    [TestClass]
    public class EndNodesWinnableTest
    {
        private readonly IOddNodesWinnable _oddNodesWinnable = new OddNodesWinnable();

        [TestMethod]
        public void Single()
        {
            var node = 0;
            var oddNodes = new List<int>
            {
                0
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 1);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Start()
        {
            var node = 0;
            var oddNodes = new List<int>
            {
                0
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 2);
            var expected = new Slice(1, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void End()
        {
            var node = 1;
            var oddNodes = new List<int>
            {
                1
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 2);
            var expected = new Slice(0, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Start_MultipleOddNodes()
        {
            var node = 0;
            var oddNodes = new List<int>
            {
                0, 2, 3
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 4);
            var expected = new Slice(1, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void End_MultipleOddNodes()
        {
            var node = 3;
            var oddNodes = new List<int>
            {
                0, 2, 3
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 4);
            var expected = new Slice(0, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}

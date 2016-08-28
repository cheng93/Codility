using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scandium2016.UnitTest
{
    [TestClass]
    public class FirstNodesWinnableTest
    {
        private readonly IOddNodesWinnable _oddNodesWinnable = new OddNodesWinnable();

        [TestMethod]
        public void NoEvensAfterNode()
        {
            var node = 1;
            var oddNodes = new List<int>
            {
                1,2,3
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 1);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void EvensAfterNode_BeforeFirstOdd()
        {
            var node = 1;
            var oddNodes = new List<int>
            {
                1,3,4
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 5);
            var expected = new Slice(3, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvensAfterNode_AfterFirstOdd()
        {
            var node = 1;
            var oddNodes = new List<int>
            {
                1,2,3
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 5);
            var expected = new Slice(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvensAfterNode_Mixed()
        {
            var node = 1;
            var oddNodes = new List<int>
            {
                1,2,3
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 6);
            var expected = new Slice(2, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EvensAfterNode_MultipleOnLeftSide_BeforeFirstOdd()
        {
            var node = 2;
            var oddNodes = new List<int>
            {
                2,4,5
            };

            var actual = _oddNodesWinnable.Get(node, oddNodes, 7);
            var expected = new Slice(4,2);

            Assert.AreEqual(expected, actual);
        }
    }
}

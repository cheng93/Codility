using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scandium2016.UnitTest
{
    [TestClass]
    public class OddNodesGrabberTest
    {
        private readonly IOddNodesGrabber _oddNodesGrabber = new OddNodesGrabber();

        [TestMethod]
        public void NoElements()
        {
            var nodes = new int[] {};

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> {};

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Null()
        {
            int[] nodes = null;

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> { };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Single_Odd()
        {
            var nodes = new [] {1};

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> {0};

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Single_Even()
        {
            var nodes = new[] {2};

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> { };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Multiple_Odds()
        {
            var nodes = new[] {1, 3};

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> {0, 1};

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Multiple_Mixed()
        {
            var nodes = new[] {1, 2, 3};

            var actual = _oddNodesGrabber.Grab(nodes);
            var expected = new List<int> {0, 2};

            CollectionAssert.AreEqual(expected, actual.ToList());
        }
    }
}

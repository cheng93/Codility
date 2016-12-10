using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class BracketCollectionsCreateTest
    {
        [Test]
        public void EmptyString()
        {
            var str = "";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { };
            var closedBrackets = new int[] { };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void OpenBracket()
        {
            var str = "(";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { 0 };
            var closedBrackets = new int[] { };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void ClosedBracket()
        {
            var str = ")";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { };
            var closedBrackets = new int[] { 0 };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void Pair()
        {
            var str = "()";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { };
            var closedBrackets = new int[] { };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void OpenBracketBeforePair()
        {
            var str = "(()";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { 0 };
            var closedBrackets = new int[] { };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void OpenBracketAfterPair()
        {
            var str = "()(";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { 2 };
            var closedBrackets = new int[] { };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void ClosedBracketBeforePair()
        {
            var str = ")()";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { };
            var closedBrackets = new int[] { 0 };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void ClosedBracketAfterPair()
        {
            var str = "())";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { };
            var closedBrackets = new int[] { 2 };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }

        [Test]
        public void BadPair()
        {
            var str = ")(";

            var bracketCollections = BracketCollections.Create(str);

            var openBrackets = new int[] { 1 };
            var closedBrackets = new int[] { 0 };

            CollectionAssert.AreEqual(openBrackets, bracketCollections.OpenBrackets);
            CollectionAssert.AreEqual(closedBrackets, bracketCollections.ClosedBrackets);
        }
    }
}
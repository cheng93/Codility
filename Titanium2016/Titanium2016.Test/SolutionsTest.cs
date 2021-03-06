﻿using NUnit.Framework;

namespace Titanium2016.Test
{
    [TestFixture]
    public class SolutionsTest
    {
        private readonly Solution _solution = new Solution();

        private string _s;

        private int _k;

        [Test]
        public void Single()
        {
            _s = ")";
            _k = 1;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleValid()
        {
            _s = "()";
            _k = 0;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleDoubleValid()
        {
            _s = "(())";
            _k = 0;

            var expected = 4;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_OneTurn()
        {
            _s = "((";
            _k = 1;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_TwoTurns()
        {
            _s = "((";
            _k = 2;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DoubleInvalid_NoTurns()
        {
            _s = "((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reflect()
        {
            _s = ")(";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 0;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reflect_Uneven()
        {
            _s = "()())()(()()()";
            _k = 0;

            var expected = 6;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4_Opposite()
        {
            _s = "))))()()";
            _k = 1;

            var expected = 6;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOptimize_OneTurn()
        {
            _s = "(((((";
            _k = 1;

            var expected = 2;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOptimize_TwoTurns()
        {
            _s = "(((((";
            _k = 2;

            var expected = 4;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Premature()
        {
            _s = "(()(()()()(()(()()(()()()(()()";
            _k = 2;

            var expected = 26;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Chain()
        {
            _s = "()()(())()()";

            _k = 1;

            var expected = 12;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random()
        {
            _s = "(()))(((()))(((()()))(";
            _k = 0;

            var expected = 8;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 1;

            expected = 16;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 2;

            expected = 20;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 3;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 1;

            expected = 16;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 2;

            expected = 20;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
            _k = 3;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleBracketOnly_Even()
        {
            _s = "((((((((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 0;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleBracketOnly_Odd()
        {
            _s = "(((((((((";
            _k = 0;

            var expected = 0;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 0;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 2;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdjacentSlices()
        {
            _s = "(()())())))(((";
            _k = 0;

            var expected = 8;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sneaky()
        {
            _s = "(()))(()())()";
            _k = 0;

            var expected = 8;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneTypeRotation()
        {
            _s = "()()(()()((()()()((((()(()()()()()";

            _k = 0;

            var expected = 10;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 18;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 24;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            _k = 0;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 18;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 24;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 5;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneTypeRotation_LargeMiddle()
        {
            _s = "()()(()()(((()()()()()(()(((()()()";
            _k = 0;

            var expected = 10;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 26;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 26;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LargeEnd()
        {
            _s = ")))()(()(())";

            _k = 0;

            var expected = 6;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);

            _k = 0;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 12;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random2()
        {
            _s = ")()()((()())())(()()((()))()()()(()(((";
            _k = 0;

            var expected = 16;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 36;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 36;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 38;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 16;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 34;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 36;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 36;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 38;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random3()
        {
            _s = "()()()()))(((()()(())()()()(())((";
            _k = 0;

            var expected = 18;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 20;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 32;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 32;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 18;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 20;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 32;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 32;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random4()
        {
            _s = ")))()(())(()()()()()(()()(()()";
            _k = 0;

            var expected = 10;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 26;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 28;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 10;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 22;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 26;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 28;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sandwich()
        {
            _s = "())()()";
            _k = 0;

            var expected = 4;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected,actual);

            _k = 1;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Random5()
        {
            _s = "()()()()((())))((()()()()(()()";
            _k = 0;

            var expected = 14;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 24;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 30;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 30;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 14;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 24;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 3;

            expected = 30;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 4;

            expected = 30;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }

        public void Hmmm()
        {
            _s = ")()()(()";
            _k = 0;

            var expected = 4;
            var actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _s = Helpers.Reflect(_s);
            _k = 0;

            expected = 4;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 1;

            expected = 6;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);

            _k = 2;

            expected = 8;
            actual = _solution.Solve(_s, _k);

            Assert.AreEqual(expected, actual);
        }
    }
}
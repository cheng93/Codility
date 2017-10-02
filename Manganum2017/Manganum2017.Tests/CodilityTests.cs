namespace Manganum2017.Tests
{
    using Manganum2017;
    using System;
    using Xunit;
    using System.Collections.Generic;

    public class CodilityTests
    {
        private Solution solution = new Solution();

        private static IEnumerable<object[]> TestCases()
        {
            yield return new object[]
            {
                new [] { 3, 5, 1, 6 },
                new [] { 1, 3, 3, 8 },
                "Xpqp",
                10
            };
            yield return new object[]
            {
                new [] { 0, 3, 5, 1, 6 },
                new [] { 4, 1, 3, 3, 8 },
                "pXpqp",
                2
            };
            yield return new object[]
            {
                new [] { 0, 6, 2, 5, 3, 0 },
                new [] { 4, 8, 2, 3, 1, 6 },
                "ppqpXp",
                12
            };
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Example1(int[] x, int[] y, string t, int expected)
        {
            var actual = solution.solution(x, y, t);

            Assert.Equal(actual, expected);
        }
    }
}

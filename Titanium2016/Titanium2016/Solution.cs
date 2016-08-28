using System;

namespace Titanium2016
{
    public class Solution
    {
        public int Solve(string s, int k)
        {
            if (s == ")" || s == "(")
            {
                return 0;
            }

            // O(N)
            var bracketCollections = BracketCollections.Create(s);

            var maxSwaps = MaxSwaps.Calculate(s.Length, bracketCollections.OpenBrackets,
                bracketCollections.ClosedBrackets);

            var swaps = Math.Min(k, maxSwaps);

            return AnotherSolver.Solve(s, maxSwaps, bracketCollections);
        }
    }
}
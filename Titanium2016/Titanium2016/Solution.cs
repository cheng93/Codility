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

            // O(1)
            var maxSwaps = MaxSwaps.Calculate(s.Length, bracketCollections.OpenBrackets,
                bracketCollections.ClosedBrackets);

            if (k >= maxSwaps)
            {
                return s.Length - (s.Length % 2 == 0 ? 0 : 1);
            }

            return Solver.Solve(s, k, bracketCollections);
        }
    }
}
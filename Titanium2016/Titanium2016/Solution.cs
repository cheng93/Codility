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

            return AnotherSolver.Solve(s, k, bracketCollections);
        }
    }
}
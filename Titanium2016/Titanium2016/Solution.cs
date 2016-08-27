using System;
using System.Linq;

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

            // O(1) due to ICollection implementation.
            var maxSwaps = MaxSwaps.Calculate(
                bracketCollections.OpenBrackets,
                bracketCollections.ClosedBrackets);

            var limit = Math.Min(k, maxSwaps);

            var output = Output.Calculate(s.Length, bracketCollections.OpenBrackets, bracketCollections.ClosedBrackets);

            if (output == s.Length)
                return output;

            for (var i = 0; i < limit; i++)
            {
                var openCount = bracketCollections.OpenBrackets.Count;
                var closedCount = bracketCollections.ClosedBrackets.Count;

                bool? removeOpen = null;
                var indexToRemove = new int[2];

                var possibleOutput = output;

                if (closedCount > 1)
                {
                    for (var x = closedCount - 2; x >= 0; x--)
                    {
                        var closed = bracketCollections.ClosedBrackets.ToList();
                        closed.RemoveAt(x + 1);
                        closed.RemoveAt(x);

                        var calc = Output.Calculate(s.Length, bracketCollections.OpenBrackets, closed);

                        if (calc > possibleOutput)
                        {
                            removeOpen = false;
                            indexToRemove = new[] { x, x + 1 };
                            possibleOutput = calc;
                        }
                    }
                }
                if (openCount > 1)
                {
                    for (var x = 1; x < openCount; x++)
                    {
                        var open = bracketCollections.OpenBrackets.ToList();
                        open.RemoveAt(x);
                        open.RemoveAt(x - 1);

                        var calc = Output.Calculate(s.Length, open, bracketCollections.ClosedBrackets);

                        if (calc > possibleOutput)
                        {
                            removeOpen = true;
                            indexToRemove = new[] { x - 1, x };
                            possibleOutput = calc;
                        }
                    }
                }

                if (removeOpen.HasValue)
                {
                    if (removeOpen.Value)
                    {
                        bracketCollections.OpenBrackets.RemoveAt(indexToRemove[1]);
                        bracketCollections.OpenBrackets.RemoveAt(indexToRemove[0]);
                    }
                    else
                    {
                        bracketCollections.ClosedBrackets.RemoveAt(indexToRemove[1]);
                        bracketCollections.ClosedBrackets.RemoveAt(indexToRemove[0]);
                    }
                }
                else
                {
                    if ((closedCount == 1 && openCount >= 1) 
                        || (openCount == 1 && closedCount >= 1))
                    {
                        bracketCollections.ClosedBrackets.Add(bracketCollections.OpenBrackets[0]);
                        bracketCollections.OpenBrackets.RemoveAt(0);
                    }
                }

                output = Output.Calculate(s.Length, bracketCollections.OpenBrackets, bracketCollections.ClosedBrackets);
            }

            return output;
        }
    }
}
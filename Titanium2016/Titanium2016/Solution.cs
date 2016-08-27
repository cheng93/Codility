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

            if (!bracketCollections.OpenBrackets.Any() && !bracketCollections.ClosedBrackets.Any())
            {
                return s.Length;
            }

            var output = 0;

            var joined = bracketCollections.ClosedBrackets.ToList();
            joined.AddRange(bracketCollections.OpenBrackets);

            for (var j = 0; j < joined.Count; j++)
            {
                var current = joined[j];
                if (j == 0)
                {
                    output = current;
                }
                else
                {
                    var prev = joined[j - 1];

                    output = Math.Max(output, current - prev - 1);
                }
            }

            if (joined.Any())
            {
                output = Math.Max(output, s.Length - joined[joined.Count - 1] - 1);
            }

            for (var i = 0; i < limit; i++)
            {
                var openCount = bracketCollections.OpenBrackets.Count;
                var closedCount = bracketCollections.ClosedBrackets.Count;

                if (openCount == closedCount && openCount == 1)
                {
                    if (i == maxSwaps - 2 && i == limit - 1)
                    {
                        return output;
                    }
                    if (i == maxSwaps - 2 && i == limit -2)
                    {
                        return s.Length;
                    }
                }

                var bracketsToRemove = new int[2];
                var open = false;
                var biggestDif = -1;

                for (var x = 1; x < openCount; x++)
                {
                    var current = bracketCollections.OpenBrackets[x];
                    var prev = bracketCollections.OpenBrackets[x - 1];
                    int dif;
                    if (x == openCount - 1)
                    {
                        dif = current - prev - 1;
                        if (openCount > 2)
                        {
                            var prevprev = bracketCollections.OpenBrackets[x - 2];
                            dif = dif + prev - prevprev - 1;
                        }
                        if (current != s.Length - 1)
                        {
                            dif = dif + s.Length - current - 1;
                        }
                    }
                    else if (x == 1)
                    {
                        var next = bracketCollections.OpenBrackets[x + 1];
                        dif = next - prev - 2;

                        var lower = closedCount > 0
                            ? bracketCollections.ClosedBrackets[closedCount - 1]
                            : 1;

                        dif = dif + prev - lower - 1;
                    }
                    else
                    {
                        var next = bracketCollections.OpenBrackets[x + 1];
                        var prevprev = bracketCollections.OpenBrackets[x - 2];
                        dif = next - prevprev - 3;
                    }

                    if (dif > biggestDif)
                    {
                        open = true;
                        bracketsToRemove = new[] { prev, current };
                        biggestDif = dif;
                    }
                }

                for (var y = closedCount - 2; y >= 0; y--)
                {
                    var current = bracketCollections.ClosedBrackets[y];
                    var next = bracketCollections.ClosedBrackets[y + 1];
                    int dif;
                    if (y == 0)
                    {
                        dif = next - current - 1;
                        if (closedCount > 2)
                        {
                            var nextnext = bracketCollections.ClosedBrackets[y + 2];
                            dif = dif + nextnext - next - 1;
                        }
                        if (current != 0)
                        {
                            dif = dif + current;
                        }
                    }
                    else if (y == closedCount - 2)
                    {
                        var prev = bracketCollections.ClosedBrackets[y - 1];
                        dif = next - prev - 2;

                        var upper = openCount > 0
                            ? bracketCollections.OpenBrackets[0]
                            : s.Length;

                        dif = dif + upper - next - 1;

                    }
                    else
                    {
                        var prev = bracketCollections.ClosedBrackets[y - 1];
                        var nextnext = bracketCollections.ClosedBrackets[y + 2];
                        dif = nextnext - prev - 3;
                    }

                    if (dif > biggestDif)
                    {
                        open = false;
                        bracketsToRemove = new[] { current, next };
                        biggestDif = dif;
                    }

                }

                if (open)
                {
                    bracketCollections.OpenBrackets.Remove(bracketsToRemove[0]);
                    bracketCollections.OpenBrackets.Remove(bracketsToRemove[1]);
                }
                else
                {
                    bracketCollections.ClosedBrackets.Remove(bracketsToRemove[0]);
                    bracketCollections.ClosedBrackets.Remove(bracketsToRemove[1]);
                }


                if (!bracketCollections.OpenBrackets.Any() && !bracketCollections.ClosedBrackets.Any())
                {
                    return s.Length;
                }

                joined = bracketCollections.ClosedBrackets.ToList();
                joined.AddRange(bracketCollections.OpenBrackets);


                for (var j = 0; j < joined.Count; j++)
                {
                    var current = joined[j];
                    if (j == 0)
                    {
                        output = current;
                    }
                    else
                    {
                        var prev = joined[j - 1];

                        output = Math.Max(output, current - prev - 1);
                    }
                }

                if (joined.Any())
                {
                    output = Math.Max(output, s.Length - joined[joined.Count - 1] - 1);
                }
            }


            return output;
        }
    }
}
using System;
using System.Linq;

namespace Titanium2016
{
    public class AnotherSolver
    {
        public static int Solve(string s, int k, BracketCollections bracketCollections)
        {
            var open = bracketCollections.OpenBrackets;
            var closed = bracketCollections.ClosedBrackets;

            var output = Output.Calculate(s.Length, open, closed);

            if (k == 0
                || (!open.Any() && !closed.Any())
                || (!open.Any() && closed.Count == 1
                    && (closed[0] == s.Length -1
                        || closed[0] == 0))
                || (!closed.Any() && open.Count == 1 
                    && (open[0] == 0
                        || (open[0] == s.Length - 1))))
            {
                return output;
            }

            for (var x = 1; x < open.Count; x++)
            {
                var newOpen = open.ToList();
                newOpen.RemoveAt(x);
                newOpen.RemoveAt(x - 1);

                var possibleOutput = Solve(s, k - 1, new BracketCollections(newOpen, closed.ToList()));
                output = Math.Max(output, possibleOutput);
            }

            for (var y = closed.Count - 2; y >= 0; y--)
            {
                var newClosed = closed.ToList();
                newClosed.RemoveAt(y + 1);
                newClosed.RemoveAt(y);

                var possibleOutput = Solve(s, k - 1, new BracketCollections(open.ToList(), newClosed));
                output = Math.Max(output, possibleOutput);
            }

            if ((closed.Count == 1 && open.Any())
                || (open.Count == 1 && closed.Any()))
            {
                var newClosed = closed.ToList();
                var newOpen = open.ToList();

                newClosed.Add(newOpen[0]);
                newOpen.RemoveAt(0);

                var possibleOutput = Solve(s, k - 1, new BracketCollections(newOpen, newClosed));
                output = Math.Max(output, possibleOutput);
            }
            else if (closed.Count == 1)
            {
                var newClosed = closed.ToList();
                var newOpen = open.ToList();

                newOpen.Add(0);
                newClosed.RemoveAt(0);

                var possibleOutput = Solve(s, k - 1, new BracketCollections(newOpen, newClosed));
                output = Math.Max(output, possibleOutput);
            }
            else if (open.Count == 1)
            {
                var newClosed = closed.ToList();
                var newOpen = open.ToList();

                newClosed.Add(s.Length - 1);
                newOpen.RemoveAt(0);

                var possibleOutput = Solve(s, k - 1, new BracketCollections(newOpen, newClosed));
                output = Math.Max(output, possibleOutput);
            }


            return output;
        }
    }
}
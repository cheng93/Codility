using System;
using System.Linq;

namespace Titanium2016
{
    public class Solver
    {
        public static int Solve(string s, int k, BracketCollections bracketCollections)
        {
            var open = bracketCollections.OpenBrackets;
            var closed = bracketCollections.ClosedBrackets;

            var output = Output.Calculate(s.Length, open, closed);

            if (k == 0
                || (!open.Any() && !closed.Any())
                || (!open.Any() && closed.Count == 1 + (2 * k)
                    && (closed[0] == s.Length - 1
                        || closed[0] == 0))
                || (!closed.Any() && open.Count == 1 + (2 * k)
                    && (open[0] == 0
                        || (open[0] == s.Length - 1))))
            {
                return output;
            }

            if (closed.Any())
            {
                // We have enough swaps to optimize the closed brackets.
                if (k >= (closed.Count + 1) / 2)
                {
                    // We have an even number amount of closed brackets.
                    if (closed.Count % 2 == 0)
                    {
                        // We only need to work output how many swaps we do on the open brackets.
                        var swapsLeft = k - (closed.Count / 2);
                        var possibleOutput = Solve(s, swapsLeft, new BracketCollections(open, new int[] { }));
                        output = Math.Max(output, possibleOutput);
                    }
                    // We have an odd number of closed brackets.
                    else
                    {
                        // There are no open brackets, so we only focus on closed.
                        if (open.Count == 0)
                        {
                            var possibleOutput = s.Length - 1;
                            output = Math.Max(output, possibleOutput);
                        }
                        // There are open brackets.
                        else
                        {
                            // We need work out how many of the open brackets we can swap.
                            // This will be at least 1.
                            var swapsLeft = k - (closed.Count / 2);
                            var swapsLeftMinusOne = swapsLeft - 1;

                            // We can swap all the open brackets, and one left to spare.
                            if (swapsLeftMinusOne >= (open.Count + 1) / 2)
                            {
                                // Even number of open brackets.
                                if (open.Count % 2 == 0)
                                {
                                    var possibleOutput = s.Length - 1;
                                    output = Math.Max(output, possibleOutput);
                                }
                                // Odd number of open brackets.
                                else
                                {
                                    var possibleOutput = s.Length;
                                    output = Math.Max(output, possibleOutput);
                                }
                            }
                            // We cant swap all the open brackets. Oh noes!
                            else
                            {
                                // The first open bracket isnt at the start. We can optimize this.
                                if (closed[0] != 0)
                                {
                                    var possibleOutput = open[swapsLeftMinusOne * 2] - 1;
                                    output = Math.Max(output, possibleOutput);
                                }

                                // Even number of open brackets.
                                if (open.Count % 2 == 0)
                                {
                                    // We just manage to swap the last bracket with out extra swap.
                                    if (open[(swapsLeftMinusOne * 2) + 1] == open.Last())
                                    {
                                        var possibleOutput = s.Length - 1 - closed[0];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                    else
                                    {
                                        var possibleOutput = open[(swapsLeftMinusOne + 1) * 2] - 1 - closed[0];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                }
                                // Odd number of open brackets.
                                else
                                {
                                    // We manage to swap end the brackets with our extra swap.
                                    if (open[swapsLeftMinusOne * 2] == open.Last())
                                    {
                                        // However the last open bracket is at the end. We can't swap this.
                                        if (open.Last() == s.Length - 1)
                                        {
                                            var possibleOutput = s.Length - 2;
                                            output = Math.Max(output, possibleOutput);

                                        }
                                        else
                                        {
                                            var possibleOutput = s.Length - 2 - closed[0];
                                            output = Math.Max(output, possibleOutput);
                                        }
                                    }
                                    else
                                    {
                                        var possibleOutput = open[swapsLeft * 2] - closed[0] - 1;
                                        output = Math.Max(output, possibleOutput);
                                    }
                                }
                            }
                        }
                    }
                }

                // We have look at each element now.
                for (var i = 0; i < closed.Count; i++)
                {
                    // We can't fully optimize elements on this.
                    if (k < (closed.Count - i + 1) / 2)
                    {
                        var possibleOutput = closed[(2 * k) + i] - (i == 0 ? 0 : closed[i - 1] + 1);
                        output = Math.Max(output, possibleOutput);
                    }
                    // We do have swaps to optimize closed brackets.
                    else if (i != 0)
                    {
                        var swapsLeft = k - ((closed.Count - i) / 2);

                        // The remaining number of closed brackets is even.
                        if ((closed.Count - i) % 2 == 0)
                        {
                            // We have no swaps left.
                            if (swapsLeft == 0)
                            {
                                // There are no open brackets
                                if (open.Count == 0)
                                {
                                    var possibleOutput = s.Length - 1 - closed[i - 1];
                                    output = Math.Max(output, possibleOutput);
                                }
                                // There are some open brackets, however we can't swap them.
                                else
                                {
                                    var possibleOutput = open[0] - 1 - closed[i - 1];
                                    output = Math.Max(output, possibleOutput);
                                }
                            }
                            else
                            {
                                // We have enough swaps to swap all of the open brackets.
                                if (swapsLeft >= (open.Count + 1) / 2)
                                {
                                    // There are an even number of open brackets.
                                    if (open.Count % 2 == 0)
                                    {
                                        var possibleOutput = s.Length - 1 - closed[i - 1];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                    // There are an odd number of open brackets.
                                    else
                                    {
                                        var possibleOutput = s.Length - 2 - closed[i - 1];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                }
                                // We don't have enough to swap all open brackets.
                                else
                                {
                                    var possibleOutput = open[swapsLeft * 2] - 1 - closed[i - 1];
                                    output = Math.Max(output, possibleOutput);
                                }
                            }
                        }
                        // The remaining number of brackets is odd.
                        else
                        {
                            // There are no open brackets.
                            if (open.Count == 0)
                            {
                                // We are on the last closed bracket.
                                if (i == closed.Count - 1)
                                {
                                    var possibleOutput = s.Length - 1 - closed[i];
                                    output = Math.Max(output, possibleOutput);
                                }
                                // We are not on the last closed bracket.
                                else
                                {
                                    var possibleOutput = closed.Last() - closed[i - 1] - 1;
                                    output = Math.Max(output, possibleOutput);
                                }
                            }
                            // We have open brackets.
                            else
                            {
                                // We can only flip the last closed bracket. This won't make a pair unfortunately.
                                if (swapsLeft < 2)
                                {
                                    // We are on the last closed bracket.
                                    if (i == closed.Count - 1)
                                    {
                                        var possibleOutput = open[0] - 1 - closed[i];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                    else
                                    {
                                        var possibleOutput = closed.Last() - closed[i - 1] - 1;
                                        output = Math.Max(output, possibleOutput);
                                    }
                                }
                                // We can swap the other side.
                                else
                                {
                                    var swapsLeftMinusTwo = swapsLeft - 2;
                                    // There was only one open to flip.
                                    if (open.Count == 1)
                                    {
                                        var possibleOutput = s.Length - 1 - closed[i - 1];
                                        output = Math.Max(output, possibleOutput);
                                    }
                                    else
                                    {
                                        // We can flip all of the otherside.
                                        if (swapsLeftMinusTwo >= open.Count / 2)
                                        {
                                            // Remaining open brackets is even.
                                            if (open.Count - 1 % 2 == 0)
                                            {
                                                var possibleOutput = s.Length - 1 - closed[i - 1];
                                                output = Math.Max(output, possibleOutput);
                                            }
                                            // Odd open brackets left.
                                            else
                                            {
                                                var possibleOutput = s.Length - 2 - closed[i - 1];
                                                output = Math.Max(output, possibleOutput);
                                            }
                                        }
                                        // We can't flip all of the other side.
                                        else
                                        {
                                            var possibleOutput = open[(swapsLeftMinusTwo * 2) + 1] - 1 -
                                                                 closed[i - 1];
                                            output = Math.Max(output, possibleOutput);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            // We have enough swaps to optimize the open brackets.
            if (k >= (open.Count + 1) / 2)
            {
                // We have odd number of open brackets.
                if (open.Count % 2 == 1)
                {
                    // The last open bracket is at the end.
                    if (open.Last() == s.Length - 1)
                    {
                        // We can't increase our output if bracket is at the end.
                        var possibleOutput = s.Length - 1 - (closed.Any() ? closed.Last() + 1 : 0);
                        output = Math.Max(output, possibleOutput);
                    }
                    // The last bracket isn't at the end.
                    else
                    {
                        // We can optimize more by swapping a bracket between the last open and last bracket.
                        var possibleOutput = s.Length - 1 - (closed.Any() ? closed.Last() + 1 : 0);
                        output = Math.Max(output, possibleOutput);
                    }
                }
                // We have even number of open brackets.
                else
                {
                    var possibleOutput = s.Length - (closed.Any() ? closed.Last() + 1 : 0);
                    output = Math.Max(output, possibleOutput);
                }
            }
            // We don't have enough swaps to optimize the open brackets.
            else
            {
                // We have to go through each open bracket, and see which yields the best result.
                for (var i = 0; i < open.Count; i++)
                {
                    // We have enough swaps to optimize where we started.
                    if (k >= (open.Count - i + 1) / 2 && i != 0)
                    {
                        // We have an odd amount brackets remaining.
                        if (open.Count - i % 2 == 1)
                        {
                            // The last open bracket is at the end.
                            if (open.Last() == s.Length - 1)
                            {
                                // We can't increase our output if bracket is at the end.
                                var possibleOutput = s.Length - open[i - 1] - 2;
                                output = Math.Max(output, possibleOutput);
                            }
                            // We can flip the last bracket.
                            else
                            {
                                var possibleOutput = s.Length - open[i - 2] - 1;
                                output = Math.Max(output, possibleOutput);
                            }
                        }
                        // We have an even amount left.
                        else
                        {
                            var possibleOutput = s.Length - open[i - 1] - 1;
                            output = Math.Max(output, possibleOutput);
                        }

                    }
                    // We don't have enough swaps to optimize where we started.
                    else
                    {
                        var possibleOutput = open[i + (2 * k)] - (i == 0 ? closed.Any() ? closed.Last() + 1 : 0 : open[i - 1] + 1);
                        output = Math.Max(output, possibleOutput);
                    }
                }
            }

            return output;
        }
    }
}
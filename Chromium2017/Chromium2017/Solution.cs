using System.Collections.Generic;
using System.Linq;

namespace Chromium2017
{
    public class Solution
    {
        public int Solve(int[] input)
        {
            if (input.Length == 1)
            {
                return 1;
            }

            var output = input.Length;

            for (var i = 0; i < input.Length; i++)
            {
                var nest = new Nest(input, i);
                output = (output + Solve(nest)) % 1000000007;
            }

            return output;
        }

        private int Solve(Nest nest)
        {
            var left = new List<int>();
            var right = new List<int>();

            var leftKeys = GetKeysDictionary(nest.LeftIndexLookup);
            var rightKeys = GetKeysDictionary(nest.RightIndexLookup);

            if (nest.SmallestIsLeft)
            {
                for (var i = 0; i < leftKeys.Count; i++)
                {
                    var leftSize = nest.LeftIndexLookup[leftKeys[i]].LongCount();
                    var leftCompute = leftSize * (1 + right.Aggregate(0, (x, y) => (x + y) % 1000000007));
                    left.Add((int) (leftCompute % 1000000007));

                    if (i < rightKeys.Count)
                    {
                        var rightSize = nest.RightIndexLookup[rightKeys[i]].LongCount();
                        var rightCompute = rightSize * (1 + left.Aggregate(0, (x, y) => (x + y) % 1000000007));
                        right.Add((int) (rightCompute % 1000000007));
                    }
                }
            }
            else
            {
                for (var i = 0; i < rightKeys.Count; i++)
                {
                    var rightSize = nest.RightIndexLookup[rightKeys[i]].LongCount();
                    var rightCompute = rightSize * (1 + left.Aggregate(0, (x, y) => (x + y) % 1000000007));
                    right.Add((int)(rightCompute % 1000000007));

                    if (i < leftKeys.Count)
                    {
                        var leftSize = nest.LeftIndexLookup[leftKeys[i]].LongCount();
                        var leftCompute = leftSize * (1 + right.Aggregate(0, (x, y) => (x + y) % 1000000007));
                        left.Add((int)(leftCompute % 1000000007));
                    }
                }
            }

            return (left.Aggregate(0, (x, y) => (x + y) % 1000000007) + right.Aggregate(0, (x, y) => (x + y) % 1000000007)) % 1000000007;
        }

        private IDictionary<int, int> GetKeysDictionary(ILookup<int, int> lookup)
        {
            return lookup
                .Select((x, i) => new
                {
                    Index = i,
                    Key = x.Key
                })
                .ToDictionary(x => x.Index, x => x.Key);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Scandium2016
{
    public class Solution
    {
        private readonly IOddNodesGrabber _oddNodesGrabber;

        private readonly IOddNodesWinnable _oddNodesWinnable;

        public Solution(IOddNodesGrabber oddNodesGrabber, IOddNodesWinnable oddNodesWinnable)
        {
            _oddNodesGrabber = oddNodesGrabber;
            _oddNodesWinnable = oddNodesWinnable;
        }

        public string Solve(int[] a)
        {
            var oddNodes = _oddNodesGrabber.Grab(a).ToList();

            var winningSlices = new List<ISlice>();
            if (oddNodes.Count % 2 == 0)
            {
                winningSlices.Add(new Slice(0, a.Length));
                return Format(winningSlices);
            }
            
            var slice = _oddNodesWinnable.Get(oddNodes[0], oddNodes, a.Length);
            if (slice != null)
            {
                winningSlices.Add(slice);
            }

            slice = _oddNodesWinnable.Get(oddNodes[oddNodes.Count - 1], oddNodes, a.Length);
            if (slice != null)
            {
                winningSlices.Add(slice);
            }

            return Format(winningSlices);

        }

        private string Format(IEnumerable<ISlice> slices)
        {
            return slices.OrderBy(s => s.Start).ThenBy(s => s.Length).FirstOrDefault()?.ToString() ?? "NO SOLUTION";
        }

        public static Solution Create()
        {
            return new Solution(new OddNodesGrabber(), new OddNodesWinnable());
        }
    }
}

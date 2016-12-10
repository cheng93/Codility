using System.Collections.Generic;
using System.Linq;

namespace Scandium2016
{
    internal class LastNodesWinnable : IOddNodesWinnable
    {
        public ISlice Get(int node, ICollection<int> oddNodes, int totalNodes)
        {
            var rightEvenSlices = totalNodes - node - 1;
            var firstOddBeforeNode = oddNodes.ElementAt(oddNodes.Count - 2);
            var leftEvenSlicesAfterLastOdd = node - firstOddBeforeNode - 1;
            var firstOdd = oddNodes.First();
            var evenSlicesBeforeFirstOdd = firstOdd;
            var difference = evenSlicesBeforeFirstOdd + leftEvenSlicesAfterLastOdd - rightEvenSlices;

            if (difference == 0)
            {
                return new Slice(firstOdd, firstOddBeforeNode - firstOdd + 1);
            }

            if (difference > 0)
            {
                if (evenSlicesBeforeFirstOdd >= difference)
                {
                    return new Slice(firstOdd - difference, firstOddBeforeNode - firstOdd + 1 + difference);
                }
                difference = difference - evenSlicesBeforeFirstOdd;
                return new Slice(0, firstOddBeforeNode + 1 + difference);
            }

            return null;
        }
    }
}
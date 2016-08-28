using System.Collections.Generic;
using System.Linq;

namespace Scandium2016
{
    internal class FirstNodesWinnable : IOddNodesWinnable
    {
        public ISlice Get(int node, ICollection<int> oddNodes, int totalNodes)
        {
            var leftEvenSlices = node;
            var firstOddAfterNode = oddNodes.ElementAt(1);
            var rightEvenSlicesBeforeFirstOdd = firstOddAfterNode - node - 1;
            var lastOdd = oddNodes.Last();
            var evenSlicesAfterLastOdd = totalNodes - lastOdd - 1;
            var difference = rightEvenSlicesBeforeFirstOdd + evenSlicesAfterLastOdd - leftEvenSlices;

            if (difference == 0)
            {
                return new Slice(firstOddAfterNode, lastOdd - firstOddAfterNode + 1);
            }

            if (difference > 0)
            {
                if (rightEvenSlicesBeforeFirstOdd >= difference)
                {
                    return new Slice(firstOddAfterNode - difference, lastOdd - firstOddAfterNode + 1 + difference);
                }
                difference = difference - rightEvenSlicesBeforeFirstOdd;
                return new Slice(node + 1, lastOdd - node + difference);
            }

            return null;
        }
    }
}

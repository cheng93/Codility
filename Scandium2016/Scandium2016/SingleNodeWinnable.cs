
using System.Collections.Generic;

namespace Scandium2016
{
    internal class SingleNodeWinnable : IOddNodesWinnable
    {
        public ISlice Get(int node, ICollection<int> oddNodes, int totalNodes)
        {
            var left = node;
            var right = totalNodes - node - 1;
            if (left == right) return null;

            if (left > right)
            {
                return new Slice(0, left - right);
            }
            return new Slice(node + 1, right - left);
        }
    }
}
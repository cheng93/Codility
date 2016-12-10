using System.Collections.Generic;

namespace Scandium2016
{
    internal class EndNodesWinnable : IOddNodesWinnable
    {
        public ISlice Get(int node, ICollection<int> oddNodes, int totalNodes)
        {
            if (totalNodes == 1) return null;

            if (node == 0)
            {
                return new Slice(1, totalNodes - 1);
            }
            if (node == totalNodes - 1)
            {
                return new Slice(0, totalNodes - 1);
            }
            return null;
        }
    }
}

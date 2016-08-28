using System.Collections.Generic;

namespace Scandium2016
{
    public interface IOddNodesWinnable
    {
        ISlice Get(int node, ICollection<int> oddNodes, int totalNodes);
    }
}
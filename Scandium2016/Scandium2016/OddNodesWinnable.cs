using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Scandium2016.UnitTest")]
namespace Scandium2016
{
    internal class OddNodesWinnable : IOddNodesWinnable
    {
        private readonly IOddNodesWinnable _endNodesWinnable = new EndNodesWinnable();

        private readonly IOddNodesWinnable _firstNodesWinnable = new FirstNodesWinnable();

        private readonly IOddNodesWinnable _lastNodesWinnable = new LastNodesWinnable();

        private readonly IOddNodesWinnable _singleNodesWinnable = new SingleNodeWinnable();

        public ISlice Get(int node, ICollection<int> oddNodes, int totalNodes)
        {
            if (node == 0 || node == totalNodes - 1)
            {
                return _endNodesWinnable.Get(node, oddNodes, totalNodes);
            }

            if (oddNodes.Count == 1)
            {
                return _singleNodesWinnable.Get(node, oddNodes, totalNodes);
            }

            if (node == oddNodes.First())
            {
                return _firstNodesWinnable.Get(node, oddNodes, totalNodes);
            }

            if (node == oddNodes.Last())
            {
                return _lastNodesWinnable.Get(node, oddNodes, totalNodes);
            }

            return null;
        }
    }
}
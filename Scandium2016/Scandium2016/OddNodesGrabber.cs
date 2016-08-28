using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Scandium2016.UnitTest")]
namespace Scandium2016
{ 
    internal class OddNodesGrabber : IOddNodesGrabber
    {
        public IEnumerable<int> Grab(int[] nodes)
        {
            if (nodes == null) return new List<int> {};
            
            return nodes.Select((n, i) => new {i, n}).Where(w => w.n % 2 == 1).Select(s => s.i);
        }
    }
}

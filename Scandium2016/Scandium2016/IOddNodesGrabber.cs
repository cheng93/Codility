using System.Collections.Generic;

namespace Scandium2016
{
    public interface IOddNodesGrabber
    {
        IEnumerable<int> Grab(int[] nodes);
    }
}
using System.Collections.Generic;

namespace Titanium2016
{
    public class MaxSwaps
    {
        public static int Calculate(int length, IList<int> openBrackets, IList<int> closedBrackets)
        {
            var open = openBrackets.Count;
            var closed = closedBrackets.Count;

            if (open == 0)
            {
                if (closed == 0)
                {
                    return 0;
                }
                return closed / 2;
            }

            if (closed == 0)
            {
                return open / 2;
            }

            if ((open + closed) % 2 == 1 || open % 2 == 0)
            {
                return (open / 2) + (closed / 2);
            }

            return 2 + (open / 2) + (closed / 2);
        }
    }
}
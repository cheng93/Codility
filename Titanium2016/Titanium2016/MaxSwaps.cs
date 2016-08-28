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
                if (closed % 2 == 0
                    || closedBrackets[0] == 0
                    || closedBrackets[closed - 1] == length - 1)
                {
                    return closed / 2;
                }
                return (closed / 2) + 1;
            }

            if (closed == 0)
            {
                if (open % 2 == 0
                    || openBrackets[0] == 0
                    || openBrackets[open - 1] == length - 1)
                {
                    return open / 2;
                }
                return (open / 2) + 1;
            }

            if (open % 2 == 0 && closed % 2 == 0)
            {
                return (open / 2) + (closed / 2);
            }

            if ((open + closed) % 2 == 1)
            {
                if (open % 2 == 1
                    && openBrackets[0] != 0
                    && openBrackets[open - 1] != length - 1)
                {
                    return (open / 2) + (closed / 2) + 1;
                }

                if (closed % 2 == 1
                    && closedBrackets[0] != 0
                    && closedBrackets[closed - 1] != length -1)
                {
                    return (open / 2) + (closed / 2) + 1;
                }

                return (open / 2) + (closed / 2);
            }

            return 2 + (open / 2) + (closed / 2);
        }
    }
}
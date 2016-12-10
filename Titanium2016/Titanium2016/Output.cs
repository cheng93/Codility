using System;
using System.Collections.Generic;
using System.Linq;

namespace Titanium2016
{
    public class Output
    {
        public static int Calculate(int length, IList<int> openBrackets, IList<int> closedBrackets)
        {
            if (!openBrackets.Any() && !closedBrackets.Any())
            {
                return length;
            }

            var joined = closedBrackets.ToList();
            joined.AddRange(openBrackets);

            var output = joined[0];

            for (var i = 1; i < joined.Count; i++)
            {
                var current = joined[i];
                var prev = joined[i - 1];

                var dif = current - prev - 1;

                output = Math.Max(output, dif);
            }

            var end = length - joined.Last() - 1;

            output = Math.Max(output, end);

            return output;
        }
    }
}
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Argon2015.UnitTest")]
namespace Argon2015
{
    internal class ImprovedForecastsChange : IForecastsChange
    {
        public IEnumerable<int> Get(int[] forecasts)
        {
            var output = new List<int>();

            if (forecasts.Length < 2) return output;

            var zeroCount = forecasts[forecasts.Length - 1] == 0 ? 1 : 0;
            var oneCount = forecasts[forecasts.Length - 1] == 1 ? 1 : 0;
            int? difference = null;
            int? desperateSplit = null;

            for (int i = forecasts.Length - 2; i >= 0; i--)
            {
                if (forecasts[i] == 0 && forecasts[i + 1] == 1)
                {
                    if (!difference.HasValue)
                    {
                        difference = oneCount - zeroCount;
                    }
                    desperateSplit = i;
                    if (oneCount - zeroCount > difference)
                    {
                        difference = oneCount - zeroCount;
                        output.Clear();
                        output.Add(i);
                    }
                    else if (oneCount - zeroCount == difference)
                    {
                        output.Add(i);
                    }
                }
                if (forecasts[i] == 0)
                {
                    zeroCount++;
                }
                else if (forecasts[i] == 1)
                {
                    oneCount++;
                }
            }
            if (output.Count == 0 && desperateSplit.HasValue)
            {
                output.Add(desperateSplit.Value);
            }
            return output;
        }
    }
}

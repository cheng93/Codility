using System.Collections.Generic;
using System.Linq;

namespace Argon2015
{
    internal abstract class ForecastCounter : IForecastCounter
    {
        private readonly int _goodForecast;

        protected ForecastCounter(int goodForecast)
        {
            _goodForecast = goodForecast;
        }

        public int Count(IEnumerable<int> forecasts)
        {
            var count = 1;
            var runningCount = 0;
            var goodForecastCount = 0;
            var badForecastCount = 0;

            foreach (var forecast in forecasts.Skip(1))
            {
                if (forecast == _goodForecast)
                {
                    goodForecastCount++;
                    if (goodForecastCount <= badForecastCount)
                    {
                        runningCount += 2;
                        goodForecastCount--;
                        badForecastCount--;
                    }
                }
                else
                {
                    badForecastCount++;
                    if (badForecastCount <= goodForecastCount)
                    {
                        runningCount += 2;
                        goodForecastCount--;
                        badForecastCount--;
                    }
                }

                if (badForecastCount == 0)
                {
                    count += runningCount;
                    runningCount = 0;
                }
            }

            return count + goodForecastCount;
        }
    }
}
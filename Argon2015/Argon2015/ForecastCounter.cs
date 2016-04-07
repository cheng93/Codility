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

        /// <summary>
        /// Counts the number of days available.
        /// </summary>
        /// <param name="forecasts"></param>
        /// <returns></returns>
        /// <remarks>
        /// This method works by:
        /// 1) We can assume the first value is equal to the good forecast value.
        /// 2) We loop through forecast, by skipping the first value.
        /// 3a) If the current forecast is equal to the good forecast value, we increase the count.
        /// 3b) If the good forecast count, is less than or equal to bad forecast count,
        /// we know we have made a (good, bad) pair.
        /// 3c) Append 2 to the running total, and decrease the count by one for each count.
        /// 3d) Vice versa for bad days.
        /// 4) If bad forecast count is 0, we have made the cancelled out the offset, thus we append to our actual count.
        /// 5) Return the count and any addition good days.
        /// </remarks>
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
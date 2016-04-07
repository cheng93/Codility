using System.Linq;

namespace Argon2015
{
    public class Solution
    {
        private readonly IForecastsChange _forecastsChange;

        private readonly IForecastCounter _swimmingForecastCounter;

        private readonly IForecastCounter _trekkingForecastCounter;

        public Solution(IForecastsChange forecastsChange, IForecastCounter swimmingForecastCounter, IForecastCounter trekkingForecastCounter)
        {
            _forecastsChange = forecastsChange;
            _swimmingForecastCounter = swimmingForecastCounter;
            _trekkingForecastCounter = trekkingForecastCounter;
        }

        /// <summary>
        /// Method to solve Argon 2015 challenge.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        /// <remarks>
        /// This method works by:
        /// 1) Getting the indexes where the next index is different. 
        /// These are the days when the forecasts have change.
        /// 2) For each day, we calculate the days we have for swimming and trekking. 
        /// If the sum of them is greater than our current count, then this becomes the new value.
        /// </remarks>
        public int Solve(int[] a)
        {
            var daysWithChange = _forecastsChange.Get(a).ToList();

            if (daysWithChange.Count == 0) return 0;

            var holidayDays = 0;

            foreach (var day in daysWithChange)
            {
                var swimmingDays = _swimmingForecastCounter.Count(a.Take(day + 1).Reverse());
                var trekkingDays = _trekkingForecastCounter.Count(a.Skip(day + 1));

                if (swimmingDays + trekkingDays > holidayDays)
                {
                    holidayDays = swimmingDays + trekkingDays;
                }
            }

            return holidayDays;
        }

        public static Solution Create()
        {
            return new Solution(new ImprovedForecastsChange(), new SwimmingForecastCounter(), new TrekkingForecastCounter());
        }
    }
}
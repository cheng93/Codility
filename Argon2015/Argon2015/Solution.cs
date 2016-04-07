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
            return new Solution(new ForecastsChange(), new SwimmingForecastCounter(), new TrekkingForecastCounter());
        }
    }
}
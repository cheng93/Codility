using System.Linq;

namespace Argon2015
{
    public class Solution
    {
        private readonly IForecastsChange _forecastsChange;

        public Solution(IForecastsChange forecastsChange)
        {
            _forecastsChange = forecastsChange;
        }

        public int Solve(int[] a)
        {
            var daysWithChange = _forecastsChange.Get(a);

            if (!daysWithChange.Any()) return 0;
            
            throw new System.NotImplementedException();
        }

        public static Solution Create()
        {
            return new Solution(new ForecastsChange());
        }
    }
}
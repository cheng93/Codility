using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Argon2015.UnitTest")]
namespace Argon2015
{
    internal class ForecastsChange : IForecastsChange
    {
        public IEnumerable<int> Get(int[] forecasts)
        {
            if (forecasts.Length < 2) return new List<int> {};

            return forecasts.Where((f, i) => i != forecasts.Length - 1 && f == 0 && forecasts[i + 1] == 1);
        }
    }
}
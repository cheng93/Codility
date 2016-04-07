using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Argon2015.UnitTest")]
namespace Argon2015
{
    internal class ForecastsChange : IForecastsChange
    {
        public IEnumerable<int> Get(int[] forecasts)
        {
            if (forecasts.Length < 2) return new List<int> { };

            return forecasts.Select((f, i) => new { i, f })
                .Where(w => w.i != forecasts.Length - 1 && w.f == 0 && forecasts[w.i + 1] == 1)
                .Select(s => s.i);
        }
    }
}
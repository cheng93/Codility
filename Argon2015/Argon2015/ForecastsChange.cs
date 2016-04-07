using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Argon2015.UnitTest")]
namespace Argon2015
{
    internal class ForecastsChange : IForecastsChange
    {
        /// <summary>
        /// Gets an enumerable of indexes when the forecast will change.
        /// </summary>
        /// <param name="forecasts"></param>
        /// <returns></returns>
        /// <remarks>
        /// The original index are 0 and will change to 1.
        /// </remarks>
        public IEnumerable<int> Get(int[] forecasts)
        {
            if (forecasts.Length < 2) return new List<int> { };

            return forecasts.Select((f, i) => new { i, f })
                .Where(w => w.i != forecasts.Length - 1 && w.f == 0 && forecasts[w.i + 1] == 1)
                .Select(s => s.i);
        }
    }
}
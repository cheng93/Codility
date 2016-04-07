using System.Collections.Generic;

namespace Argon2015
{
    public interface IForecastsChange
    {
        /// <summary>
        /// Gets the indexes of the array when the next value has changed.
        /// </summary>
        /// <param name="forecasts"></param>
        /// <returns></returns>
        IEnumerable<int> Get(int[] forecasts);
    }
}
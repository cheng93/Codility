using System.Collections.Generic;

namespace Argon2015
{
    public interface IForecastCounter
    {
        int Count(IEnumerable<int> forecasts);
    }
}
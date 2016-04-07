using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
    }
}

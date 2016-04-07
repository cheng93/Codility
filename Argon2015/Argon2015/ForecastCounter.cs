using System;

namespace Argon2015
{
    internal abstract class ForecastCounter : IForecastCounter
    {
        private readonly int _goodForecast;

        protected ForecastCounter(int goodForecast)
        {
            _goodForecast = goodForecast;
        }

        public int Count(int start, int[] forecasts)
        {
            throw new NotImplementedException();
        }
    }
}

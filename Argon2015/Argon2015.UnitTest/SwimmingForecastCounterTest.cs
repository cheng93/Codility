using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argon2015.UnitTest
{
    [TestClass]
    public class SwimmingForecastCounterTest
    {
        private readonly IForecastCounter _forecastCounter = new SwimmingForecastCounter();

        [TestMethod]
        public void Empty()
        {
            var forecasts = new List<int> {};

            var actual = _forecastCounter.Count(forecasts);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
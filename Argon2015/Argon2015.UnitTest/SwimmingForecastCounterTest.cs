using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argon2015.UnitTest
{
    [TestClass]
    public class SwimmingForecastCounterTest
    {
        private readonly IForecastCounter _forecastCounter = new SwimmingForecastCounter();

        [TestMethod]
        public void Single()
        {
            var forecasts = new List<int> { 0 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Single_BadWeather()
        {
            var forecasts = new List<int> { 1 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equal()
        {
            var forecasts = new List<int> { 0, 1 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraDays()
        {
            var forecasts = new List<int> { 0, 1, 0 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraExtraDays()
        {
            var forecasts = new List<int> { 0, 1, 0, 0 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadHeavyDays()
        {
            var forecasts = new List<int> { 0, 1, 1, 0 };

            var actual = _forecastCounter.Count(forecasts);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argon2015.UnitTest
{
    [TestClass]
    public class ForecastsChangeTest
    {
        private readonly ForecastsChange _forecastsChange = new ForecastsChange();

        [TestMethod]
        public void Empty()
        {
            var forecasts = new int[] { };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void Single()
        {
            var forecasts = new int[] { 0 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void OneChange()
        {
            var forecasts = new int[] { 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0 };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod]
        public void OneChange_Reversed()
        {
            var forecasts = new int[] { 1, 0 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }


        [TestMethod]
        public void ChangeOnPenultimateDay()
        {
            var forecasts = new int[] { 0, 0, 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 2 };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }


        [TestMethod]
        public void ChangeOnFirstDay()
        {
            var forecasts = new int[] { 0, 1, 1, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0 };

            CollectionAssert.AreEqual(expected, actual.ToList());
        }
    }
}

﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argon2015.UnitTest
{
    [TestClass]
    public class ForecastsChangeTest
    {
        private readonly IForecastsChange _forecastsChange = new ImprovedForecastsChange();

        [TestMethod]
        public void Empty()
        {
            var forecasts = new int[] { };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void Single()
        {
            var forecasts = new int[] { 0 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void OneChange()
        {
            var forecasts = new int[] { 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0 };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void OneChange_Reversed()
        {
            var forecasts = new int[] { 1, 0 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void ChangeOnPenultimateDay()
        {
            var forecasts = new int[] { 0, 0, 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 2 };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void ChangeOnFirstDay()
        {
            var forecasts = new int[] { 0, 1, 1, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0 };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void MultipleChanges()
        {
            var forecasts = new int[] { 0, 1, 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0, 2 };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod]
        public void MultipleDelayedChanges()
        {
            var forecasts = new int[] { 0, 1, 1, 0, 1, 0, 0, 1 };

            var actual = _forecastsChange.Get(forecasts);
            var expected = new List<int> { 0, 6 };

            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }
    }
}

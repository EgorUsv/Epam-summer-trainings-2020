using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TaskOne;

namespace Task1_1Tests
{
    class GcdTimeTests
    {
        [Test]
        public void GcdTest()
        {
            var testArray = new int[] { 1475, 145 };
            var actual = new GcdTime().GetGcd(testArray[0], testArray[1]);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetTimeGcdTest()
        {
            var testArray = new int[] { 14534, 228 };
            var actual = new Dictionary<string, Stopwatch>(3);
            new Gcd().GetGcdByStein(testArray[0], testArray[1], out Stopwatch simpsonTime);
            actual.Add("Euclid time", new GcdTime()
                .GetBaseGcdTime(testArray[0], testArray[1]));
            actual.Add("Substruction time", new GcdTime()
                .GetGcdTime(testArray[0], testArray[1]));
            actual.Add("Simpson time", simpsonTime);
            Assert.IsTrue(actual["Euclid time"].ElapsedTicks > 0 &&
                actual["Substruction time"].ElapsedTicks > 0 &&
                actual["Simpson time"].ElapsedTicks > 0);
        }
    }
}

using System;
using System.Linq;
using Task2_1.Figures;
using Xunit;

namespace Task1_2Tests.FiguresTests
{
    public class TriangleTests
    {
        static double[] TestSides { get; } = { 14.0, 16.0, 17.0 };
        static string TestString { get; } = "This is Triangle";
        readonly Triangle testTriangle = new Triangle(TestSides);

        [Fact]
        public void TriangleTest()
        {
            var expected = TestSides;
            var actual = testTriangle.Sides;
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
        [Fact]
        public void AreaTest()
        {
            double halfPer = TestSides.Sum() / 2.0;
            var expected = Math.Sqrt(halfPer * (halfPer - TestSides[0]) * (halfPer - TestSides[1]) * (halfPer - TestSides[2]));
            var actual = testTriangle.Area();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void EqualsTest()
        {
            var expected = new Triangle(TestSides);
            var actual = testTriangle;
            Assert.True(actual.Equals(expected));
        }
        [Fact]
        public void GetHashCodeTest()
        {
            var actual = new Triangle(TestSides).GetHashCode();
            var expected = testTriangle.GetHashCode();
            Assert.NotEqual(expected, actual);
        }
        [Fact]
        public void PerimeterTest()
        {
            var expected = TestSides.Sum();
            var actual = testTriangle.Perimeter();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToStringTest()
        {
            var expected = TestString;
            var actual = testTriangle.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

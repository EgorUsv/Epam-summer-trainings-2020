using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Shapes;
using Xunit;

namespace Tests.ModelTests.ShapeTests
{
    public class TriangleTests
    {
        static double[] TestSides { get; } = { 14.0, 16.0, 17.0 };
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
            Assert.Equal(expected, actual);
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
            var expected = testTriangle.GetType().AssemblyQualifiedName + " " + TestSides[0] +
                " " + TestSides[1] + " " + TestSides[2];
            var actual = testTriangle.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

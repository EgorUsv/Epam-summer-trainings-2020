using System;
using System.Collections.Generic;
using System.Text;
using Task3.Shapes;
using Xunit;

namespace Tests.ModelTests.ShapeTests
{
    public class CircleTests
    {
        static readonly double testRadius = 7;
        readonly Circle testFigure = new Circle(testRadius);

        [Fact]
        public void CircleTest()
        {
            var expected = testRadius;
            var actual = new Circle(testRadius).Radius;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AreaTest()
        {
            var expected = Math.PI * Math.Pow(testRadius, 2);
            var actual = testFigure.Area();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void EqualsTest()
        {
            var expected = new Circle(testRadius);
            var actual = testFigure;
            Assert.True(actual.Equals(expected));
        }
        [Fact]
        public void GetHashCodeTest()
        {
            var actual = new Circle(testRadius).GetHashCode();
            var expected = testFigure.GetHashCode();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PerimeterTest()
        {
            var expected = 2 * Math.PI * testRadius;
            var actual = testFigure.Perimeter();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToStringTest()
        {
            var expected = testFigure.GetType().AssemblyQualifiedName + " " + testRadius;
            var actual = testFigure.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Shapes;
using Xunit;

namespace Tests.ModelTests.ShapeTests
{
    public class RectangleTests
    {
        static double[] TestSides { get; } = { 16.0, 10.0 };
        readonly Rectangle testRect = new Rectangle(TestSides);

        [Fact]
        public void RectangleTest()
        {
            var expected = new Rectangle(TestSides);
            var actual = testRect;
            Assert.True(Enumerable
                .SequenceEqual(expected.Sides, actual.Sides));
        }
        [Fact]
        public void PerimeterTest()
        {
            var expected = 2 * (TestSides[0] + TestSides[1]);
            var actual = testRect.Perimeter();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetHashCodeTest()
        {
            var actual = new Rectangle(TestSides).GetHashCode();
            var expected = testRect.GetHashCode();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AreaTest()
        {
            var expected = TestSides[0] * TestSides[1];
            var actual = testRect.Area();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsTest()
        {
            var expected = new Rectangle(TestSides);
            var actual = testRect;
            Assert.True(actual.Equals(expected));
        }
        [Fact]
        public void ToStringTest()
        {
            var expected = testRect.GetType().AssemblyQualifiedName + " " + TestSides[0] +
                " " + TestSides[1];
            var actual = testRect.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Task3.Shapes;
using Xunit;

namespace Tests.ModelTests.ShapeTests
{
    public class SquareTests
    {
        static double Side { get; } = 14;
        readonly Square testSquare = new Square(Side);

        [Fact]
        public void SquareTest()
        {
            var expected = new Square(Side).Side;
            var actual = testSquare.Side;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AreaTest()
        {
            var expected = Math.Pow(Side, 2);
            var actual = testSquare.Area();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void EqualsTest()
        {
            var expected = new Square(Side);
            var actual = testSquare;
            Assert.True(actual.Equals(expected));
        }
        [Fact]
        public void GetHashCodeTest()
        {
            var actual = new Square(Side).GetHashCode();
            var expected = testSquare.GetHashCode();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PerimeterTest()
        {
            var expected = Side * 4;
            var actual = testSquare.Perimeter();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToStringTest()
        {
            var expected = testSquare.GetType().AssemblyQualifiedName + " " + Side;
            var actual = testSquare.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using Vector;
using Xunit;

namespace VectorTests
{
    public class Vector3Tests
    {
        [Fact]
        public void Vector3SingleTest()
        {
            var expected = (45, 45, 45);
            var obj = new Vector3(45);
            var actual = (obj.X, obj.Y, obj.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3Test()
        {
            var expected = (45, 15, 24);
            var obj = new Vector3(45, 15, 24);
            var actual = (obj.X, obj.Y, obj.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3SumOperatorTest()
        {
            var vector1 = new Vector3(20, 10, 13);
            var vector2 = new Vector3(25, 44, 17);
            var newVector = vector1 + vector2;
            var expected = (45, 54, 30);
            var actual = (newVector.X, newVector.Y, newVector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3MultiplyOperatorTest()
        {
            var vector1 = new Vector3(20, 10, 13);
            var vector2 = new Vector3(25, 44, 17);
            var newVector = vector1 * vector2;
            var expected = (-402, -15, 630);
            var actual = (newVector.X, newVector.Y, newVector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3SubtractionOperatorTest()
        {
            var vector1 = new Vector3(20, 10, 13);
            var vector2 = new Vector3(25, 44, 17);
            var newVector = vector1 - vector2;
            var expected = (-5, -34, -4);
            var actual = (newVector.X, newVector.Y, newVector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3NegativeOperatorTest()
        {
            var vector = -new Vector3(20, 10, 13);
            var expected = (-20, -10, -13);
            var actual = (vector.X, vector.Y, vector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3MultiplyLeftOperatorTest()
        {
            var vector = 5 * new Vector3(20, 10, 13);
            var expected = (100, 50, 65);
            var actual = (vector.X, vector.Y, vector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3MultiplyRightOperatorTest1()
        {
            var vector = new Vector3(20, 10, 13) * 5;
            var expected = (100, 50, 65);
            var actual = (vector.X, vector.Y, vector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3DivisionOperatorTest()
        {
            var vector = new Vector3(20, 10, 15) / 5;
            var expected = (4, 2, 3);
            var actual = (vector.X, vector.Y, vector.Z);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vector3EqualOperatorTest()
        {
            var vector1 = new Vector3(20, 10, 15);
            var vector2 = new Vector3(20, 10, 15);
            Assert.True(vector1 == vector2);
        }
        [Fact]
        public void Vector3NotEqualOperatorTest()
        {
            var vector1 = new Vector3(13, 4, 15);
            var vector2 = new Vector3(20, 10, 15);
            Assert.True(vector1 != vector2);
        }
        [Fact]
        public void Vector3EqualsTest()
        {
            var vector1 = new Vector3(20, 10, 15);
            var vector2 = new Vector3(20, 10, 15);
            Assert.True(vector1.Equals(vector2));
        }
        [Fact]
        public void Vector3GetHashCodeTest()
        {
            var vector1 = new Vector3(20, 10, 15);
            var vector2 = new Vector3(20, 10, 15);
            Assert.True(vector1.GetHashCode() == vector2.GetHashCode());
        }
        [Fact]
        public void Vector3ToStringTest()
        {
            var vector = new Vector3(20, 10, 15);
            var expected = "X = 20 Y = 10 Z = 15";
            Assert.True(vector.ToString() == expected);
        }
    }
}

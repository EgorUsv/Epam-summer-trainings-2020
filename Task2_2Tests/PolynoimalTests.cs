using System;
using System.Linq;
using Task2_2;
using Xunit;

namespace Task2_2Tests
{
    public class PolynoimalTests
    {
        [Fact]
        public void PolynomalTest()
        {
            Polynomial polynomal = new Polynomial(4, 6, 12);
            var expected = new double[] { 12, 6, 4 };
            var actual = polynomal.Coefficients;
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
        [Fact]
        public void PolynomalAddOperatorTest()
        {
            var polynomal1 = new Polynomial(4, 6, 12);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(7, 6, 54);
            var actual = polynomal1 + polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalSubtractOperatorTest()
        {
            var polynomal1 = new Polynomial(4, 6, 12);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(1, 6, -30);
            var actual = polynomal1 - polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalSubtractOperatorTest1()
        {
            var polynomal1 = new Polynomial(4, 6, 12, 15);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(4, 3, 12, -27);
            var actual = polynomal1 - polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalSubtractOperatorTest2()
        {
            var polynomal1 = new Polynomial(4, 6, 12, 15);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(4, -3, -12, 27);
            var actual = polynomal2 - polynomal1;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalDivisionOperatorTest1()
        {
            var polynomal1 = new Polynomial(6, 6, 12);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(2, 0, 0);
            var actual = polynomal1 / polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalDivisionOperatorTest2()
        {
            var polynomal1 = new Polynomial(3, 12);
            var polynomal2 = new Polynomial(3, 0, 42);
            var expected = new Polynomial(0);
            var actual = polynomal1 / polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalDivisionOperatorTest3()
        {
            var polynomal1 = new Polynomial(5, 12, 0, -16, -17);
            var polynomal2 = new Polynomial(5, 7);
            var expected = new Polynomial(1, 1, -1.4, -1.24);
            var actual = polynomal1 / polynomal2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalDivisionNumberOperatorTest()
        {
            var polynomal1 = new Polynomial(5, 12, 0, -16, -17);
            var expected = new Polynomial(1, 2.4, 0, -3.2, -3.4);
            var actual = polynomal1 / 5;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalMultiplyOperatorTest()
        {
            var polynomal1 = new Polynomial(5, 12, 0, -16, -17);
            var polynomal2 = new Polynomial(1, 2, 4, -3, 4);
            var actual = polynomal1 * polynomal2;
            var expected = new Polynomial(5, 22, 44, 17, -65, -50, -20, -13, -68);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalMultiplyOperatorTest1()
        {
            var polynomal1 = new Polynomial(5, 12, 45, 3, 2);
            var polynomal2 = new Polynomial(1, 2, 10, -3);
            var actual = polynomal1 * polynomal2;
            var expected = new Polynomial(5, 22, 119, 198, 422, -101, 11, -6);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalMultiplyOperatorTest3()
        {
            var polynomal1 = new Polynomial(0);
            var polynomal2 = new Polynomial(5, 12, 45, 3, 2);
            var actual = polynomal1 * polynomal2;
            var expected = new Polynomial(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalMultiplyByNumberTest()
        {
            var polynomal1 = new Polynomial(5, 12, 45, 3, 2);
            var actual = polynomal1 * 4;
            var expected = new Polynomial(20, 48, 180, 12, 8);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomalEqualsOperatorTest()
        {
            var polynomal1 = new Polynomial(5, 12, 45, 3, 2);
            var polynomal2 = new Polynomial(5, 12, 45, 3, 2);
            Assert.True(polynomal1 == polynomal2);
        }
        [Fact]
        public void PolynomalNotEqualsOperatorTest()
        {
            var polynomal1 = new Polynomial(5, 42, 45, 3, 2);
            var polynomal2 = new Polynomial(5, 12, 45, 3, 2);
            Assert.True(polynomal1 != polynomal2);
        }
        [Fact]
        public void PolynomalGetHashCodeTest()
        {
            var polynomal1 = new Polynomial(5, 42, 45, 3, 2);
            var polynomal2 = new Polynomial(5, 42, 45, 3, 2);
            Assert.Equal(polynomal1.GetHashCode(), polynomal2.GetHashCode());
        }
    }
}

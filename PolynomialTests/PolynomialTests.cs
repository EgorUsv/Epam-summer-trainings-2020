using Polynomial;
using System;
using System.Linq;
using Xunit;

namespace PolynomialTests
{
    public class PolynomialTests
    {
        [Fact]
        public void PolynomialTest()
        {
            MyPolynomial Polynomial = new MyPolynomial(4, 6, 12);
            var expected = new double[] { 12, 6, 4 };
            var actual = Polynomial.Coefficients;
            Assert.True(Enumerable.SequenceEqual(expected, actual));
        }
        [Fact]
        public void PolynomialAddOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(4, 6, 12);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(7, 6, 54);
            var actual = Polynomial1 + Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialSubtractOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(4, 6, 12);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(1, 6, -30);
            var actual = Polynomial1 - Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialSubtractOperatorTest1()
        {
            var Polynomial1 = new MyPolynomial(4, 6, 12, 15);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(4, 3, 12, -27);
            var actual = Polynomial1 - Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialSubtractOperatorTest2()
        {
            var Polynomial1 = new MyPolynomial(4, 6, 12, 15);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(4, -3, -12, 27);
            var actual = Polynomial2 - Polynomial1;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialDivisionOperatorTest1()
        {
            var Polynomial1 = new MyPolynomial(6, 6, 12);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(2, 0, 0);
            var actual = Polynomial1 / Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialDivisionOperatorTest2()
        {
            var Polynomial1 = new MyPolynomial(3, 12);
            var Polynomial2 = new MyPolynomial(3, 0, 42);
            var expected = new MyPolynomial(0);
            var actual = Polynomial1 / Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialDivisionOperatorTest3()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 0, -16, -17);
            var Polynomial2 = new MyPolynomial(5, 7);
            var expected = new MyPolynomial(1, 1, -1.4, -1.24);
            var actual = Polynomial1 / Polynomial2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialDivisionNumberOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 0, -16, -17);
            var expected = new MyPolynomial(1, 2.4, 0, -3.2, -3.4);
            var actual = Polynomial1 / 5;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialMultiplyOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 0, -16, -17);
            var Polynomial2 = new MyPolynomial(1, 2, 4, -3, 4);
            var actual = Polynomial1 * Polynomial2;
            var expected = new MyPolynomial(5, 22, 44, 17, -65, -50, -20, -13, -68);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialMultiplyOperatorTest1()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 45, 3, 2);
            var Polynomial2 = new MyPolynomial(1, 2, 10, -3);
            var actual = Polynomial1 * Polynomial2;
            var expected = new MyPolynomial(5, 22, 119, 198, 422, -101, 11, -6);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialMultiplyOperatorTest3()
        {
            var Polynomial1 = new MyPolynomial(0);
            var Polynomial2 = new MyPolynomial(5, 12, 45, 3, 2);
            var actual = Polynomial1 * Polynomial2;
            var expected = new MyPolynomial(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialMultiplyByNumberTest()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 45, 3, 2);
            var actual = Polynomial1 * 4;
            var expected = new MyPolynomial(20, 48, 180, 12, 8);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void PolynomialEqualsOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(5, 12, 45, 3, 2);
            var Polynomial2 = new MyPolynomial(5, 12, 45, 3, 2);
            Assert.True(Polynomial1 == Polynomial2);
        }
        [Fact]
        public void PolynomialNotEqualsOperatorTest()
        {
            var Polynomial1 = new MyPolynomial(5, 42, 45, 3, 2);
            var Polynomial2 = new MyPolynomial(5, 12, 45, 3, 2);
            Assert.True(Polynomial1 != Polynomial2);
        }
        [Fact]
        public void PolynomialGetHashCodeTest()
        {
            var Polynomial1 = new MyPolynomial(5, 42, 45, 3, 2);
            var Polynomial2 = new MyPolynomial(5, 42, 45, 3, 2);
            Assert.Equal(Polynomial1.GetHashCode(), Polynomial2.GetHashCode());
        }
    }
}

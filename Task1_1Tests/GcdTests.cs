using NUnit.Framework;
using TaskOne;

namespace Task1_1Tests
{
    public class Tests
    {
        [Test]
        public void BaseGcdTest()
        {
            var testArray = new int[] { 1475, 145 };
            var actual = new Gcd().GetGcd(testArray[0], testArray[1]);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdOverloadedTest1()
        {
            var testArray = new int[] { 16, 140, 164 };
            var actual = new Gcd().GetGcd(testArray[0], testArray[1], testArray[2]);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdOverloadedTest2()
        {
            var testArray = new int[] { 16, 140, 164, 111 };
            var actual = new Gcd().GetGcd(testArray[0], testArray[1], testArray[2], testArray[3]);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdOverloadedTest3()
        {
            var testArray = new int[] { 16, 140, 164, 186, 14 };
            var actual = new Gcd()
                .GetGcd(testArray[0], testArray[1], testArray[2], testArray[3], testArray[4]);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdByStainTest1()
        {
            var testArray = new int[] { 1475, 145 };
            var actual = new Gcd().GetGcdByStein(testArray[0], testArray[1], out _);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdByStainTest2()
        {
            var testArray = new int[] { 0, 145 };
            var actual = new Gcd().GetGcdByStein(testArray[0], testArray[1], out _);
            var expected = 145;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdByStainTest3()
        {
            var testArray = new int[] { 145, 0 };
            var actual = new Gcd().GetGcdByStein(testArray[0], testArray[1], out _);
            var expected = 145;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BaseGcdByStainTest4()
        {
            var testArray = new int[] { 1, 140 };
            var actual = new Gcd().GetGcdByStein(testArray[0], testArray[1], out _);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
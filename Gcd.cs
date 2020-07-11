using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    /// <summary>
    /// This class is used to calculate the gcd
    /// </summary>
    public class Gcd
    {
        /// <summary>
        /// The method uses the Euclidean algorithm to calculate the GCD of 
        /// 2 integer numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public virtual int GetGcd(int num1, int num2)
        {
            while (num2 != 0)
            {
                int tempNum = num2;
                num2 = num1 % num2;
                num1 = tempNum;
            }
            return num1;
        }
        /// <summary>
        /// The method uses the Euclidean algorithm to calculate the GCD of 
        /// 3 integer numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <returns></returns>
        public int GetGcd(int num1, int num2, int num3)
        {
            return GetGcd(num3, GetGcd(num1, num2));
        }
        /// <summary>
        /// The method uses the Euclidean algorithm to calculate the GCD of 
        /// 4 integer numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <returns></returns>
        public int GetGcd(int num1, int num2, int num3, int num4)
        {
            return GetGcd(GetGcd(num1, num2, num3), num4);
        }
        /// <summary>
        /// The method uses the Euclidean algorithm to calculate the GCD of 
        /// 5 integer numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <returns></returns>
        public int GetGcd(int num1, int num2, int num3, int num4, int num5)
        {
            return GetGcd(GetGcd(num1, num2, num3, num4), num5);
        }
        /// <summary>
        /// The method uses the Stein's algorithm to calculate the GCD of 
        /// 2 numbers.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetGcdByStein(int num1, int num2, out Stopwatch time)
        {
            time = new Stopwatch();
            time.Start();
            int shift = 0;
            if (num1 == 0)
                return num2;
            if (num2 == 0)
                return num1;
            while (((num1 | num2) & 1) == 0)
            {
                shift++;
                num1 >>= 1;
                num2 >>= 1;
            }
            while ((num1 & 1) == 0)
                num1 >>= 1;
            do
            {
                while ((num2 & 1) == 0)
                    num2 >>= 1;
                if (num1 > num2)
                    Swap(ref num1, ref num2);
                num2 -= num1;
            } while (num2 != 0);
            num1 <<= shift;
            time.Stop();
            return num1;
        }
        /// <summary>
        /// Swaps two integer elements.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        private void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}

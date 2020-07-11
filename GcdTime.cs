using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
    public class GcdTime : Gcd
    {
        public override int GetGcd(int num1, int num2)
        {
            if (num1 == 0 || num2 == 0)
                return num1 == 0 ? num2 : num1;
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }
            return num1;
        }
        public Stopwatch GetBaseGcdTime(int num1, int num2)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            base.GetGcd(num1, num2);
            time.Stop();
            return time;
        }
        public Stopwatch GetGcdTime(int num1, int num2)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            GetGcd(num1, num2);
            time.Stop();
            return time;
        }
        public Dictionary<string, Stopwatch> GetCalculationTime(int num1, int num2)
        {
            GetGcdByStein(num1, num2, out Stopwatch simpsonTime);
            var results = new Dictionary<string, Stopwatch>(3);
            results.Add("Euclid time", GetBaseGcdTime(num1, num2));
            results.Add("Substruction time", GetGcdTime(num1, num2));
            results.Add("Simpson time", simpsonTime);
            return results;
        }
    }
}

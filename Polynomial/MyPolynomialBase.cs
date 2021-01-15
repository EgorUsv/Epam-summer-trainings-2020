using System;
using System.Collections.Generic;
using System.Linq;

namespace Polynomial
{
    /// <summary>
    /// Represents a polynomial of one variable.
    /// </summary>
    public partial class MyPolynomial
    {
        /// <summary>
        /// Contains polynomial coefficients.
        /// </summary>
        public double[] Coefficients { get; private set; }
        /// <summary>
        /// Creates a polynomial. Сoefficients range from the highest degree 
        /// of the variable to the lowest variable.
        /// </summary>
        /// <param name="coefs"></param>
        public MyPolynomial(params double[] coefs)
        {
            if (coefs != null)
                Coefficients = ZeroRemoval(coefs).Reverse().ToArray();
            else
                Coefficients = new double[] { 0 };
        }
        /// <summary>
        /// Sum two polynomials.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator +(MyPolynomial left, MyPolynomial right)
        {
            var list = new List<double>();
            for (int i = 0, j = 0; i < left.Coefficients.Length || j < right.Coefficients.Length; i++, j++)
            {
                if (i >= left.Coefficients.Length)
                    list.Add(right.Coefficients[j]);
                if (j >= right.Coefficients.Length)
                    list.Add(left.Coefficients[i]);
                if (i < left.Coefficients.Length && j < right.Coefficients.Length)
                    list.Add(left.Coefficients[i] + right.Coefficients[j]);
            }
            list.Reverse();
            return new MyPolynomial(list.ToArray());
        }
        /// <summary>
        /// Subtracts the first polynomial from the second.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator -(MyPolynomial left, MyPolynomial right)
        {
            var list = new List<double>();
            for (int i = 0, j = 0; i < left.Coefficients.Length || j < right.Coefficients.Length; i++, j++)
            {
                if (i >= left.Coefficients.Length)
                    list.Add(right.Coefficients[j]);
                if (j >= right.Coefficients.Length)
                    list.Add(left.Coefficients[i]);
                if (i < left.Coefficients.Length && j < right.Coefficients.Length)
                    list.Add(left.Coefficients[i] - right.Coefficients[j]);
            }
            list.Reverse();
            return new MyPolynomial(list.ToArray());
        }
        /// <summary>
        /// Divides the first polynomial by the second.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator /(MyPolynomial left, MyPolynomial right)
        {
            if (right.Coefficients.Length > left.Coefficients.Length)
                return new MyPolynomial(new double[] { 0 });
            if (right.Coefficients == new double[] { 0 })
                throw new DivideByZeroException();
            if (left.Coefficients.Length == right.Coefficients.Length)
            {
                double[] newCoefficients = new double[right.Coefficients.Length];
                newCoefficients[0] = left.Coefficients.Last() / right.Coefficients.Last();
                return new MyPolynomial(newCoefficients);
            }
            else
                return DividePolynomals(left, right);
        }
        /// <summary>
        /// Divides a polynomial by a double value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator /(MyPolynomial left, double right)
        {
            if (right == 0)
                throw new DivideByZeroException();
            for (int i = 0; i < left.Coefficients.Length; i++)
                left.Coefficients[i] /= right;
            return left;
        }
        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator *(MyPolynomial left, MyPolynomial right)
        {
            double[] bigArray, smallArray;
            double[,] sumMatrix;
            (bigArray, smallArray, sumMatrix) = GetInitArrays(left, right);
            MultiplyArrays(bigArray, smallArray, ref sumMatrix);
            return new MyPolynomial(SumMatrixCol(ref sumMatrix));
        }
        /// <summary>
        /// multiplies a polynomial by a float value.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MyPolynomial operator *(MyPolynomial left, double right)
        {
            for (int i = 0; i < left.Coefficients.Length; i++)
                left.Coefficients[i] *= right;
            return left;
        }
        /// <summary>
        /// Determining the equality of two given objects. 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>
        /// Returns true, if polynomial coefficients are equal.
        /// </returns>
        public static bool operator ==(MyPolynomial left, MyPolynomial right)
        {
            if (Enumerable.SequenceEqual(left.Coefficients, right.Coefficients))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Determining the inequality of two given objects. 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns> 
        /// Returns true, if polynomial coefficients are not equal.
        /// </returns>
        public static bool operator !=(MyPolynomial left, MyPolynomial right)
        {
            if (Enumerable.SequenceEqual(left.Coefficients, right.Coefficients))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Determine whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Returns true if the object is a polynomial and has the same coefficients.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is MyPolynomial && Enumerable
                .SequenceEqual((obj as MyPolynomial).Coefficients, Coefficients))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return Coefficients.GetHashCode();
        }
        /// <summary>
        /// Returns a string that represents a polynomial.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            for (int i = Coefficients.GetUpperBound(0); i >= 0; i--)
            {
                if (i >= 2)
                    result += $"{(Coefficients[i] >= 0 ? "+" : "")}{Coefficients[i]}*x^{i}";
                if (i == 1)
                    result += $"{(Coefficients[i] >= 0 ? "+" : "")}{Coefficients[i]}*x";
                if (i == 0)
                    result += $"{(Coefficients[i] >= 0 ? "+" : "")}{Coefficients[i]}";
            }
            return result;
        }
    }
}

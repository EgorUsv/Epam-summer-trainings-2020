using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    public class Polynomal
    {
        public double[] Coefficients { get; private set; }
        public Polynomal(params double[] coefs)
        {
            if (coefs != null)
                Coefficients = ZeroRemoval(coefs).Reverse().ToArray();
            else
                Coefficients = new double[] { 0 };
        }
        public static Polynomal operator +(Polynomal left, Polynomal right)
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
            return new Polynomal(list.ToArray());
        }
        public static Polynomal operator -(Polynomal left, Polynomal right)
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
            return new Polynomal(list.ToArray());
        }
        public static Polynomal operator /(Polynomal left, Polynomal right)
        {
            if (right.Coefficients.Length > left.Coefficients.Length)
                return new Polynomal(new double[] { 0 });
            if (right.Coefficients == new double[] { 0 })
                throw new DivideByZeroException();
            if (left.Coefficients.Length == right.Coefficients.Length)
            {
                double[] newCoefficients = new double[right.Coefficients.Length];
                newCoefficients[0] = left.Coefficients.Last() / right.Coefficients.Last();
                return new Polynomal(newCoefficients);
            }
            else
                return DividePolynomals(left, right);
        }
        public static Polynomal operator /(Polynomal left, double right)
        {
            if (right == 0)
                throw new DivideByZeroException();
            for (int i = 0; i < left.Coefficients.Length; i++)
                left.Coefficients[i] /= right;
            return left;
        }
        public static Polynomal operator *(Polynomal left, Polynomal right)
        {
            double[] bigArray, smallArray;
            double[,] sumMatrix;
            (bigArray, smallArray, sumMatrix) = GetInitArrays(left, right);
            MultiplyArrays(bigArray, smallArray, ref sumMatrix);
            return new Polynomal(SumMatrixCol(ref sumMatrix));
        }
        public static Polynomal operator *(Polynomal left, double right)
        {
            for (int i = 0; i < left.Coefficients.Length; i++)
                left.Coefficients[i] *= right;
            return left;
        }
        public static bool operator ==(Polynomal left, Polynomal right)
        {
            if (Enumerable.SequenceEqual(left.Coefficients, right.Coefficients))
                return true;
            else
                return false;
        }
        public static bool operator !=(Polynomal left, Polynomal right)
        {
            if (Enumerable.SequenceEqual(left.Coefficients, right.Coefficients))
                return false;
            else
                return true;
        }
        public override bool Equals(object obj)
        {
            if (obj is Polynomal && Enumerable
                .SequenceEqual((obj as Polynomal).Coefficients, Coefficients))
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
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
        private static void MultiplyArrays(double[] array1, double[] array2, ref double[,] result)
        {
            int row = 0, column = 0;
            foreach (double element1 in array1)
            {
                foreach (double element2 in array2)
                {
                    result[row, column] = element2 * element1;
                    column++;
                }
                row++;
                column -= array2.Length - 1;
            }
        }
        private static (double[], double[], double[,]) GetInitArrays(Polynomal left, Polynomal right)
        {
            if (left.Coefficients.Length > right.Coefficients.Length)
            {
                double[,] matrix = new double[right.Coefficients.Length,
                    left.Coefficients.Length + right.Coefficients.Length - 1];
                return (right.Coefficients, left.Coefficients, matrix);
            }
            else
            {
                double[,] matrix = new double[left.Coefficients.Length,
                    right.Coefficients.Length + left.Coefficients.Length - 1];
                return (left.Coefficients, right.Coefficients, matrix);
            }
        }
        private static double[] SumMatrixCol(ref double[,] sumMatrix)
        {
            var result = new double[sumMatrix.GetLength(1)];
            for (int i = 0; i < sumMatrix.GetLength(1); i++)
                for (int j = 0; j < sumMatrix.GetLength(0); j++)
                    result[i] += sumMatrix[j, i];
            return result.Reverse().ToArray();
        }
        private static Polynomal DividePolynomals(Polynomal left, Polynomal right)
        {
            double[] leftCoeffs = left.Coefficients.Reverse().ToArray();
            double[] rightCoeffs = right.Coefficients.Reverse().ToArray();
            List<double> result = new List<double>();
            for (int index = 0; index < left.Coefficients.GetUpperBound(0);)
            {
                result.Add(Math.Round(leftCoeffs[index] / rightCoeffs[0], 4));
                for (int i = 0, j = index; i < rightCoeffs.Length; i++, j++)
                    leftCoeffs[j] -= result.Last() * rightCoeffs[i];
                index++;
            }
            return new Polynomal(result.ToArray());
        }
        private static double[] ZeroRemoval(double[] array)
        {
            var result = array.SkipWhile(x => x == 0).TakeWhile((x, i) => i < array.Length).ToArray();
            return result.Length == 0 ? new double[] { 0 } : result;
        }
    }
}

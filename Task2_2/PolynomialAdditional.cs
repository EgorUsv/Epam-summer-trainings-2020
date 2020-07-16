using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    public partial class Polynomial
    {
        /// <summary>
        /// Multiplies the two arrays. Returns a ready-made matrix.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="result"></param>
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
        /// <summary>
        /// Defines the largest polynomial in degree and initializes the necessary data.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static (double[], double[], double[,]) GetInitArrays(Polynomial left, Polynomial right)
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
        /// <summary>
        /// Sums the matrix by columns
        /// </summary>
        /// <param name="sumMatrix"></param>
        /// <returns></returns>
        private static double[] SumMatrixCol(ref double[,] sumMatrix)
        {
            var result = new double[sumMatrix.GetLength(1)];
            for (int i = 0; i < sumMatrix.GetLength(1); i++)
                for (int j = 0; j < sumMatrix.GetLength(0); j++)
                    result[i] += sumMatrix[j, i];
            return result.Reverse().ToArray();
        }
        /// <summary>
        /// Divides the left polynomial by the right one
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static Polynomial DividePolynomals(Polynomial left, Polynomial right)
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
            return new Polynomial(result.ToArray());
        }
        /// <summary>
        /// Removes zero coefficients from the beginning of the array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static double[] ZeroRemoval(double[] array)
        {
            var result = array.SkipWhile(x => x == 0).TakeWhile((x, i) => i < array.Length).ToArray();
            return result.Length == 0 ? new double[] { 0 } : result;
        }
    }
}

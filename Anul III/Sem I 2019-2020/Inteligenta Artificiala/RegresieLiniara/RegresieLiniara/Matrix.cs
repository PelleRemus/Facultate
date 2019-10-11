using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegresieLiniara
{
    public class Matrix
    {
        double[,] matrix;
        static MatrixHelper helper = new MatrixHelper();

        public Matrix(int n, int m)
        {
            matrix = new double[n, m];
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return helper.Substraction(a, b);
        } 

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return helper.MatrixMultiplication(a, b);
        }

        public int GetLength(int n)
        {
            return matrix.GetLength(n);
        }

        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
    }
}

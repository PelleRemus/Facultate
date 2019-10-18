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

        public Matrix ElementMultiplication(Matrix toMultiply)
        {
            Matrix toReturn = new Matrix(this.GetLength(0), this.GetLength(1));
            for (int i = 0; i < this.GetLength(0); i++)
                for (int j = 0; j < this.GetLength(1); j++)
                {
                    toReturn[i, j] = toMultiply[i, j] * matrix[i, j];
                }
            return toReturn;
        }

        public Matrix GetTranspose()
        {
            return helper.Transpose(matrix);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return helper.Substraction(a, b);
        } 

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return helper.MatrixMultiplication(a, b);
        }

        public static Matrix operator /(Matrix a, double m)
        {
            return helper.Divide(a, m);
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

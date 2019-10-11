using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegresieLiniara
{
    public class MatrixHelper
    {
        public Matrix MatrixMultiplication(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.GetLength(0), b.GetLength(1));

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    double value = 0;
                    for (int q = 0; q < a.GetLength(1); q++)
                    {
                        value += a[i, q] * b[q, j];
                    }
                    c[i, j] = value;
                }
            }

            return c;
        }

        public Matrix Substraction(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.GetLength(0), a.GetLength(1));

            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }

            return c;
        }
    }
}

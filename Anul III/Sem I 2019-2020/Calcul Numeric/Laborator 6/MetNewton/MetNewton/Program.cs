using System;

namespace MetNewton
{
    class Program
    {
        static double[,] a, inversa, f;
        static double[] x, xn;
        static double epsilon;
        public static int n = 0;

        static void Main(string[] args)
        {
            x = new double[3];
            xn = new double[3];
            a = new double[3, 3];
            inversa = new double[3, 3];
            f = new double[3, 1];

            xn[0] = 0; xn[1] = 0; xn[2] = 0;
            epsilon = 1e-10;
            do
            {
                n++;
                x[0] = xn[0]; x[1] = xn[1]; x[2] = xn[2];

                a[0, 0] = g1(x[0], x[1], x[2]); a[0, 1] = g2(x[0], x[1], x[2]); a[0, 2] = g3(x[0], x[1], x[2]);
                a[1, 0] = g4(x[0], x[1], x[2]); a[1, 1] = g5(x[0], x[1], x[2]); a[1, 2] = g6(x[0], x[1], x[2]);
                a[2, 0] = g7(x[0], x[1], x[2]); a[2, 1] = g8(x[0], x[1], x[2]); a[2, 2] = g9(x[0], x[1], x[2]);
                
                MetEliminariiGauss();
                f[0, 0] = f1(x[0], x[1], x[2]); f[1, 0] = f2(x[0], x[1], x[2]); f[2, 0] = f3(x[0], x[1], x[2]);

                xn = Dif(x, Prod(inversa, f));
            } while (Math.Max(Math.Max(Math.Abs(xn[0] - x[0]), Math.Abs(xn[1] - x[1])), xn[2] - x[2]) > epsilon);

            Console.WriteLine("Raspunsul este ({0}, {1}, {2}) si a fost determinat dupa {3} iteratii.", xn[0], xn[1], xn[2], n);
            Console.ReadKey();
        }

        static void MetMatriceiAdjuncte()
        {
            double determinant = Determinant(a);
            if (determinant == 0)
            {
                Console.WriteLine("Matricea are determinantul 0, deci nu are inversa.");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inversa[i, j] = Math.Pow(-1, i + j) * Determinant(Scurtare(a, j, i)) / determinant;
        }
        static double Determinant(double[,] matrix)
        {
            double det = 0;
            if (matrix.GetLength(0) == 2)
                det += matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else
                for (int i = 0; i < matrix.GetLength(0); i++)
                    det += Math.Pow(-1, i) * matrix[0, i] * Determinant(Scurtare(matrix, 0, i));
            return det;
        }
        static double[,] Scurtare(double[,] matrix, int k, int l)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            double[,] aux = new double[n - 1, m - 1];
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < m - 1; j++)
                {
                    if (i < k && j < l)
                        aux[i, j] = matrix[i, j];
                    if (i < k && j >= l)
                        aux[i, j] = matrix[i, j + 1];
                    if (i >= k && j < l)
                        aux[i, j] = matrix[i + 1, j];
                    if (i >= k && j >= l)
                        aux[i, j] = matrix[i + 1, j + 1];
                }
            return aux;
        }

        static void MetEliminariiGauss()
        {
            for (int i = 0; i < n; i++)
                inversa[i, i] = 1;

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                {
                    if (i == k)
                        continue;
                    double c = -a[i, k] / a[k, k];
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] += a[k, j] * c;
                        inversa[i, j] += inversa[k, j] * c;
                    }
                }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    inversa[i, j] /= a[i, i];
                a[i, i] = 1;
            }
        }

        static double[,] Prod(double[,] a, double[,] b)
        {
            double[,] c = new double[a.GetLength(0), b.GetLength(1)];

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
        static double[] Dif(double[] a, double[,] b)
        {
            double[] c = new double[3];
            for (int i = 0; i < 3; i++)
                c[i] = a[i] - b[i, 0];
            return c;
        }

        static double f1(double x, double y, double z)
        {
            return 2 * x * x - y * z - 5 * x + 1;
        }
        static double f2(double x, double y, double z)
        {
            return y * y - 2 * x - Math.Log(z);
        }
        static double f3(double x, double y, double z)
        {
            return z * z - x * y - 2 * z - 2;
        }

        static double g1(double x, double y, double z)
        {
            return 4 * x - 5;
        }
        static double g2(double x, double y, double z)
        {
            return -z;
        }
        static double g3(double x, double y, double z)
        {
            return -y;
        }
        static double g4(double x, double y, double z)
        {
            return -2;
        }
        static double g5(double x, double y, double z)
        {
            return 2 * y;
        }
        static double g6(double x, double y, double z)
        {
            return -1 / z;
        }
        static double g7(double x, double y, double z)
        {
            return -y;
        }
        static double g8(double x, double y, double z)
        {
            return -x;
        }
        static double g9(double x, double y, double z)
        {
            return 2 * z - 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodaMatriceiInverse
{
    class Program
    {
        static int n;
        static double[,] a, inversa;
        static double[] b, x;

        static void Main(string[] args)
        {
            n = 3;
            a = new double[,] {
                { 1, 1, 1 },
                { 1, 2, 3 },
                { 1, 3, 6 }
            };
            b = new double[] { 9, -1, -8 };
            inversa = new double[n, n];
            x = new double[n];

            MetMatriceiAdjuncte();
            

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    x[i] += b[j] * inversa[i, j];
            AfisareMatrice(inversa);
            Afisare(x);
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
                    if (i != k)
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] -= a[i, k] * a[k, j];
                            inversa[i, j] -= a[i, k] * inversa[k, j];
                        }
        }

        static void Afisare(double[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }

        static void AfisareMatrice(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(0); j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriceScurtata
{
    class Program
    {
        static Random r = new Random();
        static int n, m;

        static void Main(string[] args)
        {
            n = r.Next(10, 15);
            m = n;
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = r.Next(10);
            Afisare(matrix);
            int k = n, l = m;
            matrix = Scurtare(k, l, matrix);
            Afisare(matrix);
            //Console.WriteLine(Determinant(matrix));
            Console.ReadKey();
        }

        static void Afisare(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] Scurtare(int k, int l, int[,] matrix)
        {
            int[,] aux = new int[n - 1, m - 1];
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

        static float Determinant(int[,] matrix)
        {
            float det = 0;
            if (matrix.GetLength(0) == 2)
                det += matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else
                for (int i = 0; i < matrix.GetLength(0); i++)
                    det += (float)Math.Pow(-1, i) * matrix[0, i] * Determinant(Scurtare(0, i, matrix));
            return det;
        }
    }
}

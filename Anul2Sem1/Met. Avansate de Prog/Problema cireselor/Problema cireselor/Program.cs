using System;
using System.Collections.Generic;

namespace Problema_cireselor
{
    class Program
    {
        static int[,] matrix, sum;
        static int n = 7, m = 8;

        static void Main(string[] args)
        {
            Random r = new Random();
            matrix = new int[n + 1, m + 1];
            sum = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                sum[i, 0] = 0;
            for (int i = 0; i <= m; i++)
                sum[0, i] = 0;

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                {
                    matrix[i, j] = r.Next(10);
                    sum[i, j] = matrix[i, j] + sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1];
                }
            Afisare(matrix);
            Afisare(sum);

            List<Test> tests = new List<Test>();
            tests.Add(new Test(1, 1, 1, 2));
            tests.Add(new Test(1, 1, 3, 5));
            tests.Add(new Test(2, 3, 5, 5));

            for (int i = 0; i < tests.Count; i++)
                Console.WriteLine(Calcul(tests[i]));
            Console.ReadKey();
        }

        static int Calcul(Test t)
        {
            return sum[t.i2, t.j2] - sum[t.i2, t.j1 - 1] - sum[t.i1 - 1, t.j2] + sum[t.i1 - 1, t.j1 - 1];
        }

        static void Afisare(int[,] aux)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                    Console.Write(aux[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

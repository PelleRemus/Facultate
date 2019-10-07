using System;

namespace SistSuperiorTriunghiular
{
    class Program
    {
        static int n;
        static double[,] a;
        static double[] x, b;

        static void Main(string[] args)
        {
            n = 4;
            a = new double[,]{
                { 1, 1, 1, 1 },
                { 0, -2, 3, -1},
                { 0, 0, 2, 3 },
                { 0, 0, 0, 4 }
            };
            b = new double[] { 10, 1, 18, 16 };
            x = new double[n];

            for (int k = n - 1; k >= 0; k--)
            {
                double s = 0;
                for (int i = k + 1; i < n; i++)
                    s += a[k, i] * x[i];
                x[k] = (b[k] - s) / a[k, k];
            }

            for (int i = 0; i < n; i++)
                Console.Write(x[i] + " ");
            Console.ReadKey();
        }
    }
}

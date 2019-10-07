using System;

namespace SistInferiorTriunghiulare
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
                { 4, 0, 0, 0 },
                { 3, 2, 0, 0 },
                { -1, 3, -2, 0 },
                { 1, 1, 1, 1 }
            };
            b = new double[] { 16, 18, 1, 10 };
            x = new double[n];

            for (int k = 0; k < n; k++)
            {
                double s = 0;
                for (int i = 0; i < k; i++)
                    s += a[k, i] * x[i];
                x[k] = (b[k] - s) / a[k, k];
            }

            for (int i = 0; i < n; i++)
                Console.Write(x[i] + " ");
            Console.ReadKey();
        }
    }
}

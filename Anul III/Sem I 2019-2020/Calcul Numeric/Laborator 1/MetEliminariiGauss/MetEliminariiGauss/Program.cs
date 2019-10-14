using System;

namespace MetEliminariiGauss
{
    class Program
    {
        static int n;
        static double[,] a;
        static double[] x, b;

        static void Main(string[] args)
        {
            n = 3;
            a = new double[,] {
                { 10, 2, -1 },
                { -2, -5, 1 },
                { -3, 1, -5 }
            };
            b = new double[] { 9, -1, -8 };
            x = new double[n];

            AfisareMatrice();
            for (int k = 0; k < n - 1; k++)
            {
                if (a[k, k] != 0)
                {
                    double p = a[k, k];
                    for (int j = k; j < n; j++)
                        a[k, j] /= p;
                    b[k] /= p;

                    for (int i = k + 1; i < n; i++)
                    {
                        for (int j = k + 1; j < n; j++)
                            a[i, j] -= a[k, j] * a[i, k];
                        b[i] -= b[k] * a[i, k];
                        a[i, k] -= a[k, k] * a[i, k];
                    }
                    AfisareMatrice();
                }
                else
                {
                    Console.WriteLine("Can not divide by 0.");
                    Console.ReadKey();
                    return;
                }
            }
            SistSuperiorTriunghiular();
            Afisare();
            Console.ReadKey();
        }

        static void SistSuperiorTriunghiular()
        {
            for (int k = n - 1; k >= 0; k--)
            {
                double s = 0;
                for (int i = k + 1; i < n; i++)
                    s += a[k, i] * x[i];
                x[k] = (b[k] - s) / a[k, k];
            }
        }

        static void Afisare()
        {
            for (int i = 0; i < n; i++)
                Console.Write(x[i] + " ");
            Console.WriteLine();
        }

        static void AfisareMatrice()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine("= " + b[i]);
            }
            Console.WriteLine();
        }
    }
}

using System;

namespace FormulaTrapezCorectat
{
    class Program
    {
        static int n;
        static double a, b, T;
        static double[] x;

        static void Main(string[] args)
        {
            double erf1 = 0.8427007929497;
            double erf2 = 0.9953222650189;
            double erf25 = 0.999593047982;

            a = 0; b = 2.5; n = 1000;
            x = new double[n + 1];
            for (int i = 0; i <= n; i++)
                x[i] = a + (i * (b - a)) / n;
            double s = 0;
            for (int i = 1; i <= n; i++)
                s += f(x[i - 1]) + f(x[i]);
            T = s * ((b - a) / (2 * n)) - ((b - a) * (b - a) / (12 * n * n)) * (df(b) - df(a));
            Console.WriteLine("Pentru {0} subintervale, aproximarea este {1}.\n" +
                "Rezultatul corect este {2}.\n" +
                "Eroarea este {3}.", n, T, erf25, Math.Abs(erf25 - T));

            //ex 3
            //Console.WriteLine("Pamantul face {0} milioane de kilometri intr-un an", t);
            Console.ReadKey();
        }

        static double f(double x)
        {
            //ex 1
            //return 4.0 / (x * x + 1);

            //ex 2, erf (error function)
            return (2.0 / Math.Sqrt(Math.PI)) * Math.Exp(-x * x);

            //ex 3 traiectoria Pamantului in jurul soarelui
            double c = 149.6, E = 0.016729;
            return 4 * c * Math.Sqrt(1 - Math.Pow(E, 2) * Math.Sin(x));
        }

        static double df(double x)
        {
            //ex 1
            //return -8 * x / ((x * x + 1) * (x * x + 1));

            //ex 2, erf (error function)
            return -4 * x / Math.Sqrt(Math.PI) * Math.Exp(-x * x);

            //ex 3 traiectoria Pamantului in jurul soarelui
            double c = 149.6, E = 0.016729;
            return -4 * c * E * E * Math.Sin(x) * Math.Cos(x)
                / Math.Sqrt(1 - E * E * Math.Sin(x) * Math.Sin(x));
        }
    }
}

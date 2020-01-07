using System;

namespace FormulaLuiSimpson
{
    class Program
    {
        static int n;
        static double a, b;
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
            double u = 0, v = 0;
            for(int i=1; i<=n; i++)
            {
                u += f(x[i - 1]) + f(x[i]);
                v += f(0.5 * (x[i - 1] + x[i]));
            }
            double s = ((b - a) / (6 * n)) * (u + 4 * v);
            Console.WriteLine("La {0} subintervale, rezultatul este {1}.\n" +
                "Rezultatul actual: {2}.\n" +
                "Eroarea: {3}.", n, s, erf25, Math.Abs(erf25 - s));
            
            //ex 3
            //Console.WriteLine("Pamantul face {0} milioane de kilometri intr-un an", s);
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
    }
}

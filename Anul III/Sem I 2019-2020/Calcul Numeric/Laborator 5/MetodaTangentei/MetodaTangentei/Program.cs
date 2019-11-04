using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodaTangentei
{
    class Program
    {
        static double epsilon, x, xk, y, dda, c;
        static int k, m;

        static void Main(string[] args)
        {
            Console.WriteLine("Determinati intervalele [a, b] ale solutiilor unei ecuatii, si introduceti capetele unui interval de la tastatura:");
            /*Console.Write("a = ");
            x = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            y = double.Parse(Console.ReadLine());*/
            epsilon = 10e-8;

            m = 2; c = 3;
            x = 1; y = c;

            k = 0;
            dda = m * (m - 1);
            
            MetodaTangentei();

            Console.WriteLine("Solutia este {0} si a fost determinata dupa {1} iteratii.", xk, k);
            Console.ReadKey();
        }

        private static void MetodaTangentei()
        {
            if (f(x, m, c) * dda < 0)
                x = y;
            xk = c;
            do
            {
                k++;
                x = xk;
                xk = x - f(x, m, c) / df(x, m);
            } while (Math.Abs(xk - x) > epsilon);
        }
        
        static double f(double x, int m, double c)
        {
            return Math.Pow(x, m) - c;
        }
        
        static double df(double x, int m)
        {
            return m * Math.Pow(x, m - 1);
        }
    }
}

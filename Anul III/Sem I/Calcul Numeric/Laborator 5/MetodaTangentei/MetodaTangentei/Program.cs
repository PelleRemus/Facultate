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
            /*Console.WriteLine("Determinati intervalele [a, b] ale solutiilor unei ecuatii, si introduceti capetele unui interval de la tastatura:");
            Console.Write("a = ");
            x = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            y = double.Parse(Console.ReadLine());*/
            epsilon = 1e-10;

            /*m = 3; c = 3;
            Console.WriteLine("Radicalul de ordinul {0} din {1} este:", m, c);
            x = 1; y = c;*/
            x = 0.25 * Math.PI; y = 0.5 * Math.PI;

            k = 0;
            //dda = m * (m - 1);
            dda = 0.25 * Math.Sqrt(2);
            
            MetodaTangentei();

            //Console.WriteLine("Solutia este {0} si a fost determinata dupa {1} iteratii.", xk, k);
            Console.WriteLine("{0} (determinat dupa {1} iteratii)", xk, k);
            Console.ReadKey();
        }

        private static void MetodaTangentei()
        {
            if (kepler(x) * dda < 0)
                x = y;
            xk = x;
            do
            {
                Console.WriteLine(x + " " + xk);
                k++;
                x = xk;
                xk = x - kepler(x) / keplerDerivat(x);
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

        static double kepler(double x)
        {
            return x - 0.5 * Math.Sin(x) - 0.25;
        }

        static double keplerDerivat(double x)
        {
            return 1 - 0.5 * Math.Cos(x);
        }
    }
}

using System;

namespace MetInjumatatiriiIntervalului
{
    class Program
    {
        static double epsilon, x, xk, y, sol, dda;
        static int k;

        static void Main(string[] args)
        {
            Console.WriteLine("Determinati intervalele [a, b] ale solutiilor unei ecuatii, si introduceti capetele unui interval de la tastatura:");
            Console.Write("a = ");
            x = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            y = double.Parse(Console.ReadLine());
            epsilon = 10e-8;
            k = 0;
            dda = 6 * x;

            //MetodaInjumatatirii();
            MetodaCoardei();

            Console.WriteLine("Solutia este {0} si a fost determinata dupa {1} iteratii.", sol, k);
            Console.ReadKey();
        }

        static void MetodaInjumatatirii()
        {
            Console.WriteLine("Prin aceasta metoda, luam mijlocul intervalului curent si verificam in care parte fata de acesta se afla solutia.");

            while (Math.Abs(x - y) > epsilon)
            {
                if (f(x) * f((x + y) / 2) < 0)
                    y = (x + y) / 2;
                else if (f(x) * f((x + y) / 2) > 0)
                    x = (x + y) / 2;
                else
                    break;
                k++;
            }
            sol = (x + y) / 2;
        }

        static void MetodaCoardei()
        {
            if (f(x) * dda < 0)
                xk = x;
            else
            {
                double aux = x;
                x = y;
                y = aux;
                xk = x;
            }
            do
            {
                x = xk;
                xk = x - f(x) * (y - x) / (f(y) - f(x));
                k++;
            } while (Math.Abs(xk - x) > epsilon);

            sol = xk;
        }

        static double f(double x)
        {
            return x * x * x - 3 * x + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetNewon2Necunoscute
{
    class Program
    {
        static double x, xn, y, yn, epsilon;
        public static int n = 0;

        static void Main(string[] args)
        {
            xn = 2.8; yn = 1.2;
            epsilon = 1e-8;

            do
            {
                n++;
                x = xn; y = yn;

                double d = dfx(x, y) * dgy(x, y) - dfy(x, y) * dgx(x, y);
                double d1 = g(x, y) * dfy(x, y) - f(x, y) * dgy(x, y);
                double d2 = f(x, y) * dgx(x, y) - g(x, y) * dfx(x, y);

                xn = x + d1 / d;
                yn = y + d2 / d;
                Console.WriteLine("(" + xn + ", " + yn + ")");
            } while (Math.Abs(xn - x) > epsilon || Math.Abs(yn - y) > epsilon);

            Console.WriteLine("Raspunsul este ({0}, {1}) si a fost determinat dupa {2} iteratii.", xn, yn, n);
            Console.ReadKey();
        }

        static double f(double x, double y)
        {
            return x * x - 2 * x * y - 3;
        }

        static double dfx(double x, double y)
        {
            return 2 * x - 2 * y;
        }

        static double dfy(double x, double y)
        {
            return -2 * x;
        }

        static double g(double x, double y)
        {
            return Math.Sqrt(x + y) - 2;
        }

        static double dgx(double x, double y)
        {
            return 1.0 / Math.Sqrt(x + y) / 2;
        }

        static double dgy(double x, double y)
        {
            return 1.0 / Math.Sqrt(x + y) / 2;
        }
    }
}

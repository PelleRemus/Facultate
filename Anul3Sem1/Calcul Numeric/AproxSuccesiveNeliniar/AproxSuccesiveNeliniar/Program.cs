using System;

namespace AproxSuccesiveNeliniar
{
    class Program
    {
        static double x, xn, y, yn, z, zn, epsilon;
        static int n = 0;

        static void Main(string[] args)
        {
            // Ex 1
            //xn = 5; yn = 5; zn = 5;

            // Ex 2
            xn = 0.8; yn = 2.5;
            epsilon = 1e-8;
            do
            {
                n++;
                x = xn; y = yn; //z = zn;
                xn = fi(x, y, z);
                yn = f(xn, y, z);
                //zn = g(xn, yn, z);
            } while (/*Math.Max(*/Math.Max(Math.Abs(xn - x), Math.Abs(yn - y))/*, zn - z)*/ > epsilon);

            // Ex 1
            //Console.WriteLine("Raspunsul este ({0}, {1}, {2}) si a fost determinat dupa {3} iteratii.", xn, yn, zn, n);
            
            // Ex 2
            Console.WriteLine("Raspunsul este ({0}, {1}) si a fost determinat dupa {2} iteratii.", xn, yn, n);
            Console.ReadKey();
        }

        static double fi(double x, double y, double z)
        {
            // Ex 1
            //return Math.Sqrt(0.5 * (y * z + 5 * x - 1));

            // Ex 2
            //return Math.Sqrt(5 - y * y);
            return 2 / y;
        }

        static double f(double x, double y, double z)
        {
            // Ex 1
            //return Math.Sqrt(2 * x + Math.Log(z));

            // Ex 2
            //return 2 / x;
            return Math.Sqrt(5 - x * x);
        }

        static double g(double x, double y, double z)
        {
            // Ex 1
            //return Math.Sqrt(x * y + 2 * z + 8);

            // Ex 2
            return 0;
        }
    }
}

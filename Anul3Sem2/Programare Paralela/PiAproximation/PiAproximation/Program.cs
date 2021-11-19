using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiAproximation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the total number of points: ");
            long n = long.Parse(Console.ReadLine());
            Console.Write("Insert the number of threads: ");
            int threads = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            long circleP = 0;
            List<Task<long>> tasks = new List<Task<long>>();

            for (int i=0; i<threads; i++)
            {
                tasks.Add(Task<long>.Factory.StartNew(() =>
                {
                    long circlePoints = 0;
                    for (int j = 0; j < n / threads; j++)
                    {
                        double x = rnd.NextDouble();
                        double y = rnd.NextDouble();

                        if (x * x + y * y <= 1)
                            circlePoints++;
                    }
                    return circlePoints;
                }));
            }

            for (int i = 0; i < threads; i++)
                circleP += tasks[i].Result;

            Console.WriteLine("Aprox: " + 4.0 * circleP / n);
            Console.WriteLine(Math.PI);
            Console.ReadKey();
        }
    }
}

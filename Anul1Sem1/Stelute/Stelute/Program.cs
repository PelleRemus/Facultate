using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelute
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Triunghi(n);
            Console.ReadKey();
        }

        private static void Triunghi(int n)
        {
            int a=1, x;
            for (int i = n - 1; i >= 0; i--)
            {
                if (i==0)
                {
                    x = n;
                    while (x>0)
                    {
                        Console.Write("* ");
                        x--;
                    }
                }
                else if (i==n-1)
                {
                    x = i;
                    Afisare(x);
                    Console.Write("*");
                    Console.WriteLine();
                }
                else
                {
                    x = i;
                    Afisare(x);
                    Console.Write("*");
                    x = a;
                    Afisare(x);
                    Console.Write("*");
                    Console.WriteLine();
                    a += 2;
                }
            }
        }

        private static void Afisare(int x)
        {
            while (x>0)
            {
                Console.Write(" ");
                x--;
            }
        }
    }
}

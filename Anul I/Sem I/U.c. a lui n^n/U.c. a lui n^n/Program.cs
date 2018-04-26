using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.c.a_lui_n_n
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[10, 4];
            for (int i = 0; i < 4; i++)
            {
                a[0, i] = 0;
                a[1, i] = 1;
                a[2, i] = (int)Math.Pow(2, i + 1) % 10;
                a[3, i] = (int)Math.Pow(3, i + 1) % 10;
                if (i % 2 == 0) a[4, i] = 6;
                else a[4, i] = 4;
                a[5, i] = 5;
                a[6, i] = 6;
                a[7, i] = (int)Math.Pow(7, i + 1) % 10;
                a[8, i] = (int)Math.Pow(8, i + 1) % 10;
                if (i % 2 == 0) a[9, i] = 9;
                else a[9, i] = 1;
            }
            if (n % 4 == 0) Console.Write(a[n % 10, 3]);
            else Console.Write(a[n % 10, n % 4 - 1]);
            Console.ReadKey();
        }
    }
}

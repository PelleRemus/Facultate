using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Numere_grindina
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //999 994 980 000 000; 999 995 137 808 031: 1433
            int max = 0;
            for (ulong i=999994980000000; i>900000000000000; i--)
            {
                int p = 0;
                ulong n = i;
                do
                {
                    p++;
                    if (p <= 1770 && ~(n - 1) == 0) break;
                    else
                    {
                        if (n % 2 == 0) n = n / 2;
                        else n = n * 3 + 1;
                    }
                } while (n != 1);
                if (p == 1820)
                {
                    Console.Write("{0} -> {1}", i, p);
                    break;
                }
                if (max<p)
                {
                    max = p;
                    Console.WriteLine(i+": "+max);
                }
                if (i % 100000 == 0) Console.Write(i+ " ");
            }
            Console.ReadKey();
            */

            /*ulong n = 700977473076633, y = 0;
            int max = 0;
            for (ulong i = n - 1000000; i < n + 1000000; i++)
            {
                int p = 0;
                ulong x = i;
                do
                {
                    if (x % 2 == 0) x /= 2;
                    else x = 3 * x + 1;
                    p++;
                } while (x > 1);
                if (max < p)
                {
                    max = p;
                    y = i;
                }
            }
            Console.WriteLine(y + " " + max);
            Console.ReadKey();
            */

            decimal a, b, k = 0.00000001m;
            StreamWriter w = new StreamWriter(@"..\..\Solutii.txt");
            for (b = 1; b >= 0.999192m; b -= k)
            {
                a = 1.62099936198m - Decimal.Multiply(0.62150215802m, b);
                decimal n = a / 2.4702821531902077m;
                decimal m = b / 2.5596411731597635m;
                w.WriteLine("n = " + n + ", m = " + m);
            }
            Console.WriteLine("Gata");
            Console.ReadKey();
        }
    }
}

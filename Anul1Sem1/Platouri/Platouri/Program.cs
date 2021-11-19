using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platouri
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 1, 2, 2, 2, 5, 5, 5, 4, 4, 4 };
            Platou(v);
            Console.ReadKey();
        }

        static void Platou(int[]v)
        {
            int a = 0, b = v[0], n = v.Length, c = 1;
            for (int i = 1; i < n; i++)
            {
                if (v[i] == v[i - 1])
                    c++;
                else
                    if (a <= c)
                    {
                        a = c;
                        if (b < v[i - 1]) b = v[i - 1];
                        c = 1;
                    }
            }
            if (a <= c)
            {
                a = c;
                if (b < v[n - 1]) b = v[n - 1];
            }
            Console.WriteLine("Cel mai mare platou din vector are lungimea {0} si este format din numarul {1}", a, b);
        }
    }
}

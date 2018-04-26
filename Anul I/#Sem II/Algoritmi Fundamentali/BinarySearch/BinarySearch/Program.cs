using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 3, 7, 9, 10, 11, 15, 21, 24, 30 };
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(x + " " + BS(v, x, 0, v.Length-1));
            Console.ReadKey();
        }

        static bool BS(int[] v, int x, int s, int d)
        {
            if (s <= d)
            {
                int m = (s + d) / 2;
                if (v[m] == x) return true;
                if (x > v[m])
                    return BS(v, x, m + 1, d);
                else
                    return BS(v, x, s, m - 1);
            }
            return false;
        }
    }
}

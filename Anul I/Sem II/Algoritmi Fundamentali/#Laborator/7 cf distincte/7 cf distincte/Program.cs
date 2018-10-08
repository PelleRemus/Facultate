using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_cf_distincte
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            int index;
            bool[] f = new bool[10];
            int n = r.Next(1, 10);
            f[n] = true;

            int i = 0;
            do
            {
                do
                {
                    index = r.Next(10);
                } while (f[index] == true);
                f[index] = true;
                i++;
                n = n * 10 + index;
            } while (i < 6);
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}

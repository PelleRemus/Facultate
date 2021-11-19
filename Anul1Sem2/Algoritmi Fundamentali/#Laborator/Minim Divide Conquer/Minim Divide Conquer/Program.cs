using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minim_Divide_Conquer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
                v[i] = r.Next(100);
            for (int i = 0; i < n; i++)
                Console.Write(v[i]+" ");
            Console.WriteLine();
            Console.WriteLine(Minim(v, 0, n - 1));
            Console.ReadKey();
        }

        static int Minim(int[] v, int st, int dr)
        {
            if (st >= dr)
                return v[st];
            else
            {
                int m = (st + dr) / 2;
                int ms = Minim(v, st, m);
                int md = Minim(v, m + 1, dr);
                if (ms < md)
                    return ms;
                return md;
            }
        }
    }
}

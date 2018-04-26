using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picaturi_de_apa
{
    class Program
    {
        static Random r = new Random();
        static int n = 20;
        static int[] m;
        static void Main(string[] args)
        {
            int nrp = 0;
            gen();
            for (int i=0; i<100000; i++)
            {
                int p = r.Next(n);
                if (t(p)==true)
                {
                    m[p]++;
                    nrp++;
                }
            }
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", m[i]);
            Console.WriteLine();
            Console.Write(nrp);
            Console.ReadKey();

        }

        static void gen()
        {
            m = new int[n];
            for (int i = 0; i < n; i++)
                m[i] = r.Next(10);
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", m[i]);
            Console.WriteLine();
        }

        static bool t (int idx)
        {
            if (idx == 0 || idx == n) return false;
            bool left = false;
            bool right = false;
            for (int i = idx; i >= 0; i--)
                if (m[i] > m[idx]) left = true;
            for (int i = idx; i < n; i++)
                if (m[i] > m[idx]) right = true;
            if (right == true && left == true)
                return true;
            else return false;
        }
    }
}

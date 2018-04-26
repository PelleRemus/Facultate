using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suma_l_c_d
{
    class Program
    {
        static int[,] m = new int[3, 3];
        static Random r = new Random();
        static void Main(string[] args)
        {
            int k = 1, nr = 0;
            for (int i=0; i<3; i++)
                for (int j=0; j<3; j++)
                {
                    m[i, j] = k;
                    k++;
                }
            do
            {
                int l1 = r.Next(3);
                int c1 = r.Next(3);
                int l2 = r.Next(3);
                int c2 = r.Next(3);
                int t = m[l1, c2];
                m[l1, c1] = m[l2, c2];
                m[l2, c2] = t;
                nr++;
            } while (Sol() == false);
            for (int i=0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write("{0} ", m[i, j]);
                Console.WriteLine();
            }
            Console.Write(nr);
            Console.ReadKey();
        }

        static bool Sol()
        {
            int sl1 = m[0, 0] + m[0, 1] + m[0, 2];
            if (sl1 != 15) return false;
            int sl2 = m[1, 0] + m[1, 1] + m[1, 2];
            if (sl2 != 15) return false;
            int sl3 = m[2, 0] + m[2, 1] + m[2, 2];
            if (sl3 != 15) return false;
            int sc1 = m[0, 0] + m[1, 0] + m[2, 0];
            if (sc1 != 15) return false;
            int sc2 = m[0, 1] + m[1, 1] + m[2, 1];
            if (sc2 != 15) return false;
            int sc3 = m[0, 2] + m[1, 2] + m[2, 2];
            if (sc3 != 15) return false;
            int sd1 = m[0, 0] + m[1, 1] + m[2, 2];
            if (sd1 != 15) return false;
            int sd2 = m[2, 0] + m[1, 1] + m[0, 2];
            if (sd2 != 15) return false;
            return true;
        }
    }
}

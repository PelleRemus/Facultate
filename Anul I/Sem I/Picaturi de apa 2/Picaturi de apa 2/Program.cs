using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picaturi_de_apa_2
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            int n = 20;
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
                v[i] = r.Next(10);
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", v[i]);
            Console.WriteLine();
            Console.WriteLine();

            int max = v[0];
            for (int i = 1; i < n; i++)
                if (v[i] > max) max = v[i];

            int[,] m = new int[max, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < v[i]; j++)
                    m[max-j-1, i] = 1;

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", m[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
            
            for (int i = 0; i < max; i++)
            {
                int j = 0;
                while (m[i,j]==0)
                {
                    m[i, j] = 2;
                    j++;
                }
            }
            for (int i = 0; i < max; i++)
            {
                int j = n - 1;
                while (m[i,j]==0)
                {
                    m[i, j] = 2;
                    j--;
                }
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", m[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            int vol = 0;
            for (int i = 0; i < max; i++)
                for (int j = 0; j < n; j++)
                    if (m[i, j] == 0) vol++;
            Console.Write(vol);
            Console.ReadKey();
        }

    }
}

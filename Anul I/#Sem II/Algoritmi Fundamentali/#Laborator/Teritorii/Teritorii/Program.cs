using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teritorii
{
    class Program
    {
        static int n = 9, t1 = 0, t2 = 0, v = 0;
        static int[,] m = new int[n, n];
        static Random r = new Random();
        static bool[,] b = new bool[n, n];
        static bool is1, is2;

        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = r.Next(3);
            Afisare(m);

            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                    if (m[i,j]==0)
                    {
                        is1 = is2 = false;
                        v = 0;
                        Parcurgere(i, j);
                        if (is1 == true && is2 == false)
                            t1 += v;
                        if (is1 == false && is2 == true)
                            t2 += v;
                    }

            Console.WriteLine();
            Console.WriteLine("teritoriile lui 1: {0}; teritoriile lui 2: {1}", t1, t2);
            Console.ReadKey();
        }

        static void Afisare(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void Parcurgere(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < n && b[i, j] == false)
            {
                if (m[i, j] == 0)
                {
                    v++;
                    b[i, j] = true;
                    Parcurgere(i, j + 1);
                    Parcurgere(i + 1, j);
                    Parcurgere(i, j - 1);
                    Parcurgere(i - 1, j);
                }
                else
                {
                    if (m[i, j] == 1) is1 = true;
                    if (m[i, j] == 2) is2 = true;
                }
            }
        }
    }
}

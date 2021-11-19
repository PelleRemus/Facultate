using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutari
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[] sol = new int[n];
            bool[] b = new bool[n];
            Permutari(0, n, sol, b);

            int p = 3;
            sol = new int[p];
            b = new bool[n];
            Aranjamente(0, n, p, sol, b);

            sol = new int[p + 1];
            b = new bool[n];
            Combinari(1, n, p, sol, b);
            Console.ReadKey();
        }

        static public void Permutari(int k, int n, int[] sol, bool[] b)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write((sol[i]+1)+" ");
                Console.WriteLine();
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Permutari(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }

        static public void Aranjamente(int k, int n, int p, int[] sol, bool[] b)
        {
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.Write((sol[i] + 1) + " ");
                Console.WriteLine();
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Aranjamente(k + 1, n, p, sol, b);
                        b[i] = false;
                    }
        }

        static public void Combinari(int k, int n, int p, int[] sol, bool[] b)
        {
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write((sol[i]) + " ");
                Console.WriteLine();
            }
            else
                for (int i = sol[k - 1] + 1; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Combinari(k + 1, n, p, sol, b);
                        b[i] = false;
                    }
        }
    }
}

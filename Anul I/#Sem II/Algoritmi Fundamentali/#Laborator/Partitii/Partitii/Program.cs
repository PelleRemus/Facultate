using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partitii
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sol = new int[n];
            Partitii(0, n, sol);
            Console.ReadKey();
        }

        static void Partitii(int k, int n, int[] sol)
        {
            if (k >= n)
            {
                if (isCresc(sol))
                {
                    int suma = 0, index = 0;
                    while (suma < n)
                    {
                        suma += sol[index];
                        index++;
                    }
                    if (suma == n)
                    {
                        Console.Write(sol[0]);
                        for (int i = 1; i < index; i++)
                            Console.Write("+" + sol[i]);
                        Console.WriteLine();
                    }
                    sol[index - 1]++;
                }
            }
            else
                for (int i = 0; i < n; i++)
                {
                    sol[k] = i + 1;
                    Partitii(k + 1, n, sol);
                }
        }

        static bool isCresc(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
                if (v[i] < v[i - 1]) return false;
            return true;
        }
    }
}

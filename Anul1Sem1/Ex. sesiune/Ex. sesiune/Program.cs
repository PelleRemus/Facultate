using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.sesiune
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            int k = 0, nrit1 = 0, nrit2 = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                {
                    if (i % 2 == 0)
                    {
                        a[j , i - j] = k;
                        k++;
                    }
                    else
                    {
                        a[i - j, j] = k;
                        k++;
                    }
                    nrit1++;
                }

            for (int i = n - 2; i >= 0; i--)
            {
                int l = 0;
                for (int j = i; j >= 0; j--)
                {
                    if (i % 2 == 0)
                    {
                        a[n - 1 - j, n - 1 - l] = k;
                        k++;
                    }
                    else
                    {
                        a[n - 1 - l, n - 1 - j] = k;
                        k++;
                    }
                    l++;
                    nrit2++;
                }
            }

            for (int i=0; i<n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", a[i, j]);
                    if (a[i, j] / 10 == 0) Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("{0} {1}", nrit1, nrit2);
            Console.ReadKey();
        }
    }
}

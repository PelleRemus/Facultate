using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici
{
    class Program
    {
        static int n, m;
        static Random r = new Random();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();
            Ex6();
            Console.ReadKey();
        }

        static void Ex1()
        {
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = 0;
            for (int i = 0; i < n; i++)
            {
                a[i, n / 2] = 1;
                a[n / 2, i] = 1;
                a[i, i] = 1;
                a[i, n - i - 1] = 1;
            }
            Show(a);
        }

        static void Ex2()
        {
            int[,] b = new int[n / 2, n];
            for (int i = 0; i < n / 2; i++)
                for (int j = 0; j < n; j++)
                {
                    if (j < n / 3) b[i, j] = 2;
                    else if (j < 2 * n / 3) b[i, j] = 1;
                    else b[i, j] = 0;
                }
            Show(b);
        }

        static void Ex3()
        {
            int[,] c = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = 1;
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    c[i, j] = 0;
            Show(c);
        }

        static void Ex4()
        {
            int[,] d = new int[n, m];
            d = init(d);
            Show(d);
            for (int i = 0; i < m - 1; i++)
                Console.Write("{0} ", d[0, i]);
            for (int i = 0; i < n - 1; i++)
                Console.Write("{0} ", d[i, m - 1]);
            for (int i = m - 1; i >= 1; i--)
                Console.Write("{0} ", d[n - 1, i]);
            for (int i = n - 1; i >= 1; i--)
                Console.Write("{0} ", d[i, 0]);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Ex5()
        {
            int[,] e = new int[n, m];
            e = init(e);
            Show(e);
            for (int k = 0; k < n / 2; k++)
                Draw(e, k);
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Ex6()
        {
            int[,] f = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    f[i, j] = 1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m / 2; j++)
                    f[i, j] = 0;
            Show(f);
        }

        static void Draw (int[,] e, int k)
        {
            for (int i = k; i < m - 1 - k; i++)
                Console.Write("{0} ", e[k, i]);
            for (int i = k; i < n - 1 - k; i++)
                Console.Write("{0} ", e[i, m - 1 - k]);
            for (int i = m - 1 - k; i >= k + 1; i--)
                Console.Write("{0} ", e[n - 1 - k, i]);
            for (int i = n - 1 - k; i >= k + 1; i--)
                Console.Write("{0} ", e[i, k]);
        }

        static int[,] init (int[,] e)
        {
            e = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    e[i, j] = r.Next(10, 100);
            return e;
        }

        static void Show(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0} ", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flip
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            int n = 7;
            int[,] m = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = r.Next(10);
            Afisare(m);

            FlipY(ref m);
            FlipX(ref m);
            FlipDS(ref m);
            FlipDP(ref m);
            FlipLeft(ref m);
            FlipRight(ref m);
            Console.ReadKey();
        }

        private static void FlipRight(ref int[,] m)
        {
            int n = m.GetLength(0);
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[j, n - 1 - i] = m[i, j];
            m = a;
            Afisare(m);
        }

        private static void FlipLeft(ref int[,] m)
        {
            int n = m.GetLength(0);
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[n - 1 - j, i] = m[i, j];
            m = a;
            Afisare(m);
        }

        private static void FlipDP(ref int[,] m)
        {
            int n = m.GetLength(0);
            for (int i=0; i<n;i++)
                for (int j=i; j<n; j++)
                {
                    int aux = m[i, j];
                    m[i, j] = m[j, i];
                    m[j, i] = aux;
                }
            Afisare(m);
        }

        private static void FlipDS(ref int[,] m)
        {
            int n = m.GetLength(0);
            for (int i=0; i<n-i; i++)
                for (int j=0; j<n-i; j++)
                {
                    int aux = m[i, j];
                    m[i, j] = m[n - 1 - i, n - 1 - j];
                    m[n - 1 - i, n - 1 - j] = aux;
                }
            Afisare(m);
        }

        private static void FlipX(ref int[,] m)
        {
            int n = m.GetLength(0);
            for (int i=0; i<n/2; i++)
                for (int j=0; j<n; j++)
                {
                    int aux = m[i, j];
                    m[i, j] = m[n - 1 - i, j];
                    m[n - 1 - i, j] = aux;
                }
            Afisare(m);
        }

        private static void FlipY(ref int[,] m)
        {
            int n = m.GetLength(0);
            for (int i=0; i<n; i++)
                for (int j=0; j<n/2; j++)
                {
                    int aux = m[i, j];
                    m[i, j] = m[i, n - 1 - j];
                    m[i, n - 1 - j] = aux;
                }
            Afisare(m);
        }

        private static void Afisare (int[,] m)
        {
            int n = m.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", m[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}

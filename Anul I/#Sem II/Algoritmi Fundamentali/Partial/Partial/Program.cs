using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex2();
            Ex3();
        }

        private static void Ex2()
        {
            Console.WriteLine("Exercitiul 2: Vectori");
            int[] v1, v2;

            int n = int.Parse(Console.ReadLine());
            v1 = new int[n];
            string s = Console.ReadLine();
            for (int i=0; i<n; i++)
                v1[i] = int.Parse(s[i].ToString());

            int m = int.Parse(Console.ReadLine());
            v2 = new int[m];
            s = Console.ReadLine();
            for (int i = 0; i < m; i++)
                v2[i] = int.Parse(s[i].ToString());

            ComparareVectori(v1, v2);
        }

        private static int ComparareVectori(int[] v1, int[] v2)
        {
            int[] c1 = PutereVector(v1);
            int[] c2 = PutereVector(v2);
            int n = c1.Length, m = c2.Length;

            int x, nr;
            if (n < m) 
            { x = n; nr = -1; }
            else if (n > m) 
            { x = m; nr = 1; }
            else
            { x = n; nr = 0; }

            for (int i = 0; i < x; i++)
            {
                if (c1[i] > c2[i]) return 1;
                if (c1[i] < c2[i]) return -1;
            }
            return nr;
        }

        private static int[] PutereVector(int[] v)
        {
            string s = "";
            string s2 = "";
            s += v[0] + " ";
            int nr = 1;
            for (int i = 1; i < v.Length; i++) 
            {
                for (int j = 1; j < v.Length; j++)
                    if (v[j] == int.Parse(s[s.Length - 2].ToString()))
                        nr ++;
                s2 += nr + " ";
                bool ok = true;
                for (int j = 0; j < s.Length / 2; j++)
                    if (v[i].ToString() == s.Split(' ')[j])
                    {
                        ok = false;
                        break;
                    }
                if (ok) s += v[i] + " ";
                nr = 0;
            }
            int[] c = new int[s2.Length / 2];
            for (int i = 0; i < s2.Length / 2; i++)
                c[i] = int.Parse(s.Split(' ')[i]);
            return c;
        }

        private static void Ex3()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] m = new int[n, n];
            for (int i=0; i<n; i++)
            {
                m[0, i] = i;
                m[i, i] = 0;
                m[i, 0] = i;
            }

            for (int i=1; i<n; i++)
                for (int j=1; j<n; j++)
                {
                    int x = 0;
                    Eticheta: for (int k=0; k<i; k++)
                        for (int l=0; l<j; l++)
                            if (x==m[k, j] || x==m[i, l])
                            {
                                x++;
                                goto Eticheta;
                            }
                    m[i, j] = x;
                }

            for (int i=0; i<n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] < 10)
                        Console.Write(m[i, j] + "  ");
                    else Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

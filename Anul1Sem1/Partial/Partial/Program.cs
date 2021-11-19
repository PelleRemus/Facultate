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
             //1
            /*int[] v = { 1, 0, 12, 0, 2, 0, 2, 0, 8, 0, 1, 0 };
            for (int i = 0; i < v.Length; i++)
            {
                string a = "";
                string b = "";
                if (v[i] == 0)
                {
                    for (int j = 0; j < i; j++)
                        a += v[j];
                    for (int j = i + 1; j < v.Length; j++)
                        b += v[j];
                    v = new int[v.Length - 1];
                    for (int j = 0; j < a.Length; j++)
                        v[j] = Tovect(a)[j];
                    for (int j = a.Length; j < v.Length; j++)
                        v[j] = Tovect(b)[j-a.Length];
                }
                
            }
            for (int i = 0; i < v.Length; i++)
                Console.Write("{0} ", v[i]);*/

            /*//4
            int n = int.Parse(Console.ReadLine());
            int x = n, nr = 0;
            while (x>0)
            {
                x /= 10;
                nr++;
            }
            x = n;
            int[] c = new int[nr];
            for (int i=nr-1; i>=0; i--)
            {
                c[i] = x % 10;
                x /= 10;
            }
            int min = c[0];
            int poz = 0;
            for (int i = 0; i < nr; i++)
                if (c[i] < min && c[i] != 0)
                {
                    min = c[i];
                    poz = i;
                }
            c[poz] = c[0];
            c[0] = min;
            x = 0;
            c = InsertionSort(c);
            for (int i=0; i<nr; i++)
                x = x * 10 + c[i];
            Console.Write(x);*/

            //6
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int k=0; k<n/2; k+=2)
                for (int i = k; i < n - 1 - k; i++)
                {
                    a[k, i] = 1;
                    a[i, n - 1 - k] = 1;
                    a[n - 1 - k, n - 1 - i] = 1;
                    a[n - 1 - i, k] = 1;
                }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", a[i, j]);
                Console.WriteLine();
            }

            //5
            /*int zi, luna, an, ora, min, sec;
            long nrsec;
            zi = int.Parse(Console.ReadLine());
            luna = int.Parse(Console.ReadLine());
            an = int.Parse(Console.ReadLine());
            ora = int.Parse(Console.ReadLine());
            min = int.Parse(Console.ReadLine());
            sec = int.Parse(Console.ReadLine());
            ora = 24 - ora;
            min = 60 - min;
            sec = 60 - sec;
            zi++;
            if (luna == 2 && an % 4 == 0 && an % 100 != 0) zi = 29 - zi;
            else if (luna == 2) zi = 28 - zi;
            if (luna == 1 || luna == 3 || luna == 5 || luna == 7 || luna == 8 || luna == 10 || luna == 12) zi = 31 - zi;
            else zi = 30 - zi;
            for (int i=luna+1; i<=12; i++)
            {
                if (i == 2 && an % 4 == 0 && an % 100 != 0) zi += 29;
                else if (i == 2) zi += 28;
                if (i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) zi += 31;
                else zi += 30;
            }
            for (int i = an + 1; i < 2017; i++)
            {
                if (an % 4 == 0 && an % 100 != 0) zi += 366;
                else zi += 365;
            }
            zi += 327;
            ora += 12;
            nrsec = sec + 60 * min + 3600 * ora + 86400 * zi;
            Console.Write(nrsec);*/

            Console.ReadKey();

        }

        static int[] InsertionSort(int[]c)
        {
            for(int j=2; j<c.Length;j++)
                for (int i=j; i>1; i--)
                    if (c[i]<c[i-1])
                    {
                        int t = c[i];
                        c[i] = c[i - 1];
                        c[i - 1] = t;
                    }
            return c;
        }

        static int[] Tovect(string a)
        {
            int[] v = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                v[i] = int.Parse(a[i].ToString());
            return v;
        }

    }
}

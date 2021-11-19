using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] factorial = Factorial(n);
            int i = 0;
            while (factorial[i] == 0)
                i++;
            string str = $"{n}! = ";
            for (; i < factorial.Length; i++)
                str = $"{str}{factorial[i]}";
            Console.WriteLine(str);
            Console.ReadKey();
        }

        static int[] Factorial(int n)
        {
            if (n == 0 || n == 1)
                return new int[] { 1 };
            return Produs(ntov(n), Factorial(n - 1));
        }

        static int[] ntov(int n)
        {
            int x = n, k = 0;
            while (x > 0)
            {
                x /= 10;
                k++;
            }
            int[] v = new int[k];
            x = n;
            for (int i = k - 1; i >= 0; i--)
            {
                v[i] = x % 10;
                x /= 10;
            }
            return v;
        }

        static int[] Produs(int[] a, int[] b)
        {
            a = Inv(a);
            b = Inv(b);
            if (b.Length > a.Length)
            {
                int[] t = a;
                a = b;
                b = t;
            }
            int max = a.Length, min = b.Length;
            int[] v = new int[max + min];
            for (int i = 0; i < min; i++)
            {
                int[] aux = new int[i + max];
                for (int j = 0; j < max; j++)
                    aux[i + j] = b[i] * a[j];
                v = Suma(v, Inv(aux));
            }
            return v;
        }

        static int[] Inv(int[] v)
        {
            for (int i = 0; i < v.Length / 2; i++)
            {
                int t = v[i];
                v[i] = v[v.Length - 1 - i];
                v[v.Length - 1 - i] = t;
            }
            return v;
        }

        static int[] Suma(int[] v1, int[] v2)
        {
            v1 = Inv(v1);
            v2 = Inv(v2);

            int min = v1.Length, max = v1.Length;
            if (v2.Length < min)
                min = v2.Length;
            else
                max = v2.Length;

            int[] v = new int[max + 1];
            for (int i = 0; i < min; i++)
                v[i] = v1[i] + v2[i];

            for (int i = v1.Length; i < max; i++)
                v[i] = v2[i];
            for (int i = v2.Length; i < max; i++)
                v[i] = v1[i];

            for (int i = 0; i <= max; i++)
                if (v[i] > 9)
                {
                    v[i + 1] += v[i] / 10;
                    v[i] %= 10;
                }
            return Inv(v);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortari
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 12, 3, 4, 7, 2, 5, 17, 8, 17, 3, 5 };
            int[,] a = new int[6, 6];
            Print(BubbleSort(v));
            Print(SelectionSort(v));
            Print(InsertionSort(v));
            Print(CountingSort(v));
            Console.ReadKey();
        }

        static void Print (int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write("{0} ", v[i]);
            Console.WriteLine();
        }

        static void Swap(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        static int[] BubbleSort(int[] v)
        {
            int k = 0;
            bool ok;
            do
            {
                ok = false;
                for (int i = 0; i < v.Length - 1 - k; i++)
                    if (v[i] > v[i + 1])
                    {
                        Swap(ref v[i], ref v[i + 1]);
                        ok = true;
                    }
                k++;
            } while (ok);
            return v;
        }

        static int[] SelectionSort(int[] v)
        {
            for (int j=0; j < v.Length; j++)
            {
                int poz = j;
                for (int i = j + 1; i < v.Length; i++)
                    if (v[i] < v[poz])
                        poz = i;
                Swap(ref v[j], ref v[poz]);
            }
            return v;
        }

        static int[] InsertionSort(int[] v)
        {
            for (int j = 1; j < v.Length; j++)
                for (int i = j; i > 0; i--)
                    if (v[i] < v[i - 1])
                        Swap(ref v[i], ref v[i - 1]);
            return v;
        }

        static int[] CountingSort(int[] v)
        {
            int max = v[0];
            for (int i = 1; i < v.Length; i++)
                if (v[i] > max) max = v[i];

            int[] c = new int[max+1];
            for (int i = 0; i < v.Length; i++)
                c[v[i]]++;

            int k = 0;
            for (int i=0; i<c.Length; i++)
                for (int j=0; j<c[i]; j++)
                {
                    v[k] = i;
                    k++;
                }
            return v;
        }
    }
}

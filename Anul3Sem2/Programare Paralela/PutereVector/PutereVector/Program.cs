using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutereVector
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = Compare(new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 2, 2, 3, 3, 4 });
            if(c==-1)
                Console.WriteLine("Primul vector are putere mai mare");
            else if(c==1)
                Console.WriteLine("Al doilea vector are putere mai mare");
            else
                Console.WriteLine("Vectorii au puteri egale");
            Console.ReadKey();
        }

        static int[] Putere(int[] v)
        {
            Sort(v);
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();

            List<int> c = new List<int>();
            int n = v.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int count = 1;
                while (i < n - 1 && v[i] == v[i + 1])
                {
                    count++;
                    i++;
                }
                c.Add(count);
            }
            if (v[n - 1] != v[n - 2])
                c.Add(1);

            int[] toReturn = c.ToArray();
            Sort(toReturn);
            return toReturn;
        }

        static int Compare(int[] v, int[] u)
        {
            int[] a = Putere(v);
            int[] b = Putere(u);

            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] < b[i])
                    return 1;
                if (a[i] > b[i])
                    return -1;
            }

            if (a.Length < b.Length)
                return 1;
            if (a.Length > b.Length)
                return -1;
            return 0;
        }

        static void Sort(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
                for (int j = i; j > 0; j--)
                    if (v[j] > v[j - 1])
                    {
                        int aux = v[j];
                        v[j] = v[j - 1];
                        v[j - 1] = aux;
                    }
        }
    }
}

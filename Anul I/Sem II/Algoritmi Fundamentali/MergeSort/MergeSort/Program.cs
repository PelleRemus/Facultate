using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 4, 7, 3, 5, 8, 2 };
            MergeSort(v, 0, v.Length - 1);
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.ReadKey();
        }

        static void MergeSort(int[] v, int st, int dr)
        {
            if (st < dr)
            {
                int m = (st + dr) / 2;
                MergeSort(v, st, m);
                MergeSort(v, m + 1, dr);
                Interclasare(v, st, m, dr);
            }
        }

        static void Interclasare(int[] v, int st, int m, int dr)
        {
            int[] _v = new int[dr - st + 2];
            int i = st, j = m + 1, k = 0;
            while (i <= m && j <= dr)
            {
                if (v[i] <= v[j])
                    _v[++k] = v[i++];
                else
                    _v[++k] = v[j++];
            }

            while (i <= m)
                _v[++k] = v[i++];
            while (j <= dr)
                _v[++k] = v[j++];
            for (i = 1; i <= k; ++i)
                v[st + i - 1] = _v[i];
        }
    }
}

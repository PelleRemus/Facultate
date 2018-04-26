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

        }

        static int[] Interclasare(int[] v1, int[] v2)
        {
            int k1 = 0, k2 = 0, k3 = 0;
            int n1 = v1.Length, n2 = v2.Length;
            int[] v3 = new int[n1 + n2];

            while (k1 < n1 && k2 < n2)
            {
                if (v1[k1] < v2[k2])
                {
                    v3[k3] = v1[k1];
                    k3++;
                    k1++;
                }
                else
                {
                    v3[k3] = v2[k2];
                    k3++;
                    k2++;
                }
            }
            while (k1 < n1)
            {
                v3[k3] = v1[k1];
                k3++;
                k1++;
            }
            while (k2 < n2)
            {
                v3[k3] = v2[k2];
                k3++;
                k2++;
            }
            return v3;
        }
    }
}

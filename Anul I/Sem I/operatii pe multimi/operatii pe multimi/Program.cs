using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatii_pe_multimi
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k = 0, m, n;
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            int[] v2 = new int[m];


            int[] intersectie;
            if (n < m)
            {
                intersectie = new int[n];
            }
            else
            {
                intersectie = new int[m];
            }
            for (i = 0; i < n; i++)
                v1[i] = int.Parse(Console.ReadLine());
            for (i = 0; i < m; i++)
                v2[i] = int.Parse(Console.ReadLine());
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    if (v1[i] == v2[j])
                    {
                        intersectie[k] = v2[j];
                        k++;

                    }
                    if (v1[i] == v2[j])
                    {
                        v2[k] = v1[i];
                        break;
                    }
                }
            Console.WriteLine("elementele comune sunt: ");
            for (i = 0; i < k; i++)
                Console.Write(intersectie[i] + " ");
            Console.ReadLine();
        }
    }
}

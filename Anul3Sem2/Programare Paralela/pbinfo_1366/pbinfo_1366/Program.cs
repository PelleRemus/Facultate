using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbinfo_1366
{
    class Program
    {
        //Se dau n numere întregi. Să se insereze între oricare două numere 
        //de aceeași paritate media lor aritmetică. Algoritmul se va relua 
        //în mod repetat până când nu se mai poate adăuga șirului niciun nou element.

        static int[] v;
        static int n;

        static void Main(string[] args)
        {
            n = 3;
            v = new int[1000];
            v[0] = -2; v[1] = 6; v[2] = 8;
            bool ok = false;
            /*int[] t = new int[2 * n];

            do
            {
                ok = false;
                t = new int[2 * n];
                int k = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    t[k] = v[i];
                    k++;
                    if ( ((v[i] + v[i + 1]) % 2 == 0) && (v[i] != v[i + 1]) )
                    {
                        t[k] = (v[i] + v[i + 1]) / 2;
                        k++;
                        ok = true;
                    }
                }
                t[k] = v[n - 1];
                k++;

                n = k;
                v = new int[n];
                for (int i = 0; i < n; i++)
                    v[i] = t[i];
            } while (ok);
            */

            for (int i = 0; i < n - 1; i++)
            {
                if (((v[i] + v[i + 1]) % 2 == 0) && (v[i] != v[i + 1]))
                {
                    for (int j = n; j > i; j--)
                        v[j + 1] = v[j];
                    v[i + 1] = (v[i] + v[i + 1]) / 2;
                    n++;
                    i--;
                }
            }

            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.ReadKey();
        }
    }
}

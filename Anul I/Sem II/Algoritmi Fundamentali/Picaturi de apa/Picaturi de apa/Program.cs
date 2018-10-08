using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picaturi_de_apa
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            //Pentru examen, rezolvati aceasta problema folosind o matrice
            int n = 10;
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
                v[i] = r.Next(10);
            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();

            int apa = 0;
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < n; i++)
                {
                    int x = i;
                    bool stanga = false, dreapta = false;
                    for (int j = x; j >= 0; j--)
                        if (v[x] < v[j])
                        {
                            stanga = true;
                            break;
                        }
                    for (int j = x; j < n; j++)
                        if (v[x] < v[j])
                        {
                            dreapta = true;
                            break;
                        }
                    if (stanga == true && dreapta == true)
                    {
                        v[x]++;
                        apa++;
                        ok = false;
                    }
                }
            } while (!ok);

            for (int i=0; i<n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
            Console.Write(apa);
            Console.ReadKey();
        }
    }
}

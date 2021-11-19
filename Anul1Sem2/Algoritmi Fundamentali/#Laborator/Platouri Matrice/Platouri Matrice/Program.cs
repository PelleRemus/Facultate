using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Platouri_Matrice
{
    class Program
    {
        static int[,] a;
        static List<string> T = new List<string>();
        static int n, m, t, v, max = 0, Max = 0;
        static bool[,] b;

        static void Main(string[] args)
        {
            string buffer = "";
            TextReader dLoad = new StreamReader(@"..\..\TextFile1.txt");
            while ((buffer=dLoad.ReadLine())!=null)
                T.Add(buffer);
            n = T.Count;
            m = T[0].Split(' ').Length;
            a = new int[n, m];
            b = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] local = T[i].Split(' ');
                for (int j = 0; j < m; j++)
                    a[i, j] = int.Parse(local[j]);
            }
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<m; j++)
                    Console.Write(a[i,j]+" ");
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (b[i, j] == false)
                    {
                        v = 0;
                        t = a[i, j];
                        Parcurgere(i, j);
                        Console.WriteLine(t + " " + v);
                        if (v > max)
                        {
                            max = v;
                            Max = t;
                        }
                    }
            Console.WriteLine();
            Console.WriteLine(Max + " " + max);
            Console.ReadKey();
        }

        static void Parcurgere(int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < m && b[i, j] == false && a[i,j]==t)
            {
                v++;
                b[i, j] = true;
                Parcurgere(i - 1, j);
                Parcurgere(i, j + 1);
                Parcurgere(i + 1, j);
                Parcurgere(i, j - 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Coada
{
    class Program
    {
        static int[,] matrix;
        static bool[,] b;
        static int n;
        
        // parcurgere in adancime
        static bool t = false;
        static void PA(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < n && b[i, j] == false && matrix[i, j] == 0)
            {
                if (j == n - 1)
                    t = true;
                b[i, j] = true;
                PA(i - 1, j);
                PA(i, j - 1);
                PA(i + 1, j);
                PA(i, j + 1);
            }
        }

        static void Main(string[] args)
        {
            TextReader data = new StreamReader(@"..\..\TextFile1.txt");
            n = int.Parse(data.ReadLine());
            matrix = new int[n, n];
            b = new bool[n, n];
            int l = 0;
            string buffer;
            while ((buffer = data.ReadLine()) != null)
            {
                string[] s = buffer.Split(' ');
                for (int i = 0; i < n; i++)
                    matrix[l, i] = int.Parse(s[i]);
                l++;
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    b[i, j] = false;

            Afisare();

            //
            //metoda recursiva de parcurgere in adancime
            //
            /*for (int i = 0; i < n; i++)
                if (matrix[i, 0] == 0)
                    PA(i, 0);
            Console.WriteLine(t);*/

            Coada c = new Coada();
            for (int i = 0; i < n; i++)
                if (matrix[i, 0] == 0)
                {
                    c.AdaugInceput(new Nod(i, 0, 2));
                    matrix[i, 0] = 2;
                    break;
                }

            while (c.n != 0)
            {
                int lin = c.v[c.n - 1].l;
                int col = c.v[c.n - 1].c;
                int val = c.v[c.n - 1].value;
                c.StergereFinal();

                if (lin - 1 >= 0)
                {
                    if (matrix[lin - 1, col] == 0)
                    {
                        c.AdaugInceput(new Nod(lin - 1, col, val + 1));
                        matrix[lin - 1, col] = val + 1;
                    }
                }

                if (col - 1 >= 0)
                {
                    if (matrix[lin, col - 1] == 0)
                    {
                        c.AdaugInceput(new Nod(lin, col - 1, val + 1));
                        matrix[lin, col - 1] = val + 1;
                    }
                }

                if (lin + 1 < n)
                {
                    if (matrix[lin + 1, col] == 0)
                    {
                        c.AdaugInceput(new Nod(lin + 1, col, val + 1));
                        matrix[lin + 1, col] = val + 1;
                    }
                }

                if (col + 1 < n)
                {
                    if (matrix[lin, col + 1] == 0)
                    {
                        c.AdaugInceput(new Nod(lin, col + 1, val + 1));
                        matrix[lin, col + 1] = val + 1;
                    }
                }

                Afisare();
                c.Vizualizare();
                Console.ReadKey();
            }
        }

        static void Afisare()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

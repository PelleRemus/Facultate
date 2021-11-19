using System;

namespace PatratulDiabolic
{
    class Program
    {
        //In cate moduri se poate scrie suma 34 cu 4 valori din primele 16?
        //Ex.: 16 + 3 + 5 + 10 = 34

        static int nr = 0;
        static void Main(string[] args)
        {
            //problema poate fi rezolvata fara backtracking, pentru ca are numarul p suficient de mic (avem p for-uri)
            /*for (int i1 = 1; i1 <= 13; i1++)
                for (int i2 = i1 + 1; i2 <= 14; i2++)
                    for (int i3 = i2 + 1; i3 <= 15; i3++)
                        for (int i4 = i3 + 1; i4 <= 16; i4++)
                            if (i1 + i2 + i3 + i4 == 34)
                                nr++;
            */
            int n = 5;
            int[] sol = new int[n];
            //ProdusCartezian(0, n, sol);

            bool[] b = new bool[n];
            //Permutari(0, n, sol, b);

            int p = 3;
            //Aranjamente(0, p, n, sol, b);

            sol = new int[n + 1];
            sol[0] = 0; //pentru alte limbaje decat C#, in caz ca nu are valoarea default 0
            //Combinari(1, p, n, sol);
            
            n = 16;
            p = 4;
            sol = new int[n + 1];
            sol[0] = 0;

            PatratulDiabolic(1, p, n, sol);
            Console.WriteLine("Numarul total de sume este " + nr);
            Console.ReadKey();
        }

        static void ProdusCartezian(int k, int n, int[] sol)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(sol[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for(int i=0; i<n; i++)
                {
                    sol[k] = i;
                    ProdusCartezian(k + 1, n, sol);
                }
            }
        }

        static void Permutari(int k, int n, int[] sol, bool[] b)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(sol[i] + " ");
                Console.WriteLine();
            }
            else
                for (int i = 0; i < n; i++)
                    if (!b[i])
                    {
                        b[i] = true;
                        sol[k] = i + 1; //pentru a avea permutari incepand de la 1, nu de la 0
                        Permutari(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }

        static void Aranjamente(int k, int p, int n, int[] sol, bool[] b)
        {
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.Write(sol[i] + " ");
                Console.WriteLine();
            }
            else
                for (int i = 0; i < n; i++)
                    if (!b[i])
                    {
                        b[i] = true;
                        sol[k] = i + 1;
                        Aranjamente(k + 1, p, n, sol, b);
                        b[i] = false;
                    }
        }

        static void Combinari(int k, int p, int n, int[] sol)
        {
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write(sol[i] + " ");
                Console.WriteLine();
            }
            else
                for (int i = sol[k - 1] + 1; i <= n - p + k; i++)
                {
                    sol[k] = i;
                    Combinari(k + 1, p, n, sol);
                }
        }

        static void PatratulDiabolic(int k, int p, int n, int[] sol)
        {
            if (k > p)
            {
                int suma = 0;
                for (int i = 1; i <= p; i++)
                    suma += sol[i];
                if (suma == 34)
                {
                    for (int i = 1; i < p; i++)
                        Console.Write(sol[i]+" + ");
                    Console.Write(sol[p]+" = 34");
                    Console.WriteLine();
                    nr++;
                }
            }
            else
                for (int i = sol[k - 1] + 1; i <= n - p + k; i++)
                {
                    sol[k] = i;
                    PatratulDiabolic(k + 1, p, n, sol);
                }
        }
    }
}

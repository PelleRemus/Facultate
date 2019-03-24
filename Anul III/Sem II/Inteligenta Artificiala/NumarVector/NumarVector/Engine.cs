using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    public static class Engine
    {
        public static int n = 5, N = 100, K = 10;
        public static List<Solutie> pop = new List<Solutie>();
        public static List<Solutie> par = new List<Solutie>();
        public static Random rnd = new Random();

        public static Solutie CrossN(Solutie s1, Solutie s2)
        {
            int _n = (Gene.n * n) / 8;
            bool[] taieturi = new bool[Gene.n * n];
            for (int i = 0; i < Gene.n * n; i++)
                taieturi[i] = false;

            for (int i = 0; i < _n; i++)
            {
                int index;
                do
                {
                    index = rnd.Next(Gene.n * n);
                } while (taieturi[index]);
                taieturi[index] = true;
            }

            int[] s = new int[_n+1];
            int k = 1;
            s[0] = 0;
            for (int i = 0; i < Gene.n * n; i++)
            {
                if (taieturi[i])
                {
                    s[k] = i;
                    k++;
                }
            }

            int[] p1 = s1.getValues();
            int[] p2 = s2.getValues();
            int[] sol = new int[p1.Length];
            
            for (int i = 0; i < s.Length-1; i++)
            {
                for (int j = s[i]; j < s[i + 1]; j++)
                {
                    if (i % 2 == 0)
                        sol[j] = p1[j];
                    else
                        sol[j] = p2[j];
                }
            }

            Solutie r = new Solutie(sol);
            return r;
        }

        public static void initPop()
        {
            for (int i = 0; i < N; i++)
                pop.Add(new Solutie());
        }

        public static void Ord()
        {
            pop.Sort(delegate (Solutie a, Solutie b)
            {
                return a.FAdec().CompareTo(b.FAdec());
            });

            for (int i = 0; i < N; i++)
                pop[i].pondere = (i + 1) * (i + 1) * (i + 1);
        }

        public static void ViewPop()
        {
            foreach (Solutie sol in pop)
                sol.ViewValue();
        }

        public static void ViewPar()
        {
            foreach (Solutie sol in par)
                sol.ViewValue();
        }

        public static int AMC()
        {
            float s = 0;
            for (int j = 0; j < N; j++)
                s += pop[j].pondere;

            float t = (float)rnd.NextDouble() * s;
            int i = 0;

            while (t > 0)
            {
                t -= pop[i].pondere;
                i++;
            }
            return i - 1;
        }

        public static void SelectPop()
        {
            Ord();
            par.Clear();

            for(int i=0; i<K; i++)
            {
                par.Add(pop[AMC()]);
            }
        }
    }
}

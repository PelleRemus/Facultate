using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    public static class Engine
    {
        public static int n = 5;
        public static Random rnd = new Random();

        public static Solutie CrossN(Solutie s1, Solutie s2)
        {
            int N = (Gene.n * n) / 8;
            bool[] taieturi = new bool[Gene.n * n];
            for (int i = 0; i < Gene.n * n; i++)
                taieturi[i] = false;

            for (int i = 0; i < N; i++)
            {
                int index;
                do
                {
                    index = rnd.Next(Gene.n * n);
                } while (taieturi[index]);
                taieturi[index] = true;
            }

            int[] s = new int[N+1];
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
    }
}

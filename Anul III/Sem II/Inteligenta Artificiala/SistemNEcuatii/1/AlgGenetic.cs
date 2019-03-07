using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class AlgGenetic
    {
        public static Cromozom[] cromozomi;
        public static Cromozom[] parinti;
        public static int N;
        public static int K;

        public static void initPop(int n, int k)
        {
            N = n;
            K = k;
            cromozomi = new Cromozom[N];
            parinti = new Cromozom[K];
            for (int i=0; i<N; i++)
                cromozomi[i] = new Cromozom();
        }

        public static void Selectie()
        {
            Ordonare();
            for (int i = 0; i < K; i++)
                parinti[i] = cromozomi[i];
        }

        public static void Ordonare()
        {
            for (int i = 0; i < N - 1; i++)
                for (int j = i + 1; j < N; j++)
                    if (cromozomi[i].FAdec() > cromozomi[j].FAdec())
                    {
                        Cromozom c = cromozomi[i];
                        cromozomi[i] = cromozomi[j];
                        cromozomi[j] = c;
                    }
        }

        public static Cromozom Incrucisare()
        {
            int i, j;
            do
            {
                i = Program.rnd.Next(K);
                j = Program.rnd.Next(K);
            } while (i == j);
            Cromozom c = new Cromozom();
            c.gene[0] = parinti[i].gene[0];
            c.gene[1] = parinti[i].gene[1];
            c.gene[2] = parinti[j].gene[2];
            c.gene[3] = parinti[j].gene[3];
            c.gene[4] = parinti[j].gene[4];
            return c;
        }

        public static void UpdatePop()
        {
            for(int i=0; i<N; i++)
            {
                Cromozom temp = Incrucisare();
                temp.Mutatie();
                cromozomi[i] = temp;
            }
        }

        public static void View()
        {
            for (int i = 0; i < N; i++)
                cromozomi[i].View();
        }

        public static void ViewSol()
        {
            for (int i = 0; i < K; i++)
                parinti[i].View();
        }
    }
}

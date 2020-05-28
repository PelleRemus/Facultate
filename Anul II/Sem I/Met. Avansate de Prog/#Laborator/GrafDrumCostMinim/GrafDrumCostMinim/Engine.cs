using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDrumCostMinim
{
    public static class Engine
    {
        public static int[] dist;
        public static int n = Grafica.n;

        public static string BFS(int nS)
        {
            Coada c = new Coada();
            dist = new int[n];
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
                dist[i] = int.MaxValue;
            }

            visited[nS] = true;
            c.Adaugare(nS);
            dist[nS] = 0;

            while (c.n != 0)
            {
                int t = c.Stergere();
                for (int i = 0; i < n; i++)
                    if (Grafica.matrix[t, i] != 0)
                    {
                        if (!visited[i])
                        {
                            c.Adaugare(i);
                            visited[i] = true;
                        }

                        if (dist[t] + Grafica.matrix[t, i] < dist[i])
                            dist[i] = dist[t] + Grafica.matrix[t, i];

                        //graful este neorientat, deci trebuie si verificarea inversa
                        if (dist[i] + Grafica.matrix[t, i] < dist[t])
                            dist[t] = dist[i] + Grafica.matrix[t, i];
                    }
            }

            string result = "";
            for (int i = 0; i < n; i++)
                result += dist[i] + "  ";
            return result;
        }
    }
}

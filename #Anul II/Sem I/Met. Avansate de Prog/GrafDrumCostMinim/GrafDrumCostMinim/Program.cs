using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GrafDrumCostMinim
{
    class Program
    {
        static int[,] ma;
        static int n;
        static int[] dist;

        static void Main(string[] args)
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");
            n = int.Parse(dataLoad.ReadLine());
            ma = new int[n, n];
            dist = new int[n];

            for (int i = 0; i < n; i++)
                dist[i] = Int32.MaxValue;

            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int i = int.Parse(buffer.Split(' ')[0]);
                int j = int.Parse(buffer.Split(' ')[1]);
                int value = int.Parse(buffer.Split(' ')[2]);
                ma[i - 1, j - 1] = value;
                ma[j - 1, i - 1] = value;
            }
            Afisare();

            BFS(2);
            for (int i = 0; i < n; i++)
                Console.WriteLine(i + " " + dist[i] + " ");

            Console.ReadKey();
        }

        static void BFS(int nS)
        {
            Coada c = new Coada();
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
                visited[i] = false;

            visited[nS] = true;
            c.Adaugare(nS);
            dist[nS] = 0;

            while (c.n != 0)
            {
                int t = c.Stergere();
                for (int i = 0; i < n; i++)
                    if (ma[t, i] != 0)
                    {
                        if (!visited[i])
                        {
                            c.Adaugare(i);
                            visited[i] = true;
                        }

                        if (dist[t] + ma[t, i] < dist[i])
                            dist[i] = dist[t] + ma[t, i];

                        //graful este neorientat, deci trebuie si verificarea inversa
                        if (dist[i] + ma[t, i] < dist[t])
                            dist[t] = dist[i] + ma[t, i];
                    }
            }
        }

        static void Afisare()
        {
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                    Console.Write(ma[i,j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmulLuiPrim
{
    public class Prim
    {
        public int NumarPuncte;
        public int[,] MatDeAdiacenta;
        List<Edge> muchii = new List<Edge>();

        public Prim(string FisierSursa, int punctStart)
        {
            TextReader FisierDate = new StreamReader(FisierSursa);
            NumarPuncte = int.Parse(FisierDate.ReadLine());
            MatDeAdiacenta = new int[NumarPuncte, NumarPuncte];
            string aux;
            while ((aux = FisierDate.ReadLine()) != null)
            {
                int s = int.Parse(aux.Split(' ')[0]) - 1;
                int f = int.Parse(aux.Split(' ')[1]) - 1;
                int v = int.Parse(aux.Split(' ')[2]);
                MatDeAdiacenta[s, f] = v;
                MatDeAdiacenta[f, s] = v;
            }
            DetermArboreCostMinim(punctStart);
        }

        public void DetermArboreCostMinim(int punctStart)
        {
            List<int> aux = new List<int>();
            bool[] vizitat = new bool[NumarPuncte];
            aux.Add(punctStart);
            vizitat[punctStart] = true;

            while (aux.Count < NumarPuncte)
            {
                int costMin = int.MaxValue;
                int punctS = 0;
                int punctF = 0;
                for (int i = 0; i < aux.Count; i++)
                {
                    for (int j = 0; j < NumarPuncte; j++)
                    {
                        if (MatDeAdiacenta[aux[i], j] < costMin && !vizitat[j] && MatDeAdiacenta[aux[i], j] != 0)
                        {
                            costMin = MatDeAdiacenta[aux[i], j];
                            punctS = j;
                            punctF = i;
                        }
                    }
                }
                aux.Add(punctS);
                vizitat[punctS] = true;
                muchii.Add(new Edge(punctF, punctS, costMin));
            }
            for (int i = 0; i < muchii.Count; i++)
            {
                //Console.WriteLine((char)(muchii[i].start+65)+" "+(char)(muchii[i].final+65)+" "+ muchii[i].valoare);
                Console.WriteLine(muchii[i].start + " " + muchii[i].final + " " + muchii[i].valoare);
            }
        }

        public void ViewMat()
        {
            for (int i = 0; i < NumarPuncte; i++)
            {
                for (int j = 0; j < NumarPuncte; j++)
                {
                    Console.Write(MatDeAdiacenta[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

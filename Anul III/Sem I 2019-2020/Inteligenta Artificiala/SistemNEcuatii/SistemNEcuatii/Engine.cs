using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemNEcuatii
{
    public static class Engine
    {
        public static float[,] A;
        public static float[] T;
        public static int n, k = 30, copy = 0;
        public static float error = 1;
        public static int currGen = 0, maxGen = 10000;

        public static List<Solution> population = new List<Solution>();
        public static List<Solution> parents = new List<Solution>();
        public static int length = 1000;

        public static Random rnd = new Random();
        public static float iStartX = -100, iEndX = 100;

        public static void ReadFile(string path)
        {
            TextReader dataLoad = new StreamReader(path);
            List<string> buffer = new List<string>();
            string local;
            while((local=dataLoad.ReadLine()) != null)
            {
                buffer.Add(local);
            }
            dataLoad.Close();

            n = buffer.Count;
            A = new float[n, n];
            T = new float[n];

            for (int i = 0; i < n; i++)
            {
                string[] data = buffer[i].Split(' ');
                for (int j = 0; j < n; j++)
                    A[i, j] = float.Parse(data[j]);
                T[i] = float.Parse(data[n]);
            }
        }

        public static void InitPopulation()
        {
            for (int i = 0; i < length; i++)
                population.Add(new Solution());
        }

        public static void SortPopulation()
        {
            population.Sort(delegate (Solution a, Solution b)
            {
                return a.FAdec().CompareTo(b.FAdec());
            });
        }

        public static void Selection()
        {
            SortPopulation();
            float[] ponderi = new float[length];
            int pMin = 10, ration = 50, temp = 0;

            for(int i=length-1; i>=0; i--)
            {
                ponderi[i] = pMin + temp * ration;
                temp++;
            }


        }

        public static void UpdatePopulation()
        {
            /*parents.Clear();
            for (int i = 0; i < k; i++)
                parents.Add(population[i]);
            */
            population.Clear();

            for (int i = 0; i < copy; i++)
                population.Add(parents[i]);
            for(int i=copy; i<length; i++)
            {
                int index1, index2;
                index1 = rnd.Next(k);
                do
                {
                    index2 = rnd.Next(k);
                } while (index1 == index2);

                Solution temp = Cross(parents[index1], parents[index2]);
                population.Add(Mutation(temp));
            }
        }

        public static Solution Cross(Solution a, Solution b)
        {
            int aux = rnd.Next(1, n - 1);
            Solution toReturn = new Solution();
            for (int i = 0; i < aux; i++)
                toReturn.X[i] = a.X[i];
            for (int i = aux; i < n; i++)
                toReturn.X[i] = b.X[i];
            return toReturn;
        }

        public static Solution Mutation(Solution a)
        {
            Solution toReturn = new Solution();
            for (int i = 0; i < a.X.Length; i++)
                toReturn.X[i] = a.X[i];

            int l = rnd.Next(1, 4);
            for (int i = 0; i < l; i++)
            {
                int index = rnd.Next(n);
                toReturn.X[index] = GetRndNumber();
            }

            return toReturn;
        }

        public static float GetRndNumber()
        {
            return (float)rnd.NextDouble() * (iEndX - iStartX) + iStartX;
        }

        public static void View()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine(" = " + T[i]);
            }
        }

        public static void ViewPop()
        {
            for (int i = 0; i < 10; i++)
                population[i].View();
            Console.WriteLine();
        }
    }
}

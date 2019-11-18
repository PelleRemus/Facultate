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
        public static int n;

        public static List<Solution> population = new List<Solution>();
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
            for (int i = 0; i < length; i++)
                population[i].View();
        }
    }
}

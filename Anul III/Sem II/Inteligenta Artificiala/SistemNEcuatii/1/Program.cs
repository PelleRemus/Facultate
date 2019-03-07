using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Program
    {
        public static float[,] A;
        public static float[] T;
        public static int n;
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            Citire();
            Afisare();

            AlgGenetic.initPop(200, 10);
            int i = 0;
            do
            {
                i++;
                AlgGenetic.Selectie();
                AlgGenetic.UpdatePop();

                if (i == 1000)
                {
                    AlgGenetic.ViewSol();
                    Console.WriteLine();
                    i = 0;
                }
            } while (true);
        }

        static void Citire()
        {
            TextReader dataLoad = new StreamReader(@"../../Matrice.txt");
            n = int.Parse(dataLoad.ReadLine());
            A = new float[n, n];
            T = new float[n];
            string buffer;
            string[] x;

            for (int i=0; i<n; i++)
            {
                buffer = dataLoad.ReadLine();
                x = buffer.Split(' ');
                for (int j = 0; j < n; j++)
                    A[i, j] = float.Parse(x[j]);
            }

            buffer = dataLoad.ReadLine();
            x = buffer.Split(' ');
            for (int i = 0; i < n; i++)
                T[i] = float.Parse(x[i]);
        }

        static void Afisare()
        {
            for(int i=0; i<n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(A[i, j] + "*x" + j + "\t");
                Console.WriteLine("=" + T[i]);
            }
        }
    }
}

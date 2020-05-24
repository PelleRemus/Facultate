using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriciParalel
{
    class Program
    {
        static int[,] matrix;
        static int n;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //initializare si afisare matrice
            int n = 5;
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(2);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //initializare taskuri, calcularea sumelor in acestea
            int S = 0;
            Task<int>[] sume = new Task<int>[n];
            for (int i = 0; i < n; i++)
            {
                int index = i;
                sume[i] = Task<int>.Factory.StartNew(() =>
                {
                    int suma = 0;
                    for (int j = 0; j < n; j++)
                        suma += matrix[index, j];
                    return suma;
                });
            }

            //calcularea sumei finale, si afisarea sumelor intermediare
            for (int i = 0; i < n; i++)
            {
                Console.Write(sume[i].Result + " ");
                S += sume[i].Result;
            }
            Console.WriteLine();
            Console.WriteLine(S);
            Console.ReadKey();
        }
    }
}

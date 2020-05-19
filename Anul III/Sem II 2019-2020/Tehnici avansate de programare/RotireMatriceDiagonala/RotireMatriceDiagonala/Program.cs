using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotireMatriceDiagonala
{
    class Program
    {
        static int n;
        static int[,] matrix;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];

            //initializare matrice cu valori aleatorii
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rnd.Next(10);
            Afisare();

            //rotire pe diagonala principala
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    int aux = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = aux;
                }
            Afisare();

            //rotire pe diagonala secundara
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - i - 1; j++)
                {
                    int aux = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, n - i - 1];
                    matrix[n - j - 1, n - i - 1] = aux;
                }
            Afisare();

            Console.ReadKey();
        }

        static void Afisare()
        {
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                    Console.Write(matrix[i,j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

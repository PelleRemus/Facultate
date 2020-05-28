using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Dati dimensiunea matricei (ca sa arate bine, sa fie cel putin 10): ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i <= n / 2; i++)
                for (int j = i; j < n - i; j++)
                {
                    matrix[i, j] = 1;         //N
                    matrix[j, n - i - 1] = 2; //E
                    matrix[n - i - 1, j] = 3; //S
                    matrix[j, i] = 4;         //V
                }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

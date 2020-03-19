using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiniiColoaneDiferit
{
    class Program
    {
        static int[,] matrix;
        static int n;

        static void Main(string[] args)
        {
            n = 9;
            matrix = new int[n, n];
            
            /*for (int i = 0; i < n; i++)
                matrix[0, i] = i;

            for (int i = 1; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    bool[] v = new bool[n*n];
                    for (int k = 0; k < i; k++)
                        v[matrix[k, j]] = true;
                    for (int k = 0; k < j; k++)
                        v[matrix[i, k]] = true;

                    for (int k = 0; k < n*n; k++)
                        if (!v[k])
                        {
                            matrix[i, j] = k;
                            break;
                        }
                }
            */
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = i ^ j;

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

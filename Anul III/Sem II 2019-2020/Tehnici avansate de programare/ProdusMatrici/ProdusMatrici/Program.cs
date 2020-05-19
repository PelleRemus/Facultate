using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdusMatrici
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[,]
            {
                { 1, 2, 1 },
                { 2, 1, 1 }
            };
            int[,] B = new int[,]
            {
                { 1, 2 },
                { 2, 1 },
                { 1, 1 }
            };
            int[,] C = Inmultire(A, B);

            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                    Console.Write(C[i, j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static int[,] Inmultire(int[,] A, int[,] B)
        {
            int n = A.GetLength(0), m = A.GetLength(1);
            int[,] C = new int[n, n];
            if (n != B.GetLength(1))
                Console.WriteLine("Numarul de coloane al primei matrice trebuie sa fie egal cu numarul de linii al celei de-a doua");
            else
            {
                for (int k = 0; k < n; k++)
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < m; j++)
                            C[k, i] += A[k, j] * B[j, i];
            }
            return C;
        }

    }
}

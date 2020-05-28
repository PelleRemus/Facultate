using System;

namespace Fredkin
{
    class Program
    {
        static int[,] matrix, temp;
        static int n;

        static void Main(string[] args)
        {
            n = 11;
            matrix = new int[n + 2, n + 2];
            temp = new int[n + 2, n + 2];
            for (int i = 0; i < n + 2; i++)
                for (int j = 0; j < n + 2; j++)
                {
                    matrix[i, j] = 0;
                    temp[i, j] = 0;
                }

            matrix[n / 2 + 1, n / 2 + 1] = 1;
            matrix[n / 2, n / 2] = 1;
            matrix[n / 2 + 2, n / 2] = 1;
            matrix[n / 2, n / 2 + 2] = 1;
            matrix[n / 2 + 2, n / 2 + 2] = 1;

            Afisare();

            do
            {
                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                    {
                        int s = matrix[i - 1, j];
                        s += matrix[i, j - 1];
                        s += matrix[i + 1, j];
                        s += matrix[i, j + 1];

                        if (s % 2 == 0)
                            temp[i, j] = 0;
                        else
                            temp[i, j] = 1;
                    }

                for (int i = 0; i < n + 2; i++)
                    for (int j = 0; j < n + 2; j++)
                    {
                        matrix[i, j] = temp[i, j];
                        temp[i, j] = 0;
                    }

                Afisare();
                Console.ReadKey();
            } while (true);
            
        }

        static void Afisare()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

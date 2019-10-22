using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmIacobi
{
    class Program
    {
        static int n, k;
        static double epsilon;
        static double[,] a, alpha;
        static double[] b, beta;
        static List<double[]> x = new List<double[]>();

        static void Main(string[] args)
        {
            //initializare
            n = 3; k = 0;
            a = new double[,] {
                { 10, 2, -1 },
                { -2, -5, 1 },
                { -3, 1, -5 }
            };
            b = new double[] { 9, -1, -8 };
            epsilon = 0.0000000000001;
            alpha = new double[n, n];
            beta = new double[n];
            x.Add(new double[n]);

            //calculare alpha si beta
            for (int i = 0; i < n; i++)
            {
                if (a[i, i] != 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j == i)
                            continue;
                        alpha[i, j] = -a[i, j] / a[i, i];
                    }
                    beta[i] = b[i] / a[i, i];
                }
                else
                {
                    Console.WriteLine("Can not divide by 0.");
                    Console.ReadKey();
                    return;
                }
            }

            //algoritm
            for (int i = 0; i < n; i++)
                x[k][i] = beta[i];
            do
            {
                k++;
                x.Add(new double[n]);
                for (int i = 0; i < n; i++)
                {
                    double s = 0;
                    //Iacobi
                    /*for (int j = 0; j < n; j++)
                        s += alpha[i, j] * x[k - 1][j];*/

                    //Gauss-Seidel
                    for (int j = 0; j < i; j++)
                        s += alpha[i, j] * x[k][j];
                    for (int j = i + 1; j < n; j++)
                        s += alpha[i, j] * x[k - 1][j];

                    x[k][i] = beta[i] - s / a[i, i];
                }
            } while (MaxError() >= epsilon);

            Console.WriteLine(k);
            Afisare();
            Console.WriteLine("Correct result: 1 0 1");
            Console.ReadKey();
        }

        static double MaxError()
        {
            double max = 0;
            for (int i = 0; i < n; i++)
            {
                double aux = Math.Abs(x[k][i] - x[k - 1][i]);
                if (aux > max)
                    max = aux;
            }
            return max;
        }

        static void Afisare()
        {
            for (int i = 0; i < n; i++)
                Console.Write(x[k][i] + " ");
            Console.WriteLine();
        }
    }
}

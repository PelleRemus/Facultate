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
                { 5, 1, 1 },
                { 1, 6, 4 },
                { 1, 1, 10 }
            };
            b = new double[] { 10, 4, -7 };
            epsilon = 0.00000000000000000000001;
            alpha = new double[n, n];
            beta = new double[n];
            x.Add(new double[n]);

            for (int i = 0; i < n; i++)
            {
                if (a[i, i] != 0)
                    x[k][i] = b[i] / a[i, i];
                else
                {
                    Console.WriteLine("Can not divide by 0.");
                    Console.ReadKey();
                    return;
                }
            }

            //algoritm 
            do
            {
                k++;
                x.Add(new double[n]);
                for (int i = 0; i < n; i++)
                {
                    double s = 0;
                    //Iacobi
                    /*for (int j = 0; j < n; j++)
                        if (j != i)
                            s += a[i, j] * x[k - 1][j];*/

                    //Gauss-Seidel
                    for (int j = 0; j < i; j++)
                        s += a[i, j] * x[k][j];
                    for (int j = i + 1; j < n; j++)
                        s += a[i, j] * x[k - 1][j];
                    
                    x[k][i] = (b[i] - s) / a[i, i];
                }
            } while (MaxError() >= epsilon);

            Console.WriteLine(k);
            Afisare();
            Console.WriteLine("Correct result: 2 1 -1");
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

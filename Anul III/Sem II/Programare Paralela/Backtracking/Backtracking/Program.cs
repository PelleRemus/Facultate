using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Program
    {
        // [0..n-1]x[0..n-1]x...x[0..n-1]
        // pt 6 zaruri, produsul cartezian ar fi
        // [1..6]x[1..6]x[1..6]x[1..6]x[1..6]x[1..6]
        // adica 6^6 posibilitati
        // for 
        //    for
        //       for
        // ...(de 6 ori)

        // daca dorim elemente distincte, obtinem permutari.
        // 1 2 3 4 5
        // 1 2 3 5 4
        // 1 2 4 3 5
        // 1 2 4 5 3
        // ...
        
        // aranjamentele sunt permutari neterminate
        // 1 2 3
        // 1 3 2
        // 2 1 3
        // 2 3 1
        // 3 1 2
        // 3 2 1

        // combinarile sunt aranjamente in ordine crescatoare (sau descrescatoare)
        

        static void Main(string[] args)
        {
            /*for (int i1 = 1; i1 <= 3; i1++)
                for (int i2 = 1; i2 <= 3; i2++)
                    for (int i3 = 1; i3 <= 3; i3++)
                        Console.WriteLine(i1 + " " + i2 + " " + i3);
            */
            int n = 6;
            int p = 4;
            int[] solution = new int[n+1];
            solution[0] = 0;
            Back(1, n, p, solution);
            
            Console.ReadKey();
        }

        static void Back(int k, int n, int p, int[] solution)
        {
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write(solution[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = solution[k - 1] + 1; i <= n - p + k; i++)
                {
                    solution[k] = i;
                    Back(k + 1, n, p, solution);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnuriHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Hanoi(n, 'A', 'B', 'C');
            Console.WriteLine();
            Console.WriteLine();
            HanoiPatruTije(n, 'A', 'B', 'C', 'D');
            Console.ReadKey();
        }

        static void Hanoi (int n, char A, char B, char C)
        {
            if (n == 1) Console.Write(A+"->"+C+"   ");
            else
            {
                Hanoi(n - 1, A, C, B);
                Hanoi(1, A, B, C);
                Hanoi(n - 1, B, A, C);
            }
        }

        static void HanoiPatruTije(int n, char A, char B, char C, char D)
        {
            if (n == 1)
                Console.Write(A + "->" + D + "   ");
            else if (n == 2)
            {
                Console.Write(A + "->" + B + "   ");
                Console.Write(A + "->" + D + "   ");
                Console.Write(B + "->" + D + "   ");
            }
            else
            {
                HanoiPatruTije(n - 2, A, C, D, B);
                Console.Write(A + "->" + C + "   ");
                Console.Write(A + "->" + D + "   ");
                Console.Write(C + "->" + D + "   ");
                HanoiPatruTije(n - 2, B, A, C, D);
            }
        }
    }
}

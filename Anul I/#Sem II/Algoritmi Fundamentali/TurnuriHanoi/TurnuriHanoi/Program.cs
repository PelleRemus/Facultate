using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnuriHanoi
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Hanoi(5, 'A', 'B', 'C');
            Console.ReadKey();
        }
    }
}

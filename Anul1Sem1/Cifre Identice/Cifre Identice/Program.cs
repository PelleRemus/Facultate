using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifre_Identice
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int k=1; k<=n; k++)
                for (int i=1; i<=9; i++)
                {
                    int x = k;
                    while (x>0)
                    {
                        Console.Write(i);
                        x--;
                    }
                    Console.WriteLine();
                }
            Console.ReadKey();
        }
    }
}

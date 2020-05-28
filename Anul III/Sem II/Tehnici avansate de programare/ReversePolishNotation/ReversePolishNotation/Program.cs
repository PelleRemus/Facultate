using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Shout out to Bondoc Ioana, the creator of this masterpiece :)

            string notation1 = "2 3 +";
            string notation2 = "6 2 3 + - 3 8 2 / + * 2 +";
            string notation3 = "23 5 + 20 5 / 2 ^ - 3 *";
            Console.WriteLine(Engine.CalculateReversePolishNotation(notation1));
            Console.ReadKey();
        }
    }
}

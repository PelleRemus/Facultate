using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmulLuiPrim
{
    class Program
    {
        static void Main(string[] args)
        {
            //multumim lui Csongor pentru acest cod! =)

            Prim prim = new Prim(@"..\..\TextFile1.txt", 2);
            prim.ViewMat();
            Console.ReadKey();
        }
    }
}

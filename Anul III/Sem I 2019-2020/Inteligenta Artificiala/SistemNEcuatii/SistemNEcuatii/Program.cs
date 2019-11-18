using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemNEcuatii
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.ReadFile(@"../../TextFile1.txt");
            Engine.View();
            Engine.InitPopulation();
            Engine.SortPopulation();
            Engine.ViewPop();
            Console.ReadKey();
        }
    }
}

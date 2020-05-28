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
            Engine.Selection();
            do
            {
                Engine.UpdatePopulation();
                Engine.SortPopulation();
                Engine.ViewPop();
                Engine.currGen++;
            } while (Engine.currGen < Engine.maxGen && Engine.population[0].FAdec() > Engine.error);

            Console.ReadKey();
        }
    }
}

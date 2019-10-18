using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegresieLiniara
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Init();
            while (true)
            {
                Run();
                Console.WriteLine(Engine.FAdec());
                Console.ReadKey();
            }
        }

        public static void Run()
        {
            for (int i = 0; i < Engine.nrOfIterations; i++)
            {
                Engine.GradientDescent();
            }
        }
    }
}

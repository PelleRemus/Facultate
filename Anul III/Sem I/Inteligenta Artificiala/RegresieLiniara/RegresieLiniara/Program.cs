using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegresieLiniara
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Init();
            for(int i=0; i<1000; i++)
            {
                Run();
                Console.WriteLine(Engine.FAdec());
            }
            File.WriteAllText(@"../../extData.txt", Engine.weights);
            Console.ReadLine();
        }

        public static void Run()
        {
            for (int i = 0; i < Engine.nrOfIterations; i++)
            {
                Engine.GradientDescent();
            }
            Engine.weights += Engine.W[0, 0] + " " + Engine.W[1, 0] + "\n";
        }
    }
}

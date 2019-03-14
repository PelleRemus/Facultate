using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    class Program
    {
        static void Main(string[] args)
        {
            Solutie A = new Solutie();
            Solutie B = new Solutie();
            A.View();
            B.View();
            Solutie sol = Engine.CrossN(A, B);
            sol.View();

            Console.ReadKey();
        }
    }
}

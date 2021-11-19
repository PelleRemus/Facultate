using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafHamiltonEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            //multumim, Bondoc Ioana! Pentru acest cod minunabil

            EulerEngine.InitMatrix();
            EulerEngine.ShowMatrix();
            Console.WriteLine("Eulerian Answer:");
            EulerEngine.FindEulerian();

            HamiltonEngine.InitMatrix();
            HamiltonEngine.ShowMatrix();
            Console.WriteLine("Hamiltonian Answer:");
            HamiltonEngine.FindHamiltonian();

            Console.ReadKey();
        }
    }
}

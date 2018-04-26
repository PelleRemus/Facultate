using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciurul_lui_Eratostene
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 120000;
            bool[] v = new bool[n];
            /*int index = 2;
            //Tema: Gasiti valoarea minima pana la care trebuie sa mearga "index"
            //astfel incat sa putem inca gasi toate nr prime.
            do
            {
                //De fiecare data cand se face un pas in for, numarul prim va fi
                //prima valoare false gasita in vector.
                //Trebuie sa scrieti voi partea de afisare a nr-lor prime pt program.
                for (int i = 1; i * index < n; i++)
                    v[i * index] = true;
                while (v[index] == true)
                    index++;
                for (int i = 2; i < n; i++)
                    Console.Write(v[i] + " ");
                Console.WriteLine();
            } while (index < n-1);*/

            for (int i=2; i<n; i++)
                if (v[i]==false)
                {
                    Console.Write(i+" ");
                    int k = i;
                    while (k<n)
                    {
                        v[k] = true;
                        k += i;
                    }
                }
            Console.ReadKey();
        }
    }
}

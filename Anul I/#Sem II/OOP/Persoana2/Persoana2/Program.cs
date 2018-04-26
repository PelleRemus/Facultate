using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persoana2
{
    class Persoana : IComparer
    {
        string nume;
        int varsta;
        public Persoana(string n, int v)
        {
            nume = n;
            varsta = v;
        }

        public int Compare(object x, object y)
        {
            Persoana p1 = x as Persoana;
            Persoana p2 = y as Persoana;
            return string.Compare(p1.nume, p2.nume);
        }
        public override string ToString()
        {
            return nume + ", " + varsta + " ani";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persoana p = new Persoana("George", 20);
            ArrayList persoane = new ArrayList();
            persoane.Add(new Persoana("David", 21));
            persoane.Add(new Persoana("Andrei", 20));
            persoane.Sort(p);
            Console.WriteLine(persoane[0] + "   " + persoane[1]);
            Console.ReadKey();
        }
    }
}

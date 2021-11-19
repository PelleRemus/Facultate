using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persoana1
{
    class Persoana: IComparable
    {
        string nume;
        int varsta;
        public Persoana(string n, int v)
        {
            nume = n;
            varsta = v;
        }

        public int CompareTo(object ob)
        {
            Persoana pers = ob as Persoana;
            return string.Compare(nume, pers.nume);
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
            ArrayList persoane = new ArrayList();
            persoane.Add(new Persoana("Andrei", 21));
            persoane.Add(new Persoana("David", 20));
            persoane.Sort();
            Console.WriteLine(persoane[0]+"   "+persoane[1]);
            Console.ReadKey();
        }
    }
}

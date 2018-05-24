using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfate
{
    interface IForme2D
    {
        double Aria();
        double Perimetru();
        string denumire
        {
            get;
            set;
        }
    }

    class Cerc : IForme2D
    {
        string nume;
        public float r;

        public Cerc(string s)
        {
            denumire = s;
            r = int.Parse(nume.Split(' ')[1]);
        }
        public string denumire
        {
            get { return nume; }
            set { nume = value; }
        }

        public double Aria()
        {
            return Math.PI * r * r;
        }
        public double Perimetru()
        {
            return 2 * Math.PI * r;
        }

        public override string ToString()
        {
            return "Cerc, Raza: " + r + ", Aria: " + Aria() + ", Lungime: " + Perimetru();
        }
    }

    class Patrat : IForme2D
    {
        string nume;
        public float l;

        public Patrat(string s)
        {
            denumire = s;
            l = int.Parse(nume.Split(' ')[1]);
        }
        public string denumire
        {
            get { return nume; }
            set { nume = value; }
        }

        public double Aria()
        {
            return l * l;
        }
        public double Perimetru()
        {
            return 4 * l;
        }

        public override string ToString()
        {
            return "Patrat, Lungimea laturii: " + l + ", Aria: " + Aria() + ", Perimetru: " + Perimetru();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cerc c = new Cerc("raza 7");
            Patrat p = new Patrat("lungimea 5");
            Console.WriteLine(c);
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}

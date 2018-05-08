using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_de_nume
{
    class Nume
    {
        int size;
        List<string> nume = new List<string>();

        public Nume(int size, string nume)
        {
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                this.nume.Add(nume);
            }
        }

        public string this[int index]
        {
            get
            {
                return nume[index];
            }
            set
            {
                nume[index] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Nume studenti = new Nume(8, "strudel");
            studenti[2] = "Andrei";
            Console.WriteLine(studenti[2]);
        }
    }
}

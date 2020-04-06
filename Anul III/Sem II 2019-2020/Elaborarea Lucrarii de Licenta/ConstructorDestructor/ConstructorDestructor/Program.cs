using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDestructor
{
    public class Complex
    {
        // z = real + imaginar * i
        public int real, imaginar;

        // Constructorul este o metoda ce se apeleaza la crearea unui obiect.
        // Scopul sau este de a da valori initiale proprietatilor acelui obiect.
        public Complex(int real = 0, int imaginar = 0)
        {
            this.real = real;
            this.imaginar = imaginar;
            // Pentru a vedea ca metoda constructor se apeleaza la crearea obiectului, afisam obiectul creat.
            Console.WriteLine("Am creat numarul complex z = {0} + {1} * i", real, imaginar);
        }

        // Destructorul este o metoda ce se apeleaza atunci cand un obiect nu mai este folosit,
        // si acesta urmeaza sa fie sters din memorie. Inainte de asta, destructorul se va apela automat
        // si putem sa mai folosim proprietatile obiectului o ultima data.
        ~Complex()
        {
            Console.WriteLine("Se va sterge numarul complex z = {0} + {1} * i", real, imaginar);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Pentru z1, nu se va apela destructorul pentru ca vedem output-ul inainte sa iesim din metoda Main
            Complex z1 = new Complex(1, 2);
            // Pentru z2, destructorul va fi apelat pentru ca iesim din metoda NewComplex inainte sa vedem output-ul
            NewComplex();
            // Folosim metoda Collect a GarbageCollector-ului pentru a distruge numarul complex z2
            GC.Collect();
            Console.ReadKey();
        }

        static void NewComplex()
        {
            Complex z2 = new Complex(3, 4);
        }
    }
}

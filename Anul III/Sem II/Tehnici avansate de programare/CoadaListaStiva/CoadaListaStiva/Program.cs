using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoadaListaStiva
{
    class Program
    {
        static void Main(string[] args)
        {
            //va fi nevoie sa aratati cum functioneaza clasa ceruta
            Stiva s = new Stiva();
            s.AdaugareFinal(1); s.AdaugareFinal(2); s.AdaugareFinal(3);
            s.Afisare();
            Console.WriteLine(s.StergereFinal());
            s.AdaugareFinal(1);
            s.Afisare();
            Console.WriteLine();

            Coada c = new Coada();
            c.AdaugareInceput(1); c.AdaugareInceput(2); c.AdaugareInceput(3);
            c.Afisare();
            Console.WriteLine(c.StergereFinal());
            c.AdaugareInceput(1);
            c.Afisare();
            Console.WriteLine();

            ListaOrdonata l = new ListaOrdonata();
            l.AdaugareOrdonata(4); l.AdaugareOrdonata(2);
            l.AdaugareOrdonata(3); l.AdaugareOrdonata(1);
            l.Afisare();
            l.AdaugareOrdonata(2); l.AdaugareOrdonata(2);
            l.Afisare();
            l.StergereElement(2);
            l.Afisare();

            Console.ReadKey();
        }
    }
}

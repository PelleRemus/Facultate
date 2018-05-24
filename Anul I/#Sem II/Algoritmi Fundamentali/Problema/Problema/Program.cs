using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema
{
    class Program
    {
        static void Main(string[] args)
        {
            AngajatiInterface listaAngajati = new AngajatiInterface();
            listaAngajati.Load();
            listaAngajati.View();
            Console.WriteLine();

            listaAngajati.Add("Ion Vasile 2018.05.24");
            listaAngajati.View();
            Console.WriteLine();

            listaAngajati.Remove("Ion", "Vasile");
            listaAngajati.View();
            Console.WriteLine();

            listaAngajati.SortbyName();
            listaAngajati.Write(@"..\..\TextFile2.txt");

            listaAngajati.SortbyDate();
            listaAngajati.Write(@"..\..\TextFile3.txt");

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader dataload = new StreamReader(@"../../TextFile1.txt");
            int k = int.Parse(dataload.ReadLine());
            string buffer = dataload.ReadLine();
            string[] s = buffer.Split(' ');

            Lista lista = new Lista();
            Lista listaPara = new Lista();
            Lista listaImpara = new Lista();

            for (int i = 0; i < s.Length; i++)
            {
                lista.Add(int.Parse(s[i]));
                if (lista.v[i] % 2 == 0)
                    listaPara.Add(lista.v[i]);
                else
                    listaImpara.Add(lista.v[i]);
            }

            Console.WriteLine("Exercitiul 1:");
            lista.Afisare();
            lista.Permutare(k);
            lista.Afisare();
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Exercitiul 2:");
            listaPara.Afisare();
            listaImpara.Afisare();
            Console.ReadKey();
        }
    }
}

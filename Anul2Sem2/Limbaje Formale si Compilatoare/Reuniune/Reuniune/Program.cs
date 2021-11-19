using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuniune
{
    class Program
    {
        static void Main(string[] args)
        {
            AFN A1 = new AFN(@"../../Automat1.txt");
            AFN A2 = new AFN(@"../../Automat2.txt");

            Console.WriteLine("Automatul 1:");
            Console.WriteLine(A1);

            VerificareA1:
            Console.Write("Verificati un cuvant: ");
            string cuvant = Console.ReadLine();

            if (A1.DeltaStelat("s0", cuvant))
                Console.WriteLine("Cuvantul " + cuvant + " apartine limbajului automatului 1.");
            else
                Console.WriteLine("Cuvantul " + cuvant + " nu apartine limbajului automatului 1.");
            Console.WriteLine();

            Console.Write("Doriti sa verificati inca un cuvant? (da / nu) ");
            if (Console.ReadLine() == "da")
            {
                Console.WriteLine();
                goto VerificareA1;
            }

            Console.WriteLine();
            Console.WriteLine("Automatul 2:");
            Console.WriteLine(A2);

            VerificareA2:
            Console.Write("Verificati un cuvant: ");
            cuvant = Console.ReadLine();

            if (A2.DeltaStelat("s0", cuvant))
                Console.WriteLine("Cuvantul " + cuvant + " apartine limbajului automatului 2.");
            else
                Console.WriteLine("Cuvantul " + cuvant + " nu apartine limbajului automatului 2.");
            Console.WriteLine();

            Console.Write("Doriti sa verificati inca un cuvant? (da / nu) ");
            if (Console.ReadLine() == "da")
            {
                Console.WriteLine();
                goto VerificareA2;
            }
            Console.WriteLine();

            AFN A = new AFN();
            A.alfabet = A1.alfabet;

            int nrA1 = A1.stari.Length, nrA2 = A2.stari.Length;
            int nrStari = nrA1 + nrA2 + 1;
            A.stari = new string[nrStari];
            for (int i = 0; i < nrStari; i++)
                A.stari[i] = "s" + i;

            A.stareInitiala = "s0";

            int stareActuala;
            int nrStariFinale = A1.stariFinale.Length + A2.stariFinale.Length;
            A.stariFinale = new string[nrStariFinale];
            for (int i = 0; i < A1.stariFinale.Length; i++)
            {
                stareActuala = int.Parse(A1.stariFinale[i][1].ToString()) + 1;
                A.stariFinale[i] = "s" + stareActuala;
            }
            for (int i = A1.stariFinale.Length; i < nrStariFinale; i++)
            {
                stareActuala = int.Parse(A2.stariFinale[i - A1.stariFinale.Length][1].ToString()) + nrA1 + 1;
                A.stariFinale[i] = "s" + stareActuala;
            }

            A.tranzitii = new List<Delta>();
            for(int i=0; i<A1.tranzitii.Count; i++)
                if(A1.tranzitii[i].stare1=="s0")
                {
                    stareActuala = int.Parse(A1.tranzitii[i].stare2[1].ToString()) + 1;
                    A.tranzitii.Add(new Delta("s0", A1.tranzitii[i].litera, "s" + stareActuala));
                }
            for (int i = 0; i < A2.tranzitii.Count; i++)
                if (A2.tranzitii[i].stare1 == "s0")
                {
                    stareActuala = int.Parse(A2.tranzitii[i].stare2[1].ToString()) + nrA1 + 1;
                    A.tranzitii.Add(new Delta("s0", A2.tranzitii[i].litera, "s" + stareActuala));
                }

            for(int i=0; i< A1.tranzitii.Count; i++)
            {
                string stare1 = "s" + (int.Parse(A1.tranzitii[i].stare1[1].ToString()) + 1);
                string stare2 = "s" + (int.Parse(A1.tranzitii[i].stare2[1].ToString()) + 1);
                A.tranzitii.Add(new Delta(stare1, A1.tranzitii[i].litera, stare2));
            }
            for (int i = 0; i < A2.tranzitii.Count; i++)
            {
                string stare1 = "s" + (int.Parse(A2.tranzitii[i].stare1[1].ToString()) + nrA1 + 1);
                string stare2 = "s" + (int.Parse(A2.tranzitii[i].stare2[1].ToString()) + nrA1 + 1);
                A.tranzitii.Add(new Delta(stare1, A2.tranzitii[i].litera, stare2));
            }

            Console.WriteLine("Automatul generat de reuniunea automatelor:");
            Console.WriteLine(A);

            VerificareA:
            Console.Write("Verificati un cuvant: ");
            cuvant = Console.ReadLine();

            if (A.DeltaStelat("s0", cuvant))
                Console.WriteLine("Cuvantul " + cuvant + " apartine limbajului reuniunii.");
            else
                Console.WriteLine("Cuvantul " + cuvant + " nu apartine limbajului reuniunii.");
            Console.WriteLine();

            Console.Write("Doriti sa verificati inca un cuvant? (da / nu) ");
            if (Console.ReadLine() == "da")
            {
                Console.WriteLine();
                goto VerificareA;
            }

            Console.ReadKey();
        }
    }
}

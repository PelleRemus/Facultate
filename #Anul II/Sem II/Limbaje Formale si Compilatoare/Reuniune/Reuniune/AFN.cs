using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuniune
{
    public class AFN
    {
        public char[] alfabet;
        public string[] stari;
        public string stareInitiala;
        public string[] stariFinale;
        public List<Delta> tranzitii;

        public AFN()
        {

        }

        public AFN(string path)
        {
            TextReader dataLoad = new StreamReader(path);

            string buffer = dataLoad.ReadLine();
            string[] litere = buffer.Split(' ');

            alfabet = new char[litere.Length];
            for (int i = 0; i < litere.Length; i++)
                alfabet[i] = char.Parse(litere[i]);

            buffer = dataLoad.ReadLine();
            stari = buffer.Split(' ');

            stareInitiala = dataLoad.ReadLine();

            buffer = dataLoad.ReadLine();
            stariFinale = buffer.Split(' ');

            tranzitii = new List<Delta>();
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                string[] caractere = buffer.Split(' ');
                tranzitii.Add(new Delta(caractere[0], char.Parse(caractere[1]), caractere[2]));
            }
        }

        public bool DeltaStelat(string stare, string cuvant)
        {
            for (int i = 0; i < tranzitii.Count; i++)
            {
                if (tranzitii[i].stare1 == stare && tranzitii[i].litera == cuvant[0])
                {
                    Console.Write(tranzitii[i].View(cuvant));
                    if (cuvant.Length == 1)
                    {
                        for (int j = 0; j < stariFinale.Length; j++)
                            if (tranzitii[i].stare2 == stariFinale[j])
                            {
                                Console.WriteLine(" -> stare finala");
                                return true;
                            }
                        Console.WriteLine(" -> nu este stare finala");
                        return false;
                    }
                    Console.WriteLine();
                    if (DeltaStelat(tranzitii[i].stare2, cuvant.Substring(1)))
                        return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder("A automat A(S, d, s0, T)\n");
            s.Append("A = { ");
            for (int i = 0; i < alfabet.Length - 1; i++)
                s.Append(alfabet[i] + ", ");
            s.Append(alfabet[alfabet.Length - 1] + " }\n");

            s.Append("S = { ");
            for (int i = 0; i < stari.Length - 1; i++)
                s.Append(stari[i] + ", ");
            s.Append(stari[stari.Length - 1] + " }\n");

            s.Append("T = { ");
            for (int i = 0; i < stariFinale.Length - 1; i++)
                s.Append(stariFinale[i] + ", ");
            s.Append(stariFinale[stariFinale.Length - 1] + " }\n");

            s.Append("Functia de tranzitie delta (d):\n");
            for (int i = 0; i < tranzitii.Count; i++)
                s.Append(tranzitii[i] + "\n");

            return s.ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace AFN_AFD
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomatFinit AFN = new AutomatFinit(@"../../../AFN.txt");
            Console.WriteLine(AFN);

            Console.Write("Introduceti cuvantul pentru care doriti sa faceti verificarea: ");
            string cuvant = Console.ReadLine();

            Console.WriteLine("Delta stelat al AFN-ului pentru cuvantul dat:");
            if (AFN.DeltaStelat("s0", cuvant))
                Console.WriteLine("Cuvantul " + cuvant + " apartine limbajului generat de AFN.");
            else
                Console.WriteLine("Cuvantul " + cuvant + " nu apartine limbajului generat de AFN.");

            Console.WriteLine();
            Console.WriteLine("Transformarea in AFD:");
            AutomatFinit AFD = new AutomatFinit();
            AFD.alfabet = AFN.alfabet;
            AFD.stareInitiala = AFN.stareInitiala;

            List<List<string>> stari = new List<List<string>>();
            List<string> stariFinale = new List<string>();
            List<Delta> tranzitii = new List<Delta>();

            stari.Add(new List<string> { AFD.stareInitiala });
            for (int i = 0; i < stari.Count; i++)
                for (int x = 0; x < AFD.alfabet.Length; x++)
                {
                    List<string> aux = new List<string>();
                    for (int j = 0; j < AFN.tranzitii.Count; j++)
                        for (int k = 0; k < stari[i].Count; k++)
                            if (AFN.tranzitii[j].stare1 == stari[i][k]
                                && AFN.tranzitii[j].litera == AFD.alfabet[x]
                                && !aux.Contains(AFN.tranzitii[j].stare2))
                            {
                                aux.Add(AFN.tranzitii[j].stare2);
                            }

                    aux.Sort();
                    if (aux.Count > 0)
                    {
                        tranzitii.Add(new Delta(TransformareStare(stari[i]), AFD.alfabet[x], TransformareStare(aux)));

                        bool ok = true;
                        for (int j = 0; j < stari.Count; j++)
                            if (stari[j].Count == aux.Count)
                            {
                                bool ok2 = true;
                                for (int k = 0; k < stari[j].Count; k++)
                                    if (stari[j][k] != aux[k])
                                    {
                                        ok2 = false;
                                        break;
                                    }
                                if (ok2)
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        if (ok)
                            stari.Add(aux);
                    }
                }

            AFD.stari = new string[stari.Count];
            for(int i=0; i<stari.Count; i++)
                AFD.stari[i] = TransformareStare(stari[i]);

            for(int i=0; i<AFN.stariFinale.Length; i++)
                for(int j=0; j<stari.Count; j++)
                    if (stari[j].Contains(AFN.stariFinale[i]) && !stariFinale.Contains(TransformareStare(stari[j])))
                        stariFinale.Add(TransformareStare(stari[j]));
            AFD.stariFinale = stariFinale.ToArray();

            AFD.tranzitii = tranzitii;
            Console.WriteLine(AFD);

            Console.WriteLine("Delta stelat al AFD-ului pentru cuvantul dat:");
            if (AFD.DeltaStelat("s0", cuvant))
                Console.WriteLine("Cuvantul " + cuvant + " apartine limbajului generat de AFD.");
            else
                Console.WriteLine("Cuvantul " + cuvant + " nu apartine limbajului generat de AFD.");
            
        }

        static string TransformareStare(List<string> stari)
        {
            string s = "s";
            for (int i = 0; i < stari.Count; i++)
                s += stari[i][1];
            return s;
        }
    }
}

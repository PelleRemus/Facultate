using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problema
{
    public class Data
    {
        public int an, luna, zi;
        public Data(string text)
        {
            string[] t = text.Split('.');
            an = int.Parse(t[0]);
            luna = int.Parse(t[1]);
            zi = int.Parse(t[2]);
        }

        public void NrMaxZile()
        {
            switch (luna)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                    {
                        zi = 31;
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        zi = 30;
                        break;
                    }
                case 2:
                    {
                        if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
                            zi = 29;
                        else zi = 28;
                        break;
                    }
            }
        }


        public static bool operator ==(Data d1, Data d2)
        {
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi == d2.zi) return true;
            return false;
        }
        public static bool operator !=(Data d1, Data d2)
        {
            if (d1 == d2) return false;
            return true;
        }

        public static bool operator <(Data d1, Data d2)
        {
            if (d1.an < d2.an) return true;
            if (d1.an == d2.an && d1.luna < d2.luna) return true;
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi < d2.zi) return true;
            return false;
        }
        public static bool operator >(Data d1, Data d2)
        {
            if (d1 < d2 || d1 == d2) return false;
            return true;
        }

        public static bool operator <=(Data d1, Data d2)
        {
            if (d1 > d2) return false;
            return true;
        }
        public static bool operator >=(Data d1, Data d2)
        {
            if (d1 < d2) return false;
            return true;
        }

        public static Data operator -(Data d1, Data d2)
        {
            Data d = new Data("0.0.0");
            d.an = d1.an; d.luna = d1.luna; d.zi = d1.zi;
            if(d2.zi>d.zi)
            {
                d.luna--;
                int z = d2.zi - d1.zi;
                d.NrMaxZile();
                d.zi -= z;
            }
            if(d2.luna>d.luna)
            {
                d.an--;
                int l = d2.luna - d1.luna;
                d.luna = 12 - l;
            }
            d.an -= d2.an;
            return d;
        }

        public int NrZile()
        {
            int nrZile = 0;
            for (int i = 0; i < an; i++)
            {
                if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                    nrZile += 366;
                else nrZile += 365;
            }
            for (int i = 1; i<luna; i++)
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        {
                            nrZile += 31;
                            break;
                        }
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        {
                            nrZile += 30;
                            break;
                        }
                    case 2:
                        {
                            if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
                                nrZile += 29;
                            else nrZile += 28;
                            break;
                        }
                }
            nrZile += zi;
            return nrZile;
        }

        public override string ToString()
        {
            return an + "." + luna + "." + zi;
        }
    }

    public class Persoana
    {
        public string nume;
        public string prenume;
        public Data data;

        public Persoana(string text)
        {
            string[] t = text.Split(' ');
            nume = t[0];
            prenume = t[1];
            data = new Data(t[2]);
        }

        public static bool operator <(Persoana p1, Persoana p2)
        {
            if (p1.nume[0] < p2.nume[0]) return true;
            return false;
        }
        public static bool operator >(Persoana p1, Persoana p2)
        {
            if (p1 < p2) return false;
            return true;
        }

        public override string ToString()
        {
            return nume + " " + prenume + " " + data;
        }
    }

    interface IAngajati
    {
        void Add(Persoana p);
        void Remove(Persoana p);
        void SortName();
        void SortDate();
    }

    public class Angajati : IAngajati
    {
        public List<Persoana> angajati = new List<Persoana>();
        public Angajati()
        {
            TextReader text = new StreamReader(@"..\..\TextFile1.txt");
            string buffer;
            while ((buffer = text.ReadLine()) != null)
                Add(new Persoana(buffer));
        }

        public void AfisareFisier(string text, Data d)
        {
            TextWriter file = new StreamWriter(text);
            foreach (Persoana a in angajati)
            {
                Data date = d - a.data;
                file.WriteLine(a + ", " + date.an + " ani, " + date.luna + " luni, " + date.zi + "zile.");
            }
            file.Close();
        }
        public void AfisareFisier(string text)
        {
            TextWriter file = new StreamWriter(text);
            foreach (Persoana a in angajati)
                file.WriteLine(a);
            file.Close();
        }

        public void Add(Persoana p)
        {
            angajati.Add(p);
        }
        public void Remove(Persoana p)
        {
            angajati.Remove(p);
        }

        public void SortName()
        {
            for (int j = 1; j < angajati.Count; j++)
                for (int i = j; i > 0; i--)
                    if (angajati[i] < angajati[i - 1])
                    {
                        Persoana aux = angajati[i];
                        angajati[i] = angajati[i - 1];
                        angajati[i - 1] = aux;
                    }
        }
        public void SortDate()
        {
            for (int j = 1; j < angajati.Count; j++)
                for (int i = j; i > 0; i--)
                    if (angajati[i].data < angajati[i - 1].data)
                    {
                        Persoana aux = angajati[i];
                        angajati[i] = angajati[i - 1];
                        angajati[i - 1] = aux;
                    }
        }

        public void Vizualizare()
        {
            foreach (Persoana p in angajati)
                Console.WriteLine(p);
        }

        public Persoana this[int index]
        {
            get
            {
                return angajati[index];
            }
            set
            {
                angajati[index] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Angajati lista = new Angajati();
            lista.Vizualizare();
            Console.WriteLine();
            string s = "Ion Vasile 2018.05.24";
            Persoana p = new Persoana(s);

            lista.Add(p);
            lista.Vizualizare();
            Console.WriteLine();

            lista.Remove(p);
            lista.Vizualizare();
            Console.WriteLine();

            lista.SortName();
            lista.AfisareFisier(@"..\..\TextFile2.txt");

            lista.SortDate();
            s = DateTime.Today.ToString();
            string[] local = s.Split('.');
            string S = local[2].Split(' ')[0] + "." + local[1] + "." + local[0];
            Data d = new Data(S);
            lista.AfisareFisier(@"..\..\TextFile3.txt", d);

            Console.WriteLine(lista[0]);
            Console.ReadKey();
        }
    }
}

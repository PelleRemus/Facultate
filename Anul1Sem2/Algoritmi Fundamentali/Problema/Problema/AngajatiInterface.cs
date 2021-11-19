using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problema
{
    interface IAngajati
    {
        void Load();
        void Write(string text);
        void Add(string text);
        void Remove(string Nume, string Prenume);
    }

    public class AngajatiInterface : IAngajati
    {
        public List<Angajat> list = new List<Angajat>();

        public void Add(string text)
        {
            list.Add(new Angajat(text));
        }

        public void Load()
        {
            TextReader data = new StreamReader(@"..\..\TextFile1.txt");
            string buffer;
            while ((buffer = data.ReadLine()) != null)
                list.Add(new Angajat(buffer));
        }

        public void Remove(string Nume, string Prenume)
        {
            list.RemoveAll(delegate (Angajat a) { return a.nume == Nume && a.prenume == Prenume; });
        }

        public void Write(string text)
        {
            TextWriter data = new StreamWriter(text);
            foreach (Angajat a in list)
                data.WriteLine(a);
            data.Close();
        }

        public void SortbyName()
        {
            list.Sort(delegate (Angajat a, Angajat b) { return a.nume.CompareTo(b.nume); });
        }

        public void SortbyDate()
        {
            list.Sort(delegate (Angajat a, Angajat b) { return b.data.CompareTo(a.data); });
        }

        public void View()
        {
            foreach (Angajat a in list)
                Console.WriteLine(a);
        }
    }
}

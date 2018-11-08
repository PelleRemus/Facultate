using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adresa
{
    public abstract class Adresa
    {
        public string nume;
        public string telefon;
        public TipAdresa type;
        protected TextWriter dataSave;

        public Adresa(string n, string t)
        {
            nume = n;
            telefon = t;
        }

        public abstract void Add(string s);

        public virtual void Save(string fileName)
        {
            dataSave = new StreamWriter(fileName);
            dataSave.WriteLine("Begin");
            dataSave.WriteLine(nume);
            dataSave.WriteLine(telefon);
        }
    }
}

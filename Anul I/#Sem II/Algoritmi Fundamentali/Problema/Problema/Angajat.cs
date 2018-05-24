using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema
{
    public class Angajat
    {
        public string nume;
        public string prenume;
        public DateTime data;

        public Angajat(string text)
        {
            string[] local = text.Split(' ');
            nume = local[0];
            prenume = local[1];
            data = DateTime.Parse(local[2]);
        }

        public override string ToString()
        {
            return nume + " " + prenume + " " + data;
        }
    }
}

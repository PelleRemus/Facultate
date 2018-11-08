using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresa
{
    public class AdresaMedie : Adresa
    {
        public List<string> locatie;

        public AdresaMedie(string n, string t) : base(n, t)
        {
            locatie = new List<string>();
            type = TipAdresa.medie;
        }

        public override void Add(string s)
        {
            locatie.Add(s);
        }

        public override void Save(string fileName)
        {
            base.Save(fileName);

            foreach (string s in locatie)
                dataSave.WriteLine(s);

            dataSave.WriteLine("End");
            dataSave.WriteLine();
            dataSave.Close();
        }
    }
}

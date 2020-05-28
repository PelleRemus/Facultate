using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresa
{
    public class AdresaExtinsa : Adresa
    {
        public List<string> locatie;
        public string email;
        public List<string> dateComp;

        public AdresaExtinsa(string n, string t, string email) : base(n, t)
        {
            locatie = new List<string>();
            dateComp = new List<string>();
            this.email = email;
            type = TipAdresa.extinsa;
        }

        public override void Add(string s)
        {
            locatie.Add(s);
        }

        public void AddDataC(string s)
        {
            dateComp.Add(s);
        }

        public override void Save(string fileName)
        {
            base.Save(fileName);

            foreach (string s in locatie)
                dataSave.WriteLine(s);

            dataSave.WriteLine(email);

            foreach (string s in dateComp)
                dataSave.WriteLine(s);

            dataSave.WriteLine("End");
            dataSave.WriteLine();
            dataSave.Close();
        }
    }
}

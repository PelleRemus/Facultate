using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresa
{
    public class AdresaSimpla : Adresa
    {
        public AdresaSimpla(string n, string t) : base(n, t)
        {
            type = TipAdresa.simpla;
        }

        public override void Add(string s)
        {
            throw new NotImplementedException();
        }

        public override void Save(string fileName)
        {
            base.Save(fileName);
            dataSave.WriteLine("End");
            dataSave.WriteLine();
            dataSave.Close();
        }
    }
}

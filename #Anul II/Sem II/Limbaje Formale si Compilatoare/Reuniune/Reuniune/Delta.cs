using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuniune
{
    public class Delta
    {
        public string stare1;
        public char litera;
        public string stare2;

        public Delta(string stare1, char litera, string stare2)
        {
            this.stare1 = stare1;
            this.litera = litera;
            this.stare2 = stare2;
        }

        public string View(string cuvant)
        {
            return "d(" + stare1 + ", " + cuvant + ") = " + stare2;
        }

        public override string ToString()
        {
            return "d(" + stare1 + ", " + litera + ") = " + stare2;
        }
    }
}

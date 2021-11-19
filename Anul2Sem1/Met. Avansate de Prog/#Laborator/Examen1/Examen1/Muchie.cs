using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    public class Muchie
    {
        public int nodS, nodE;

        public Muchie(string s)
        {
            nodS = int.Parse(s.Split(' ')[0]);
            nodE = int.Parse(s.Split(' ')[1]);
        }

        public override string ToString()
        {
            return nodS + " " + nodE;
        }
    }
}

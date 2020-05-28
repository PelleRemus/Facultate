using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmulLuiPrim
{
    public class Edge
    {
        public int start, final, valoare;
        public Edge(int start, int final, int valoare)
        {
            this.start = start;
            this.final = final;
            this.valoare = valoare;
        }
    }
}

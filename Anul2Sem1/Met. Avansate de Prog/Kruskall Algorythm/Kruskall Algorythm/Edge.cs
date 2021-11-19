using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskall_Algorythm
{
    public class Edge
    {
        public int nodS;
        public int nodE;
        public int cost;

        public Edge(int s, int f, int value)
        {
            nodS = s;
            nodE = f;
            cost = value;
        }

        public override string ToString()
        {
            return nodS + " " + nodE + " " + cost;
        }
    }
}

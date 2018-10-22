using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    public class UnitAttribute : Attribute
    {
        public int AS, DS, size;

        public UnitAttribute(int a, int d, int s)
        {
            AS = a;
            DS = d;
            size = s;
        }
    }
}

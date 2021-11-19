using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coada
{
    public class Nod
    {
        public int l;
        public int c;
        public int value;

        public Nod(int i, int j, int v)
        {
            l = i;
            c = j;
            value = v;
        }

        public void View()
        {
            Console.WriteLine("(" + l + ", " + c + ", " + value + ")");
        }
    }
}

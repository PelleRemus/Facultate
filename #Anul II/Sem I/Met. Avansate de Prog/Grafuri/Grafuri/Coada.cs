using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    public class Coada
    {
        public int[] v;
        public int n;

        public Coada()
        {
            n = 0;
            v = new int[n];
        }

        public void Add(int value)
        {
            n++;
            int[] t = new int[n];
            for (int i = 0; i < n - 1; i++)
                t[i + 1] = v[i];
            t[0] = value;
            v = t;
        }

        public int Delete()
        {
            int value = v[n - 1];
            n--;
            int[] t = new int[n];
            for (int i = 0; i < n; i++)
                t[i] = v[i];
            v = t;
            return value;
        }
    }
}

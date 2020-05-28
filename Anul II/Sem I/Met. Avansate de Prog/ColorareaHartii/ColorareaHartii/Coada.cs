using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorareaHartii
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

        public void Add(int val)
        {
            n++;
            int[] t = new int[n];
            t[0] = val;

            for(int i=0; i<n-1; i++)
            {
                t[i + 1] = v[i];
            }

            v = t;
        }

        public int Del()
        {
            int val = v[n - 1];
            n--;
            int[] t = new int[n];

            for (int i = 0; i < n; i++)
                t[i] = v[i];

            v = t;
            return val;
        }
    }
}

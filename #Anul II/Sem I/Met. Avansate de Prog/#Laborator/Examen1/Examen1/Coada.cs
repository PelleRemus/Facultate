using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    public class Coada
    {
        public Muchie[] v;
        public int n;

        public Coada()
        {
            n = 0;
            v = new Muchie[0];
        }

        public void Add(string value)
        {
            n++;
            Muchie[] t = new Muchie[n];
            for (int i = 0; i < n - 1; i++)
                t[i] = v[i];
            t[n - 1] = new Muchie(value);
            v = t;
        }

        public Muchie Del()
        {
            Muchie value = v[0];
            n--;
            Muchie[] t = new Muchie[n];
            for (int i = 0; i < n; i++)
                t[i] = v[i + 1];
            v = t;
            return value;
        }

        public void View(int[] s)
        {
            for (int i = 0; i < n; i++)
                Console.Write(v[s[i]] + ", ");
            Console.WriteLine();
        }
    }
}

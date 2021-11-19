using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coada
{
    public class Coada
    {
        public Nod[] v;
        public int n;

        public Coada()
        {
            v = new Nod[0];
            n = 0;
        }

        public void AdaugInceput(Nod x)
        {
            Nod[] s = new Nod[n];
            for (int i = 0; i < n; i++)
                s[i] = v[i];
            n++;
            v = new Nod[n];
            for (int i = 1; i < n; i++)
                v[i] = s[i - 1];
            v[0] = x;
        }

        public void AdaugFinal(Nod x)
        {
            Nod[] s = new Nod[n];
            for (int i = 0; i < n; i++)
                s[i] = v[i];
            n++;
            v = new Nod[n];
            for (int i = 0; i < n - 1; i++)
                v[i] = s[i];
            v[n - 1] = x;
        }

        public void StergereInceput()
        {
            Nod[] s = new Nod[n - 1];
            for (int i = 1; i < n; i++)
                s[i - 1] = v[i];
            n--;
            v = new Nod[n];
            for (int i = 0; i < n; i++)
                v[i] = s[i];
        }

        public void StergereFinal()
        {
            Nod[] s = new Nod[n - 1];
            for (int i = 0; i < n - 1; i++)
                s[i] = v[i];
            n--;
            v = new Nod[n];
            for (int i = 0; i < n; i++)
                v[i] = s[i];
        }

        public void Vizualizare()
        {
            for (int i = 0; i < n; i++)
                v[i].View();
            Console.WriteLine();
        }
    }
}

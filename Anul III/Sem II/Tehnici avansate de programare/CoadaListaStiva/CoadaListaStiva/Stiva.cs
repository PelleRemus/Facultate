using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoadaListaStiva
{
    public class Stiva
    {
        public int n;
        public int[] v;

        public Stiva()
        {
            n = 0;
            v = new int[0];
        }

        public void AdaugareFinal(int value)
        {
            //cream un nou vector de dimensiune mai mare cu 1
            n++;
            int[] newV = new int[n];

            //adaugam toate valorile de la inceput in noul vector
            for (int i = 0; i < n - 1; i++)
                newV[i] = v[i];

            //iar pe ultima pozitie se pune value
            newV[n - 1] = value;
            v = newV;
        }

        public int StergereFinal()
        {
            //cream un nou vector de dimensiune mai mica cu 1 
            n--;
            int[] newV = new int[n];

            //copiem toate valorile de la inceput
            for (int i = 0; i < n; i++)
                newV[i] = v[i];

            //iar ultima valoare este salvata pentru a fi returnata
            int value = v[n];
            v = newV;
            return value;
        }

        public void Afisare()
        {
            for(int i=0; i<n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }
    }
}

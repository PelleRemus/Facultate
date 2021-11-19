using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoadaListaStiva
{
    public class Coada
    {
        public int n;
        public int[] v;

        public Coada()
        {
            n = 0;
            v = new int[0];
        }

        public void AdaugareInceput(int value)
        {
            //cream un nou vector de dimensiune mai mare cu 1
            n++;
            int[] newV = new int[n];

            //adaugam toate valorile din v pe pozitia i+1 in vectorul nou
            for (int i = 0; i < n - 1; i++)
                newV[i + 1] = v[i];

            //pentru a pastra pozitia 0 pentru a introduce noua valoare
            newV[0] = value;
            v = newV;
        }

        public int StergereFinal()
        {
            n--;
            int[] newV = new int[n];
            for (int i = 0; i < n; i++)
                newV[i] = v[i];
            int value = v[n];
            v = newV;
            return value;
        }

        public void Afisare()
        {
            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }
    }
}

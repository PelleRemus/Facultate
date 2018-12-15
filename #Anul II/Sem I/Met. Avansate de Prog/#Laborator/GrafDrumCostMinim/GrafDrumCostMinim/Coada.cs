using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDrumCostMinim
{
    public class Coada
    {
        public int[] values;
        public int n;

        public Coada()
        {
            n = 0;
            values = new int[n];
        }

        public void Adaugare(int value)
        {
            n++;
            int[] temp = new int[n];
            for (int i = 0; i < n - 1; i++)
                temp[i + 1] = values[i];
            temp[0] = value;
            values = temp;
        }

        public int Stergere()
        {
            int r = values[n - 1];
            n--;
            int[] temp = new int[n];
            for (int i = 0; i < n; i++)
                temp[i] = values[i];
            values = temp;
            return r;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class Lista
    {
        public int n;
        public int[] v;

        public Lista()
        {
            n = 0;
            v = new int[0];
        }

        public void Add(int value)
        {
            n++;
            int[] newV = new int[n];
            for (int i = 0; i < n - 1; i++)
                newV[i] = v[i];
            newV[n - 1] = value;
            v = newV;
        }

        public void Permutare(int k)
        {
            if (k > n)
                k = n % k;
            int[] aux = new int[n];

            for(int i=0; i<n; i++)
            {
                if (i - k < 0)
                    aux[n + i - k] = v[i];
                else
                    aux[i - k] = v[i];
            }

            v = aux;
        }

        public void Afisare()
        {
            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }
    }
}

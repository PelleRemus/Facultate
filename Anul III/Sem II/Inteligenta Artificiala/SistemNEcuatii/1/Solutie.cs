using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Cromozom
    {
        public float[] gene;

        public Cromozom()
        {
            gene = new float[Program.n];
            for (int i = 0; i < Program.n; i++)
                gene[i] = (float)Program.rnd.NextDouble() * 2000 - 1000;
        }

        public float FAdec()
        {
            float r = 0;
            for(int j=0; j< Program.n; j++)
            {
                float aux = 0;
                for (int i = 0; i < Program.n; i++)
                    aux += Program.A[j, i] * gene[i] - Program.T[j];
                r += Math.Abs(aux);
            }
            return r;
        }

        public void Mutatie()
        {
            int n = Program.rnd.Next(Program.n);
            gene[n] = (float)Program.rnd.NextDouble() * 2000 - 1000;
        }

        public void View()
        {
            Console.Write("(");
            for (int i = 0; i < Program.n; i++)
                Console.Write(gene[i].ToString("0.000") + " ");
            Console.WriteLine(")" + FAdec().ToString("0.000"));
        }
    }
}

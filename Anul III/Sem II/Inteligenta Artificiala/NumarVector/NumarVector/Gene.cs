using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    public class Gene
    {
        static int pi = 1;
        static int pr = 1;
        public static int n = pi + pr + 1;
        public int[] cifre;

        public Gene()
        {
            cifre = new int[n];
            initRandom();
        }

        public double ConvertToDouble()
        {
            double s = 0;
            for (int i = 1; i <= pi; i++)
                s = s * 10 + cifre[i];
            for (int i = pi + 1; i < n; i++)
            {
                double s2 = cifre[i];
                s2 /= Math.Pow(10, i - pi);
                s += s2;
            }
            if (cifre[0] < 5)
                s = s * -1;
            return s;
        }

        public void ConvertToVector(double number)
        {

        }

        public void initRandom()
        {
            for (int i = 0; i < n; i++)
                cifre[i] = Engine.rnd.Next(10);
        }

        public void Mutate()
        {
            
            int index = Engine.rnd.Next(n);
            int value;
            do
            {
                value = Engine.rnd.Next(10);
            } while (cifre[index] == value);

            cifre[index] = value;
        }

        public void View()
        {
            for(int i=0; i<n; i++)
                Console.Write(cifre[i]);
        }
    }
}

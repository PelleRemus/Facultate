using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemNEcuatii
{
    public class Solution
    {
        public float[] X;

        public Solution()
        {
            X = new float[Engine.n];
            SetRnd();
        }
        public void SetRnd()
        {
            for (int i = 0; i < Engine.n; i++)
                X[i] = Engine.GetRndNumber();
        }
        public void SetTest()
        {
            for (int i = 0; i < Engine.n; i++)
                X[i] = i + 1;
        }

        public float FAdec()
        {
            float suma = 0;
            for(int j=0; j<Engine.n; j++)
            {
                float s = 0;
                for (int i = 0; i < Engine.n; i++)
                    s += Engine.A[j, i] * X[i];
                s -= Engine.T[j];
                suma += Math.Abs(s);
            }
            return suma;
        }

        public void View()
        {
            for (int i = 0; i < Engine.n; i++)
                Console.Write(X[i] + " ");
            Console.WriteLine("(" + FAdec() + ")");
        }
    }
}

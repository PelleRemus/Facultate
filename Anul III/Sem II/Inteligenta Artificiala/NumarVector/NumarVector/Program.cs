using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Solutie A = new Solutie();
            Solutie B = new Solutie();
            A.View();
            B.View();
            Solutie sol = Engine.CrossN(A, B);
            sol.View();*/

            /*float[] ponderi = new float[] { 1.1f, 2.0f, 0.5f, 0.01f, 1.3f };
            int[] vn = new int[ponderi.Length];
            float s = 0;
            for (int i = 0; i < ponderi.Length; i++)
            {
                vn[i] = 0;
                s += ponderi[i];
            }

            for (int i = 0; i < 1000000; i++)
                vn[Engine.AMC(ponderi)]++;

            for (int i = 0; i < ponderi.Length; i++)
                Console.WriteLine("{0} = {1}", vn[i]/1000000.0, ponderi[i]/s);
            */

            Engine.Citire();
            Engine.initPop();
            Engine.ViewPop();
            Console.WriteLine();
            do
            {
                Console.Clear();
                for (int i = 0; i < 1000; i++)
                {
                    Engine.SelectPop();
                    Engine.UpdatePop();
                }
                Engine.ViewPar();
                Console.ReadKey();

            } while (true);
        }
    }
}

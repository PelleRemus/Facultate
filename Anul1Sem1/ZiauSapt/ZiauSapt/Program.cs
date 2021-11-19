using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiauSapt
{
    class Program
    {
        static int t = 0;
        static void Main(string[] args)
        {
            Ani();
            Console.WriteLine("Peste {0} ani, in aceeasi data, va fi aceeasi zi a saptamanii", t);
            Console.ReadKey();
        }

        private static int Ani ()
        {
            Console.WriteLine("Introduceti o data: (an, zi, luna)");
            int an, zi, luna, c = 0;
            an = int.Parse(Console.ReadLine());
            zi = int.Parse(Console.ReadLine());
            luna = int.Parse(Console.ReadLine());

            if (zi == 29 && luna == 2)
            {
                while (c != 7)
                    if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
                    { c++; t++; }
                return c;
            }

            do
            {
                if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
                {
                    if (c % 7 == 6 && luna < 3)
                    {
                        t++;
                        return t;
                    }
                    else c += 2;
                }
                else c++;
                an++; t++;
            } while (c % 7 != 0);
            return t;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ianuarie_1_677000
{
    class Program
    {
        static void Main(string[] args)
        {
            int an, zi = 0;
            int an2 = int.Parse(Console.ReadLine());
            for (an = 2018; an < an2; an++)
            {
                if ((an % 4 == 0 && an % 100 != 0) || an % 400 == 0)
                    zi += 2;
                else zi++;
                zi %= 7;
            }

            Console.Write("1 Ianuarie {0} este ", an);
            switch (zi)
            {
                case 0:
                        Console.WriteLine("luni");
                        break;
                case 1:
                        Console.WriteLine("marti");
                        break;
                case 2:
                        Console.WriteLine("miercuri");
                        break;
                case 3:
                        Console.WriteLine("joi");
                        break;
                case 4:
                        Console.WriteLine("vineri");
                        break;
                case 5:
                        Console.WriteLine("sambata");
                        break;
                case 6:
                        Console.WriteLine("duminica");
                        break;
            }
            Console.ReadKey();
        }
    }
}

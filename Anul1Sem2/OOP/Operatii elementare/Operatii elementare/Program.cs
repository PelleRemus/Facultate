using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_elementare
{
    class Operatii
    {
        public float a, b;
        public float Adunare()
        {
            return a + b;
        }
        public float Scadere()
        {
            return a - b;
        }
        public float Inmultire()
        {
            return a * b;
        }
        public float Impartire()
        {
            return a / b;
        }
    }

    class Steluteee
    {
        public Steluteee(int n)
        {
            for (int i=1; i<=n; i++)
            {
                int y = i;
                while (y > 0)
                { Console.Write("*"); y--; }
                Console.WriteLine();
            }
            Console.WriteLine();

            int a = 1, x;
            for (int i = n - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    x = n;
                    while (x > 0)
                    {
                        Console.Write("* ");
                        x--;
                    }
                }
                else if (i == n - 1)
                {
                    x = i;
                    Afisare(x);
                    Console.Write("*");
                    Console.WriteLine();
                }
                else
                {
                    x = i;
                    Afisare(x);
                    Console.Write("*");
                    x = a;
                    Afisare(x);
                    Console.Write("*");
                    Console.WriteLine();
                    a += 2;
                }
            }
        }

        private void Afisare(int x)
        {
            while (x > 0)
            {
                Console.Write(" ");
                x--;
            }
        }
    }

    class Dreptunghi
    {
        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Length
        {
            get;
            set;
        }
        public int Area()
        {
            return width * Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Operatii ex = new Operatii();
            Console.Write("a= ");  ex.a = float.Parse(Console.ReadLine());
            Console.Write("b= "); ex.b = float.Parse(Console.ReadLine());
            Console.WriteLine(ex.Adunare()); Console.WriteLine(ex.Scadere()); Console.WriteLine(ex.Inmultire()); Console.WriteLine(ex.Impartire());
            */
            /*Console.Write("Nr. de linii stelute: "); int n = int.Parse(Console.ReadLine());
            Steluteee stelute = new Steluteee(n);
            */
            Dreptunghi D = new Dreptunghi();
            D.Width = int.Parse(Console.ReadLine());
            D.Length = int.Parse(Console.ReadLine());
            Console.WriteLine(D.Area());
            Console.ReadKey();
        }
    }
}

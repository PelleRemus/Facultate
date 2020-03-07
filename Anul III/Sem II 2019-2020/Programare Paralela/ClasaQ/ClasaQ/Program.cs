using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaQ
{
    /* Sa se construiasca clasa Q (numere rationale) cu urmatoarele facilitati:
    a) suma a doua numere Q
    b) produsul a doua numere Q
    c) aducerea la fractie ireductibila
    d) constructor / destructor
    e) suprascrierea cel putin a unui operator
    f) ...

    0.5p pe fiecare, 3p total. 
    */

    public class Q
    {
        public long numarator, numitor;

        public Q() { }

        public Q(long numarator, long numitor)
        {
            this.numarator = numarator;
            this.numitor = numitor;
        }

        public void Ireductibil()
        {
            long t = Program.Euclid(numarator, numitor);
            numarator /= t;
            numitor /= t;
        }

         //faceti suma si produsul cu suprascrierea operatorilor
         //decat cu functie separata in Program.

        public static Q operator +(Q a, Q b)
        {
            Q c = new Q();
            c.numarator = a.numarator * b.numitor + a.numitor * b.numarator;
            c.numitor = a.numitor * b.numitor;
            return c;
        }

        public static Q operator *(Q a, Q b)
        {
            Q c = new Q();
            c.numarator = a.numarator * b.numarator;
            c.numitor = a.numitor * b.numitor;
            return c;
        }

        public override string ToString()
        {
            return numarator.ToString() + "/" + numitor.ToString();
        }
    }

    public class Program
    {
        static Q Suma(Q a, Q b)
        {
            Q c = new Q();
            c.numarator = a.numarator * b.numitor + a.numitor * b.numarator;
            c.numitor = a.numitor * b.numitor;
            return c;
        }

        static Q Produs(Q a, Q b)
        {
            Q c = new Q();
            c.numarator = a.numarator * b.numarator;
            c.numitor = a.numitor * b.numitor;
            return c;
        }

        public static long Euclid(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        public static long Euclid2(long a, long b)
        {
            while (b != 0)
            {
                long r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        static void Main(string[] args)
        {
            Q A = new Q(3, 2);
            Q B = new Q(5, 7);
            //Q C = Suma(A, B);
            Q C = A + B;
            Console.WriteLine(C);
            C.Ireductibil();
            Console.WriteLine(C);
            //C = Produs(A, B);
            C = A * B;
            Console.WriteLine(C);
            C.Ireductibil();
            Console.WriteLine(C);
            Console.ReadKey();
        }
    }
}

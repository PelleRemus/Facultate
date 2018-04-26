using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeaComplex
{
    struct Cplx
    {
        public float Re, Im;

        public void View()
        {
            Console.WriteLine(Re + "+i*" + Im);
            Console.WriteLine();
        }
        float Norma()
        {
            return (float)Math.Sqrt(Re * Re + Im * Im);
        }
    };

    class Program
    {
        static Cplx Sum(Cplx A, Cplx B)
        {
            Cplx toR = new Cplx();
            toR.Re = A.Re + B.Re;
            toR.Im = A.Im + B.Im;
            return toR;
        }

        static Cplx Prod(Cplx A, Cplx B)
        {
            Cplx prd = new Cplx();
            prd.Re = A.Re * B.Re - A.Im * B.Im;
            prd.Im = A.Re * B.Im + B.Re * A.Im;
            return prd;
        }


        static void Main(string[] args)
        {
            Cplx A = new Cplx();
            A.Re = 4;
            A.Im = 2;
            A.View();

            Cplx B = new Cplx();
            B.Re = 1;
            B.Im = 5;
            B.View();

            Cplx C = Sum(A, B);
            C.View();

            Cplx D = Prod(A, B);
            D.View();

            Console.ReadKey();
        }
    }
}

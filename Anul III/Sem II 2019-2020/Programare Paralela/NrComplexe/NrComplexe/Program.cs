using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrComplexe
{
    public class Complex
    {
        public float real, imaginar;

        public Complex()
        {
            real = float.Parse(Console.ReadLine());
            imaginar = float.Parse(Console.ReadLine());
        }

        public Complex(float real, float imaginar)
        {
            this.real = real;
            this.imaginar = imaginar;
        }

        public float Norma()
        {
            return (float)Math.Sqrt(real * real + imaginar * imaginar);
        }

        public static Complex operator+ (Complex a, Complex b)
        {
            float real = a.real + b.real;
            float imaginar = a.imaginar + b.imaginar;
            return new Complex(real, imaginar);
        }

        public static Complex operator*(Complex a, Complex b)
        {
            float real = a.real * b.real - a.imaginar * b.imaginar;
            float imaginar = a.real * b.imaginar + a.imaginar * b.real;
            return new Complex(real, imaginar);
        }

        public static bool operator== (Complex a, Complex b)
        {
            if (a.real == b.real && a.imaginar == b.imaginar)
                return true;
            return false;
        }
        public static bool operator!=(Complex a, Complex b)
        {
            if (a==b)
                return false;
            return true;
        }

        public static bool operator< (Complex a, Complex b)
        {
            if (a.real < b.real)
                return true;
            if (a.real > b.real)
                return false;
            if (a.imaginar < b.imaginar)
                return true;
            return false;
        }
        public static bool operator> (Complex a, Complex b)
        {
            if (a < b || a == b)
                return false;
            return true;
        }

        public override string ToString()
        {
            if (imaginar > 0)
                return real + "+i" + imaginar;
            else if (imaginar < 0)
                return real + "-i" + -imaginar;
            else
                return real.ToString();
        }
    }

    class Program
    {
        static Complex Suma(Complex a, Complex b)
        {
            float real = a.real + b.real;
            float imaginar = a.imaginar + b.imaginar;
            return new Complex(real, imaginar);
        }

        static Complex Produs(Complex a, Complex b)
        {
            float real = a.real * b.real - a.imaginar * b.imaginar;
            float imaginar = a.real * b.imaginar + a.imaginar * b.real;
            return new Complex(real, imaginar);
        }

        static void Main(string[] args)
        {
            Complex a = new Complex(2, 7);
            Complex b = new Complex();
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a == b);
            Console.WriteLine(a.Norma());
            Complex c = a + b;
            Complex d = a * b;
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}

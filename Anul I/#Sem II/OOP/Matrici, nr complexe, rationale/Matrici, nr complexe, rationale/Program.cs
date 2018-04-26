using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici__nr_complexe__rationale
{
    class Complex
    {
        public double re, im;
        public Complex(double real = 0, double imaginar = 0)
        {
            re = real;
            im = imaginar;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            Complex c = new Complex();
            c.re = a.re + b.re;
            c.im = a.im + b.im;
            return c;
        }
        public static Complex operator -(Complex a, Complex b)
        {
            Complex c = new Complex();
            c.re = a.re - b.re;
            c.im = a.im - b.im;
            return c;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            Complex c = new Complex();
            c.re = a.re * b.re - a.im * b.im;
            c.im = a.re * b.im + a.im * b.re;
            return c;
        }
        public virtual Complex Putere(int x)
        {
            Complex c = new Complex(re, im);
            if (x == 0) return new Complex(1);
            if (x == 1) return new Complex(re, im);
            return c * c.Putere(x - 1);
        }

        public void Trigonometric()
        {
            double r = Math.Sqrt(re * re + im * im);
            double fi = Math.Atan(im / re);
            Console.WriteLine("{0}*( cos({1}) + i * sin({1}) )", r, fi);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} + i*{1}", re, im);
            return s.ToString();
        }
    }

    class Rational
    {
        int a, b;
        public Rational(int nr = 0, int nm = 1)
        {
            a = nr; b = nm;
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int c = cmmmc(r1.b, r2.b);
            r.b = c;
            r.a = r1.a * c / r1.b + r2.a * c / r2.b;
            return r;
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int c = cmmmc(r1.b, r2.b);
            r.b = c;
            r.a = r1.a * c / r1.b - r2.a * c / r2.b;
            return r;
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            r.a = r1.a * r2.a;
            r.b = r1.b * r2.b;
            return r;
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            Rational r = new Rational();
            int x = r2.a;
            r2.a = r2.b;
            r2.b = x;
            r = r1 * r2;
            return r;
        }

        public Rational Putere(int x)
        {
            Rational r = new Rational(a, b);
            if (x == 0) return new Rational(1);
            if (x == 1) return new Rational(a, b);
            return r * r.Putere(x - 1);
        }
        public void Ireductibil()
        {
            int x = cmmdc(a, b);
            a /= x; b /= x;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            if (r1.a / r1.b == r2.a / r2.b) return true;
            return false;
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            if (r1==r2) return false;
            return true;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            if (r1.a / r1.b < r2.a / r2.b) return true;
            return false;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            if (r1 < r2 || r1 == r2) return false;
            return true;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            if (r1 < r2 || r1 == r2) return true;
            return false;
        }
        public static bool operator >=(Rational r1, Rational r2)
        {
            if (r1 > r2 || r1 == r2) return true;
            return false;
        }

        public static int cmmdc(int x, int y)
        {
            while (x != y)
            {
                if (x < y) y -= x;
                else x -= y;
            }
            return x;
        }
        public static int cmmmc(int x, int y)
        {
            return x * y / cmmdc(x, y);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}/{1}", a, b);
            return s.ToString();
        }
    }

    class Matrice
    {
        public float[,] matrix;
        public float determinant;
        static Random r = new Random();
        public Matrice(int n, int m)
        {
            matrix = new float[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = r.Next(10);
        }

        public Matrice Adunare(Matrice B)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            Matrice C = new Matrice(n, m);
            if (n!= B.matrix.GetLength(0) || m != B.matrix.GetLength(1))
                Console.WriteLine("Nu se pot aduna doua matrici de dimensiuni diferite");
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        C.matrix[i, j] = matrix[i, j] + B.matrix[i, j];
            }
            return C;
        }
        public Matrice Scadere(Matrice B)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            Matrice C = new Matrice(n, m);
            if (n != B.matrix.GetLength(0) || m != B.matrix.GetLength(1))
                Console.WriteLine("Nu se pot scadea doua matrici de dimensiuni diferite");
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        C.matrix[i, j] = matrix[i, j] - B.matrix[i, j];
            }
            return C;
        }

        public Matrice Inmultire(Matrice B)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            Matrice C = new Matrice(n, n);
            if (n != B.matrix.GetLength(1))
                Console.WriteLine("Numarul de coloane al primei matrice trebuie sa fie egal cu numarul de linii al celei de-a doua");
            else
            {
                for (int k = 0; k < n; k++)
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < m; j++)
                            C.matrix[k, i] += matrix[i, j] * B.matrix[j, i];
            }
            return C;
        }
        public Matrice Putere (int x)
        {
            int n = matrix.GetLength(0);
            Matrice C = new Matrice(n, n);
            if (n != matrix.GetLength(1))
            { Console.WriteLine("Doar matricile patratice pot avea putere"); return C; }
            if (x == 0)
                for (int i = 0; i < n; i++)
                    C.matrix[i, i] = 1;
            else if (x == 1)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        C.matrix[i, j] = matrix[i, j];
            else
                C = C.Inmultire(C.Putere(x - 1));
            return C;
        }

        public Matrice Inversa()
        {
            int n = matrix.GetLength(0);
            Matrice C = new Matrice(n, n);
            if (n != matrix.GetLength(1))
            { Console.WriteLine("Doar matricile patratice pot avea inversa"); return C; }
            CalculDeterminant();
            if (determinant != 0)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Matrice A = new Matrice(n - 1, n - 1);
                        for (int k = 0; k < n - 1; k++)
                            for (int l = 0; l < n - 1; l++)
                            {
                                if (k >= i && l >= j) A.matrix[l, k] = matrix[k + 1, l + 1];
                                else if (k >= i && l < j) A.matrix[l, k] = matrix[k + 1, l];
                                else if (k < 1 && l >= j) A.matrix[l, k] = matrix[k, l + 1];
                                else A.matrix[l, k] = matrix[k, l];
                            }
                        A.Afisare();
                        A.CalculDeterminant();
                        C.matrix[i, j] = (int)Math.Pow(-1, i + j) * A.determinant;
                        Console.WriteLine(C.matrix[i,j]);
                    }
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        C.matrix[i, j] *= 1f / determinant;
            }
            return C;
        }
        public void CalculDeterminant()
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                Console.WriteLine("Doar matricile patratice au determinant");
            else
            {
                int[] sol = new int[n];
                bool[] b = new bool[n];
                Permutari(0, n, sol, b);
            }
        }
        private void Permutari(int k, int n, int[] sol, bool[] b)
        {
            int[] v = new int[n];
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    v[i] = sol[i];
                Prelucrare(v);
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Permutari(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }
        private void Prelucrare(int[] v)
        {
            int n = matrix.GetLength(0);
            int grad = 0;
            float produs = 1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (v[i] > v[j]) grad++;
            for (int i=0; i<n; i++)
            {
                produs *= matrix[i, v[i]];
            }
            if (grad % 2 == 0) determinant += produs;
            else determinant -= produs;
        }

        public void Afisare()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            //1
            Complex a = new Complex((double)r.Next(10), (double)r.Next(10));
            Complex b = new Complex((double)r.Next(10), (double)r.Next(10));
            int x = r.Next(10);

            Console.WriteLine("a: {0}, b: {1}", a, b);
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
            Console.WriteLine("({0})^{1} = {2}", a, x, a.Putere(x));
            b.Trigonometric();
            Console.WriteLine();

            //2
            Rational r1 = new Rational(r.Next(100), r.Next(100));
            Rational r2 = new Rational(r.Next(100), r.Next(100));
            Console.WriteLine("r1: {0}, r2: {1}", r1, r2);
            Console.WriteLine("{0} - {1} = {2}", r1, r2, r1 - r2);
            Console.WriteLine("{0} + {1} = {2}", r1, r2, r1 + r2);
            Console.WriteLine("{0} * {1} = {2}", r1, r2, r1 * r2);
            Console.WriteLine("{0} / {1} = {2}", r1, r2, r1 / r2);
            Console.WriteLine("{0}^{1} = {2}; {3}^{1} = {4}", r1, x, r1.Putere(x), r2, r2.Putere(x));
            Rational R1 = r1; R1.Ireductibil();
            Rational R2 = r2; R2.Ireductibil();
            Console.WriteLine("{0} = {1}; {2} = {3}", r1, R1, r2, R2);
            Console.WriteLine("{0} < {1}: {2}", r1, r2, r1 < r2);
            Console.WriteLine("{0} > {1}: {2}", r1, r2, r1 > r2);
            Console.WriteLine("{0} <= {1}: {2}", r1, r2, r1 <= r2);
            Console.WriteLine("{0} >= {1}: {2}", r1, r2, r1 >= r2);
            Console.WriteLine("{0} == {1}: {2}", r1, r2, r1 == r2);
            Console.WriteLine("{0} != {1}: {2}", r1, r2, r1 != r2);
            Console.WriteLine();

            //3
            Matrice A = new Matrice(3, 3);
            Matrice B = new Matrice(3, 3);
            A.Afisare(); B.Afisare();
            Matrice C = new Matrice(3, 3);
            C = A.Adunare(B); C.Afisare();
            C = A.Scadere(B); C.Afisare();
            C = A.Inmultire(B); C.Afisare();
            C = A.Putere(3); C.Afisare();
            C = B.Inversa(); C.Afisare();

            //1'
            ComplexD zd = new ComplexD(5, 3);
            Complex D = new Complex();
            D = zd.Putere(2);
            Console.WriteLine(D);
            Complex[] v = new Complex[2];
            v[0] = new Complex(1, 1);
            v[1] = new Complex(5, 2);
            double d = zd.Distanta(v);
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }

    class ComplexD : Complex
    {
        double r, fi;
        public ComplexD(double re = 0, double im = 0)
        {
            this.re = re;
            this.im = im;
            this.r = Math.Sqrt(re * re + im * im);
            this.fi = Math.Atan(im / re);
        }

        public override Complex Putere(int x)
        {
            ComplexD A = new ComplexD();
            A.r = Math.Pow(r, x);
            A.fi = x * fi;
            double re = Math.Sqrt(A.r * A.r / (1 + Math.Tan(A.fi) * Math.Tan(A.fi)));
            double im = Math.Tan(A.fi) * re;
            return new Complex(re, im);
        }

        public double Distanta(Complex[] v)
        {
            double[] dist = new double[v.Length];
            for (int i=0; i<v.Length; i++)
                dist[i] = Math.Sqrt((re - v[i].re) * (re - v[i].re) + (im - v[i].im) * (im - v[i].im));
            double min = dist[0];
            for (int i = 0; i < dist.Length; i++)
                if (min > dist[i])
                    min = dist[i];
            return min;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
            Ex3();
        }

        static Coada c;
        static void Ex1()
        {
            Console.WriteLine("Exercitiul 1:");
            TextReader dataLoad = new StreamReader(@"../../data.in");
            string buffer = dataLoad.ReadLine();
            int n = int.Parse(buffer);
            c = new Coada();

            while ((buffer = dataLoad.ReadLine()) != null)
                c.Add(buffer);

            int nr = c.n;
            int[] sol = new int[nr];
            bool[] b = new bool[nr];
            Permutare(0, nr, sol, b);

            Console.WriteLine("Daca nu s-a afisat nimic inainte de asta, Euler avea dreptate");
            Console.ReadKey();
        }
        static void Permutare(int k, int n, int[] sol, bool[] b)
        {
            if (k >= n)
                Euler(n, sol);
            else
                for(int i=0; i<n; i++)
                    if(!b[i])
                    {
                        b[i] = true;
                        sol[k] = i;
                        Permutare(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }
        static void Euler(int n, int[] sol)
        {
            for (int i = 1; i < n; i++)
            {
                if (c.v[sol[i - 1]].nodS == c.v[sol[i]].nodE ||
                    c.v[sol[i - 1]].nodE == c.v[sol[i]].nodS)
                    continue;
                else
                    return;
            }
            Console.WriteLine("Am gasit solutia!");
            c.View(sol);
        }

        static void Ex2()
        {
            Console.WriteLine("Exercitiul 2:");
            A a = new A();
            a.addRND(0);
            a.addRND(0);
            a.addRND(1);
            a.addRND(1);
            a.addRND(2);
            a.addRND(2);
            a.addRND(3);
            a.addRND(3);
            Console.WriteLine("Valorile sunt adaugate pe pozitii la intamplare in vector:");
            Afisare(a);

            a.addUniq(4);
            a.addUniq(4);
            a.addUniq(3);
            Console.WriteLine("Dintre toate valorile, a fost adaugata doar valoarea 4, la inceputul vectorului:");
            Afisare(a);

            a.Sort();
            Console.WriteLine("Vectorul este sortat eficient:");
            Afisare(a);

            a.Uniq();
            Console.WriteLine("Pastram doar una singura din fiecare valoare:");
            Afisare(a);

            a.addRND(2);
            a.addRND(2);
            Console.WriteLine("Adaugam mai multe valori ale lui 2, dupa care le vom sterge pe toate:");
            Afisare(a);
            a.Del(2);
            Afisare(a);
            Console.ReadKey();
        }
        static void Afisare(A a)
        {
            for(int i=0; i<a.n; i++)
                Console.Write(a.v[i]+" ");
            Console.WriteLine();
        }

        static void Ex3()
        {
            Console.WriteLine("Exercitiul 3:");
            Console.WriteLine("Calculam puterea n a matricei urmatoare:");
            Console.WriteLine("1  1");
            Console.WriteLine("1  0");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = Putere(n);
            Console.WriteLine(matrix[0, 0] + " " + matrix[0, 1]);
            Console.WriteLine(matrix[1, 0] + " " + matrix[1, 1]);
            Console.ReadKey();
        }
        static int[,] Putere(int n)
        {
            if (n == 1)
                return new int[,] { { 1, 1 }, { 1, 0 } };

            int[,] matrix = Putere(n - 1);
            int[,] Matrix = new int[2, 2];
            Matrix[0, 0] = matrix[0, 0] + matrix[0, 1];
            Matrix[0, 1] = Matrix[1, 0] = matrix[0, 0];
            Matrix[1, 1] = matrix[1, 0];
            return Matrix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drum
{
    class Program
    {
        static int n = 8, c1, c2, l1, l2;
        static int[,] m = new int[n, n];
        static Random r = new Random();
        static Queue<Trivalue> nume = new Queue<Trivalue>();

        static void Generare()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = r.Next(4);
                    //dorim sa avem mai multi de 0
                    if (m[i, j] == 3)
                        m[i, j] = 1;
                    else
                        m[i, j] = 0;
                }
        }

        static void Afisare()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i, j] <= 9)
                        Console.Write(m[i, j] + "  ");
                    else
                        Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Generare();
            Afisare();
            l1 = int.Parse(Console.ReadLine());
            c1 = int.Parse(Console.ReadLine());
            l2 = int.Parse(Console.ReadLine());
            c2 = int.Parse(Console.ReadLine());

            nume.Enqueue(new Trivalue(l1, c1, 2));
            m[l1, c1] = 2;
            bool ok;
            do
            {
                ok = true;
                Trivalue t = nume.Dequeue();
                if (t.c - 1 >= 0)
                    if (m[t.l, t.c - 1] == 0)
                    {
                        m[t.l, t.c - 1] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l, t.c - 1, t.v + 1));
                    }
                if (t.l - 1 >= 0)
                    if (m[t.l - 1, t.c] == 0)
                    {
                        m[t.l - 1, t.c] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l - 1, t.c, t.v + 1));
                    }
                if (t.c + 1 < n)
                    if (m[t.l, t.c + 1] == 0)
                    {
                        m[t.l, t.c + 1] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l, t.c + 1, t.v + 1));
                    }
                if (t.l + 1 < n)
                    if (m[t.l + 1, t.c] == 0)
                    {
                        m[t.l + 1, t.c] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l + 1, t.c, t.v + 1));
                    }
                if (nume.Count == 0 || (t.l == l2 && t.c == c2))
                    ok = false;

            } while (ok);
            Afisare();

            if (m[l2, c2] != 0)
            {
                Trivalue[] drum = new Trivalue[m[l2, c2] - 1];
                drum[0] = new Trivalue(l2, c2, m[l2, c2]);
                for (int i = 1; i < drum.Length; i++)
                {
                    if (drum[i - 1].c - 1 >= 0)
                        if (m[drum[i - 1].l, drum[i - 1].c - 1] == drum[i - 1].v - 1)
                        {
                            drum[i] = new Trivalue(drum[i - 1].l, drum[i - 1].c - 1, drum[i - 1].v - 1);
                            continue;
                        }
                    if (drum[i - 1].l - 1 >= 0)
                        if (m[drum[i - 1].l - 1, drum[i - 1].c] == drum[i - 1].v - 1)
                        {
                            drum[i] = new Trivalue(drum[i - 1].l - 1, drum[i - 1].c, drum[i - 1].v - 1);
                            continue;
                        }
                    if (drum[i - 1].c + 1 < n)
                        if (m[drum[i - 1].l, drum[i - 1].c + 1] == drum[i - 1].v - 1)
                        {
                            drum[i] = new Trivalue(drum[i - 1].l, drum[i - 1].c + 1, drum[i - 1].v - 1);
                            continue;
                        }
                    if (drum[i - 1].l + 1 < n)
                        if (m[drum[i - 1].l + 1, drum[i - 1].c] == drum[i - 1].v - 1)
                        {
                            drum[i] = new Trivalue(drum[i - 1].l + 1, drum[i - 1].c, drum[i - 1].v - 1);
                        }
                }

                for (int i = drum.Length - 1; i >= 0; i--)
                    Console.WriteLine(drum[i].l + ", " + drum[i].c + ": " + drum[i].v);
            }
            else
                Console.WriteLine("Nu exista drum");
            Console.ReadKey();
        }
    }
}

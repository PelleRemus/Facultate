using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoriParalel
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializare vector
            int n = 100, threads = 5;
            int[] v = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                v[i] = rnd.Next(1, 10);

            //afisare vector
            for(int i=0; i<n; i++)
                Console.Write(v[i]+ " ");
            Console.WriteLine();

            //initializare taskuri; calculare suma pt fiecare task
            Task<int>[] tasks = new Task<int>[threads];
            for (int i = 0; i < threads; i++)
            {
                int index = i; //i se modifica in for, trebuie salvat intr-o alta variabila ca altfel sare peste elemente
                tasks[i] = Task<int>.Factory.StartNew(() =>
                {
                    int s = 0;
                    for (int j = index * n / threads; j < (index + 1) * n / threads; j++)
                        s += v[j];
                    return s;
                });
            }

            //calculare suma in modul normal
            int suma = 0;
            for (int i = 0; i < n; i++)
                suma += v[i];
            Console.WriteLine("Suma calculata normal: " + suma);

            //calculare suma paralel
            suma = 0;
            for (int i = 0; i < threads; i++)
                suma += tasks[i].Result;
            Console.WriteLine("Suma calculata paralel: " + suma);
            Console.ReadKey();
        }
    }
}

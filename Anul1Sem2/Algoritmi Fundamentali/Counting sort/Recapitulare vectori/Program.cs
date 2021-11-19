using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Sort
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //Tema: Construirea counting sort-ului cu valorile min si max introduse de la tastatura
            int min, max;
            min = int.Parse(Console.ReadLine());
            max = int.Parse(Console.ReadLine());
            int n = 756;
            int[] v = new int[n];
            for (int i = 0; i < n; i++)
                v[i] = rnd.Next(min, max+1);

            //afisare vector
            /*for (int i=0; i<n; i++)
                Console.Write("{0} ", v[i]);*/

            int[] c = new int[Math.Abs(max-min+1)];
            for (int i = 0; i < n; i++)
                c[v[i]-min]++;
            for (int i=0; i< Math.Abs(max - min + 1); i++)
                Console.Write("{0} ", c[i]);
            Console.WriteLine();
            Console.WriteLine();

            //afisare sortata a vectorului (vectorul nu se sorteaza)
            /*int _max = c[0], index = 0;
            for (int i=0; i<101; i++)
                if (_max < c[i])
                {
                    _max = c[i];
                    index = i;
                }
            Console.WriteLine(index);*/

            //sortam vectorul in a
            int[] a = new int[n];
            int k = 0;
            for (int i= 0;i< Math.Abs(max - min + 1); i++)
                if (c[i]!=0)
                {
                    for (int j = 0; j < c[i]; j++)
                    {
                        a[k] = i+min;
                        k++;
                    }
                }
            for (int i=0; i<n; i++)
                Console.Write(a[i]+" ");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancnote
{
    class Program
    {
        //Enunt: se da o suma de bani. Care este numarul minim de bancnote in care poate fi pusa aceasta?
        //Algoritmul greedy functioneaza in majoritatea cazurilor, dar nu in toate.
        //Avem noroc ca nu ni se cere sa functioneze mereu, putem folosi greedy.

        static void Main(string[] args)
        {
            int[] bill = new int[] { 500, 200, 100, 50, 10, 5, 1 }; //bancnotele in lei, descrescator
            int n = bill.Length;

            Console.Write("Introduceti o suma de bani: ");
            int sum = int.Parse(Console.ReadLine());
            int[] nr = new int[n]; //aici numaram cate bancnote de fiecare fel ne trebuie pentru a completa suma
            
            for(int i=0; i<n; i++)
            {
                while (sum >= bill[i])
                {
                    nr[i]++;
                    sum -= bill[i];
                }
                Console.WriteLine(nr[i] + " * " + bill[i]);
            }
            Console.ReadKey();
        }
    }
}

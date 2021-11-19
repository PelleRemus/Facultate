using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problema_spectacolelor
{
    public class Spectacol
    {
        public int ti, tf;
        public Spectacol(string data)
        {
            ti = int.Parse(data.Split(' ')[0]);
            tf = int.Parse(data.Split(' ')[1]);
        }
        public void Afisare()
        {
            Console.WriteLine(ti + " " + tf);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextReader dataLoad = new StreamReader(@"..\..\TextFile1.txt");
            string buffer;
            int n = int.Parse(dataLoad.ReadLine());
            Spectacol[] MyS = new Spectacol[n];
            int i = 0;
            while ((buffer=dataLoad.ReadLine())!=null)
            {
                MyS[i] = new Spectacol(buffer);
                i++;
            }
            for (int j=0; j<n; j++)
            {
                MyS[j].Afisare();
            }
            Console.WriteLine();
            for (i =0; i<n-1; i++)
                for (int j=i+1; j<n; j++)
                {
                    if (MyS[i].tf>MyS[j].tf)
                    {
                        int aux = MyS[i].tf;
                        MyS[i].tf = MyS[j].tf;
                        MyS[j].tf = aux;

                        aux = MyS[i].ti;
                        MyS[i].ti = MyS[j].ti;
                        MyS[j].ti = aux;
                    }
                }
            for (int j = 0; j < n; j++)
            {
                MyS[j].Afisare();
            }
            Console.WriteLine();

            MyS[0].Afisare();
            int tp = MyS[0].tf;
            for (i = 1; i<n; i++)
                if (MyS[i].ti>=tp)
                {
                    MyS[i].Afisare();
                    tp = MyS[i].tf;
                }
            Console.ReadKey();
        }
    }
}

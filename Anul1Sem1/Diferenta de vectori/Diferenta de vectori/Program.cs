using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diferenta_de_vectori
{
    class Program
    {
        static bool ok;

        static void Main(string[] args)
        {
            Print("v1-v2=", Dif(new int[] { 1, 0, 0, 0 }, new int[] { 1, 0, 0, 1 }));
            Console.ReadKey();
        }

        static void Print(string nume, int[] a)
        {
            string str = "";
            for (int i = 0; i < a.Length; i++)
                str += a[i].ToString();
            while (str[0] == '0' && str.Length > 1)
                str = str.Substring(1, str.Length - 1);
            if (str == "0") Console.WriteLine(nume + " 0");
            else
            {
                if (ok == true) Console.WriteLine(nume + " {0}", str);
                else Console.WriteLine(nume + " -{0}", str);
            }
        }

        static int[] Dif (int[] v1, int[] v2)
        {
            int[] v;
            if (Comp(v1, v2)==0)
            {
                v = new int[1];
                v[0] = int.Parse(0.ToString());
                return v;
            }
            if (Comp(v1, v2) == -1) ok = false;
            else ok = true;
            v1 = Inv(v1);
            v2 = Inv(v2);
            if (ok==true)
            {
                v = new int[v1.Length];
                for (int i = 0; i < v2.Length; i++)
                    v[i] = v1[i] - v2[i];
                for (int i = v2.Length; i < v1.Length; i++)
                    v[i] = v1[i];
            }
            else
            {
                v = new int[v2.Length];
                for (int i = 0; i < v1.Length; i++)
                    v[i] = v2[i] - v1[i];
                for (int i = v1.Length; i < v2.Length; i++)
                    v[i] = v1[i];
            }
            for (int i=0; i<v.Length; i++)
                if (v[i]<0)
                {
                    v[i] = 10 + v[i];
                    v[i + 1]--;
                }
            Inv(v);
            return v;
        }

        static int Comp(int[] v1, int[] v2)
        {
            if (v1.Length < v2.Length) return -1;
            else if (v1.Length > v2.Length) return 1;
            else
                for (int i = 0; i < v1.Length; i++)
                {
                    if (v1[i] < v2[i]) return -1;
                    else if (v1[i] > v2[i]) return 1;
                }
            return 0;
        }

        static int[] Inv(int[] v)
        {
            for (int i = 0; i < v.Length / 2; i++)
            {
                int t = v[i];
                v[i] = v[v.Length - 1 - i];
                v[v.Length - 1 - i] = t;
            }
            return v;
        }
    }
}

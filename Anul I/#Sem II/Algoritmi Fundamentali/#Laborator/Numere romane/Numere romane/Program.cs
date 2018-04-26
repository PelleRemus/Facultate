using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numere_romane
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "MCMLXXIV";
            int[] v = new int[s.Length];
            for (int i=0; i<s.Length; i++)
                switch(s[i])
                {
                    case 'I':
                        {
                            v[i] = 1;
                            break;
                        }
                    case 'V':
                        {
                            v[i] = 5;
                            break;
                        }
                    case 'X':
                        {
                            v[i] = 10;
                            break;
                        }
                    case 'L':
                        {
                            v[i] = 50;
                            break;
                        }
                    case 'C':
                        {
                            v[i] = 100;
                            break;
                        }
                    case 'D':
                        {
                            v[i] = 500;
                            break;
                        }
                    case 'M':
                        {
                            v[i] = 1000;
                            break;
                        }
                }
            int n = 0;
            for (int i=0; i<v.Length-1; i++)
            {
                if (v[i] < v[i + 1]) n -= v[i];
                else n += v[i];
            }
            n += v[v.Length - 1];
            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}

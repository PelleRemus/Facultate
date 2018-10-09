using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CezarAndRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1_2();
            Console.WriteLine();
            Ex3();
        }

        static void Ex1_2()
        {
            Console.Write("Introduceti un text: ");
            string s = Console.ReadLine();
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            string c = Criptare(s, n);
            Console.WriteLine(c);
            string d = Decriptare(c, n);
            Console.WriteLine(d);
            Console.ReadKey();
        }

        public static string Criptare(string s, int n)
        {
            string sol = "";
            for(int i=0; i<s.Length; i++)
            {
                if (!char.IsLetter(s[i]))
                    sol += s[i];
                else
                {
                    char a = 'a';
                    if (char.IsUpper(s[i]))
                        a = 'A';
                    sol += (char)((s[i] + n - a) % 26 + a);
                }
            }
            return sol;
        }

        public static string Decriptare(string c, int n)
        {
            return Criptare(c, 26 - n);
        }

        public static void Ex3()
        {
            TextReader dataLoad = new StreamReader(@"..\..\Text.txt");
            string s = dataLoad.ReadLine();
            Console.WriteLine("Your text is: " + s);
            dataLoad = new StreamReader(@"..\..\Source.txt");
            string cript = dataLoad.ReadLine();

            string sol = "";
            for(int i=0; i<s.Length; i++)
            {
                if (!char.IsLetter(s[i]))
                    sol += s[i];
                else
                {
                    char a = 'a';
                    if (char.IsUpper(s[i]))
                    {
                        a = 'A';
                        sol += (char)(cript[s[i] - a] - 32);
                    }
                    else
                        sol += cript[s[i] - a];
                }
            }
            TextWriter data = new StreamWriter(@"..\..\Solution.txt");
            data.WriteLine(sol);

            string decript = "";
            for(int i=0; i<sol.Length; i++)
            {
                if (!char.IsLetter(sol[i]))
                    decript += sol[i];
                else
                {
                    char a = 'a', x = sol[i];
                    if (char.IsUpper(sol[i]))
                    {
                        x = (char)(sol[i] + 32);
                        a = 'A';
                    }
                    decript += (char)(a + cript.IndexOf(x));
                }
            }
            data.WriteLine(decript);
            data.Close();
            Console.ReadKey();
        }
    }
}

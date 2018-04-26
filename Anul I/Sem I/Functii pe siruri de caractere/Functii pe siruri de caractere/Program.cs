using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functii_pe_siruri_de_caractere
{
    class Program
    {
        static void Main(string[] args)
        {
            string v1, v2;
            v1 = Console.ReadLine();
            v2 = Console.ReadLine();
            Console.ReadKey();
        }

        static int strlen (string v)
        {
            return v.Length;
        }

        static void strcpy (out string v1, string v2)
        {
            v1 = v2;
        }

        static void strncpy (out string v1, string v2)
        {
            string cpy = "";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                cpy += v2[i];
            v1 = cpy;
        }

        static string strcat (string v1, string v2)
        {
            v1 += v2;
            return v1;
        }

        static string strncat (string v1, string v2)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                v1 += v2[i];
            return v1;
        }

        static int strcmp (string v1, string v2)
        {
            if (strlen(v1) < strlen(v2)) return -1;
            else if (strlen(v1) > strlen(v2)) return 1;
            else
                for (int i = 0; i < strlen(v1); i++)
                    if (v1[i] < v2[i]) return -1;
                    else if (v1[i] > v2[i]) return 1;
            return 0;
        }

        static int strncmp (string v1, string v2)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                if (v1[i] < v2[i]) return -1;
                else if (v1[i] > v2[i]) return 1;
            return 0;
        }

        /*static string strupr (string v1)
        {
            for (int i = 0; i < strlen(v1); i++)
                if (97 <= v1[i] && v1[i] <= 122)
                    v1[i] = v1[i]&223;
            return v1;
        }*/

        /*static string strlwr (string v1)
        {

        }*/
    }
}

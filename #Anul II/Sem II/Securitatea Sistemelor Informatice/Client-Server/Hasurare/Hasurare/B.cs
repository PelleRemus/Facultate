using System;

namespace Hasurare
{
    public static class B
    {
        public static int iA = 1;
        public static byte[] wi;

        public static void Init(byte[] password)
        {
            wi = password;
            Console.WriteLine("B was initialized.");
        }

        public static void LogIn(int i)
        {
            if (CheckI(i))
            {
                Console.WriteLine("You are now logged in.");
                iA++;
                wi = A.H(wi);
            }
        }

        public static bool CheckI(int i)
        {
            if (iA != i)
            {
                Console.WriteLine("i != iA");
                return false;
            }

            Console.WriteLine(i);
            A.i++;
            if (!CompareArrays(A.H(wi), A.GetH()))
            {
                Console.WriteLine("Incorrect password!");
                Console.WriteLine(ArrayToString(A.H(wi)));
                Console.WriteLine(ArrayToString(A.GetH()));
                return false;
            }

            Console.WriteLine("Password correct!");
            Console.WriteLine(ArrayToString(A.H(wi)));
            Console.WriteLine(ArrayToString(A.GetH()));
            return true;
        }

        public static bool CompareArrays(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length)
                return false;

            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;

            return true;
        }

        public static string ArrayToString(byte[] array)
        {
            string s = "";
            foreach (byte item in array)
                s += item.ToString() + "_";
            return s;
        }
    }
}

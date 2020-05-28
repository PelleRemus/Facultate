using System;

namespace Listener
{
    public static class B
    {
        public static int iA = 1;
        public static byte[] wi;
        public static byte[] hashedWord, savedHashedWord;

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
                wi = hashedWord;
                hashedWord = savedHashedWord = null;
            }
        }

        public static bool CheckI(int i)
        {
            if (iA != i)
            {
                Console.WriteLine("i != iA");
                return false;
            }

            //trimite clientului wi si cere H(wi) si GetH()
            if (CompareArrays(hashedWord, savedHashedWord))
            {
                Console.WriteLine("Incorrect password!");
                return false;
            }

            Console.WriteLine("Password correct!");
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
    }
}

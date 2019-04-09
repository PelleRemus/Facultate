using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class A
    {
        public static byte[] w; //secret word
        public static byte[][] words;
        public static int i;
        public const int t = 100;
        public static byte[] wi;

        public static void Init(string word)
        {
            Aes aes = Aes.Create();
            w = Encryption(word, aes.CreateEncryptor(aes.Key, aes.IV));
            i = 1;

            words = new byte[t + 1][];
            words[0] = H(w);
            for (int i = 1; i < t + 1; i++)
                words[i] = H(words[i - 1]);
            for (int i = 0; i < words.Length / 2; i++)
            {
                byte[] aux = words[i];
                words[i] = words[words.Length - i - 1];
                words[words.Length - i - 1] = aux;
            }

            Console.WriteLine("A was initialized.");
            //B.Init(GetH()); transmisie spre server cu GetH()
        }
        static byte[] Encryption(string plainText, ICryptoTransform encryptor)
        {
            byte[] cryptedText;
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    cryptedText = msEncrypt.ToArray();
                }
            }
            return cryptedText;
        }

        public static void LogIn()
        {
            Console.WriteLine("A tries to log in.");
            //B.LogIn(i); transmisie spre server cu i
        }

        public static byte[] H(byte[] word)
        {
            HashAlgorithm hashObject = MD5.Create();
            return hashObject.ComputeHash(word);
        }

        public static byte[] GetH()
        {
            wi = words[words.Length - i];
            return wi;
        }
    }
}

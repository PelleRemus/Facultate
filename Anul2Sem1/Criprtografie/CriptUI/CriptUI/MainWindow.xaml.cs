using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace CriptUI
{
    public partial class MainWindow : Window
    {
        int algorithmNumber;
        int cipherModeNumber;
        int paddingNumber;
        Aes aes;
        DES des;
        RC2 rc2;
        TextWriter initialTextFile;
        TextWriter cryptedTextFile;
        TextWriter decryptedTextFile;
        string initialText;
        byte[] cryptedText;
        string decryptedText;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                Path.Text = dialog.FileName;
                initialText = File.ReadAllText(dialog.FileName);
                initialTextFile = new StreamWriter(@"../../InitialText.txt");
                initialTextFile.Write(initialText);
                initialTextFile.Close();
            }
        }

        void AlgorithmChanged(object sender, RoutedEventArgs e)
        {
            algorithmNumber = Algorithms.SelectedIndex;
            switch(algorithmNumber)
            {
                case 0:
                    {
                        aes = Aes.Create();
                        Key.Text = ArrayToString(aes.Key);
                        IV.Text = ArrayToString(aes.IV);
                        break;
                    }
                case 1:
                    {
                        des = DES.Create();
                        Key.Text = ArrayToString(des.Key);
                        IV.Text = ArrayToString(des.IV);
                        break;
                    }
                case 2:
                    {
                        rc2 = RC2.Create();
                        Key.Text = ArrayToString(rc2.Key);
                        IV.Text = ArrayToString(rc2.IV);
                        break;
                    }
            }
        }

        void CipherModeChanged(object sender, RoutedEventArgs e)
        {
            cipherModeNumber = CipherMode.SelectedIndex;
            System.Security.Cryptography.CipherMode mode = System.Security.Cryptography.CipherMode.CBC;

            switch(cipherModeNumber)
            {
                case 0: { mode = System.Security.Cryptography.CipherMode.CBC; break; }
                case 1: { mode = System.Security.Cryptography.CipherMode.ECB; break; }
                case 2: { mode = System.Security.Cryptography.CipherMode.OFB; break; }
                case 3: { mode = System.Security.Cryptography.CipherMode.CFB; break; }
                case 4: { mode = System.Security.Cryptography.CipherMode.CTS; break; }
            }
        }

        void PaddingChanged(object sender, RoutedEventArgs e)
        {
            paddingNumber = Padding.SelectedIndex;
            PaddingMode padding = PaddingMode.None;

            switch(paddingNumber)
            {
                case 1: { padding = PaddingMode.PKCS7; break; }
                case 2: { padding = PaddingMode.Zeros; break; }
                case 3: { padding = PaddingMode.ANSIX923; break; }
                case 4: { padding = PaddingMode.ISO10126; break; }
            }
        }

        string ArrayToString(byte[] array)
        {
            string s = "";
            foreach (byte item in array)
                s += item.ToString();
            return s;
        }

        private void Crypt_Click(object sender, RoutedEventArgs e)
        {
            switch(algorithmNumber)
            {
                case 0: { Encryption(aes.CreateEncryptor(aes.Key, aes.IV)); break; }
                case 1: { Encryption(des.CreateEncryptor(des.Key, des.IV)); break; }
                case 2: { Encryption(rc2.CreateEncryptor(rc2.Key, rc2.IV)); break; }
            }
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            switch (algorithmNumber)
            {
                case 0: { Decryption(aes.CreateDecryptor(aes.Key, aes.IV)); break; }
                case 1: { Decryption(des.CreateDecryptor(des.Key, des.IV)); break; }
                case 2: { Decryption(rc2.CreateDecryptor(rc2.Key, rc2.IV)); break; }
            }
        }

        void Encryption(ICryptoTransform encryptor)
        {
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(initialText);
                    }
                    cryptedText = msEncrypt.ToArray();
                }
            }
            
            cryptedTextFile = new StreamWriter(@"../../CryptedText.txt");
            cryptedTextFile.Write(ArrayToString(cryptedText));
            cryptedTextFile.Close();
        }

        void Decryption(ICryptoTransform decryptor)
        {
            if(cryptedText!=null)
            {
                using (MemoryStream msDecrypt = new MemoryStream(cryptedText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedText = srDecrypt.ReadToEnd();
                        }
                    }
                }

                decryptedTextFile = new StreamWriter(@"../../DecryptedText.txt");
                decryptedTextFile.Write(decryptedText);
                decryptedTextFile.Close();
            }
        }
    }
}

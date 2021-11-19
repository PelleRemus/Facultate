using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Parole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            aes = Aes.Create();

            TextReader dataLoad = new StreamReader(@"../../Password.txt");
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
                passwords.Add(buffer);
            dataLoad.Close();

            writer = new StreamWriter(@"../../Password.txt");
        }

        Random r = new Random();
        TextWriter writer;
        List<string> passwords = new List<string>();
        Aes aes;

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Weak.IsChecked = false;
            Medium.IsChecked = false;
            Strong.IsChecked = false;
            (sender as CheckBox).IsChecked = true;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            int categories = 1;
            int length = 3;
            Password.Text = "";
            Crypt_Password.Text = "";
            Save.IsEnabled = true;

            if (Weak.IsChecked == true)
                length = r.Next(6, 16);
            if (Medium.IsChecked == true)
                length = r.Next(16, 26);
            if (Strong.IsChecked == true)
                length = r.Next(26, 36);

            if (Numbers.IsChecked == true)
                categories++;
            if (Uppercase.IsChecked == true)
                categories++;
            if (SpecialCharacters.IsChecked == true)
                categories++;

            int categoryLength = length / categories;
            char[] password = new char[length];
            int i = 0, n = categoryLength;
            for (; i < n; i++)
                password[i] = (char)('a' + r.Next(26));

            n = 2 * n;
            if (categories == 2)
                n = length;

            if (Numbers.IsChecked == true)
            {
                for (; i < n; i++)
                    password[i] = (char)('0' + r.Next(10));
                n = 3 * categoryLength;
                if (categories == 3)
                    n = length;
            }

            if (Uppercase.IsChecked == true)
            {
                for (; i < n; i++)
                    password[i] = (char)('A' + r.Next(26));
            }

            char[] characters = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', ':', ';', '"', ',', '<', '.', '>', '/', '?', '\\', '|' };
            if (SpecialCharacters.IsChecked == true)
            {
                for (; i < length; i++)
                    password[i] = characters[r.Next(characters.Length)];
            }

            for (i = 1; i < length; i++)
            {
                int index = r.Next(i);
                char aux = password[i];
                password[i] = password[index];
                password[index] = aux;
            }

            for (i = 0; i < length; i++)
                Password.Text += password[i];
        }

        private void Crypt_Click(object sender, RoutedEventArgs e)
        {
            Crypt_Password.Text = "";
            if (Password.Text != "")
            {
                string plainText = Password.Text;
                Crypt_Password.Text = Encryption(plainText, aes.CreateEncryptor(aes.Key, aes.IV));
            }
        }

        string Encryption(string plainText, ICryptoTransform encryptor)
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

            return ArrayToString(cryptedText);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string buffer = Site.SelectedItem.ToString().Split(' ')[1];
            int index = passwords.Count;

            for (int i = 0; i < passwords.Count; i++)
                if (passwords[i].Split(' ')[0] == buffer)
                {
                    index = i;
                    break;
                }

            buffer += " ";
            if (Crypt_Password.Text != "")
                buffer+=Crypt_Password.Text + " " + ArrayToString(aes.Key) + " " + ArrayToString(aes.IV);
            else
                buffer+=Password.Text;

            if (index == passwords.Count)
                passwords.Add(buffer);
            else
                passwords[index] = buffer;

            Save.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            for (int i = 0; i < passwords.Count; i++)
                writer.WriteLine(passwords[i]);
            writer.Close();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            Decrypt_Password.Text = "";
            string buffer = Site.SelectedItem.ToString().Split(' ')[1];
            int index = passwords.Count;

            for (int i = 0; i < passwords.Count; i++)
                if (passwords[i].Split(' ')[0] == buffer)
                {
                    index = i;
                    break;
                }

            if (index == passwords.Count)
                return;

            byte[] cryptedText = StringToArray(passwords[index].Split(' ')[1]);
            try
            {
                byte[] key = StringToArray(passwords[index].Split(' ')[2]);
                byte[] iv = StringToArray(passwords[index].Split(' ')[3]);
                Decrypt_Password.Text = Decryption(cryptedText, aes.CreateDecryptor(key, iv));
            }
            catch
            {
                Decrypt_Password.Text = ArrayToString(cryptedText);
            }
        }

        string Decryption(byte[] cryptedText, ICryptoTransform decryptor)
        {
            string decryptedText = "";

            if (cryptedText != null)
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
            }
            return decryptedText;
        }

        string ArrayToString(byte[] array)
        {
            string s = "";
            foreach (byte item in array)
                s += item.ToString() + "_";
            return s;
        }

        byte[] StringToArray(string s)
        {
            string[] items = s.Split('_');
            byte[] b = new byte[items.Length - 1];
            for (int i = 0; i < items.Length - 1; i++) 
                b[i] = byte.Parse(items[i].ToString());
            return b;
        }
    }
}
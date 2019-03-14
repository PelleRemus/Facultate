using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            TextReader dataLoad = new StreamReader(@"../../Password.txt");
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
                passwords.Add(buffer);
            dataLoad.Close();

            writer = new StreamWriter(@"../../Password.txt");
        }

        Random r = new Random();
        int N;
        TextWriter writer;
        List<string> passwords = new List<string>();

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
                length = r.Next(6, 11);
            if (Medium.IsChecked == true)
                length = r.Next(11, 16);
            if (Strong.IsChecked == true)
                length = r.Next(16, 26);

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
                string cryptedText = "";
                N = r.Next(10, 20);

                for (int i = 0; i < plainText.Length; i++)
                    cryptedText += (char)(plainText[i] + N);

                Crypt_Password.Text = cryptedText;
            }
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
                buffer+=Crypt_Password.Text + " " + N;
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

            string cryptedText = passwords[index].Split(' ')[1];
            try
            {
                int key = int.Parse(passwords[index].Split(' ')[2]);
                string decryptedText = "";

                for (int i = 0; i < cryptedText.Length; i++)
                    decryptedText += (char)(cryptedText[i] - key);

                Decrypt_Password.Text = decryptedText;
            }
            catch
            {
                Decrypt_Password.Text = cryptedText;
            }
        }
    }
}
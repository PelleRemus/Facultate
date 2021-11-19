using System;
using System.Collections.Generic;
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
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowOnLoad();
        }

        string cript, key, decript;
        int n, m;
        char[,] matrix;
        int[] permutare;

        private void MainWindowOnLoad()
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");

            string buffer = dataLoad.ReadLine();
            txb_msgCript.Text = buffer;
            cript = buffer;

            buffer = dataLoad.ReadLine();
            txb_key.Text = buffer;
            key = buffer;

            m = key.Length;
            n = cript.Length / m;

            matrix = new char[n, m];

            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = cript[k];
                    k++;
                }
        }

        private void Decript_Click(object sender, RoutedEventArgs e)
        {
            //am implementat diferit de cum a explicat profu
            //si nu stiu daca merge bine
            permutare = new int[m];
            int k = 0;
            for (int i = 0; i < 26; i++)
            {
                char litera = (char)('a' + i);
                for (int j = 0; j <= n; j++)
                {
                    if (key[j] == litera)
                    {
                        permutare[k] = 'z' - litera;
                        k++;
                        break;
                    }
                }
            }
        }
    }
}

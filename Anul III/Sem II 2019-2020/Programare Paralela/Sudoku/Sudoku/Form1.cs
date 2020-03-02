using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] matrix;
        int n;

        private void Form1_Load(object sender, EventArgs e)
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");
            matrix = new int[9, 9];
            string buffer;
            int i = 0;

            while ((buffer = dataLoad.ReadLine()) != null)
            {
                string[] s = buffer.Split(' ');
                for (int j = 0; j < 9; j++)
                    matrix[i, j] = int.Parse(s[j]);
                i++;
            }
            Afisare();
            for (int k = 0; k < 100; k++)
                Solve();
            Afisare();

            n = CountZeros();
            bool[,] t = new bool[10, n];
        }

        void Solve()
        {
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                {
                    int t = Found(i, j);
                    if (matrix[i, j] == 0 && t != -1)
                        matrix[i, j] = t;
                }
        }

        int Found(int i, int j)
        {
            bool[] v = new bool[10];

            for (int k = 0; k < 9; k++)
            {
                v[matrix[i, k]] = true;
                v[matrix[k, j]] = true;
            }

            int startX = i / 3, startY = j / 3;

            for (int k = 0; k < 3; k++)
                for (int l = 0; l < 3; l++)
                    v[matrix[startX * 3 + k, startY * 3 + l]] = true;

            int nr = 0, index = 0;
            for (int k = 1; k < 10; k++)
                if (!v[k])
                {
                    nr++;
                    index = k;
                }
            if (nr == 1)
                return index;
            return -1;
        }

        int CountZeros()
        {
            int nr = 0;
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                    if (matrix[i, j] == 0)
                        nr++;
            return nr;
        }

        void ComplectMatrix()
        {
            int k = 0;
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        
                        k++;
                    }
                }
        }

        void Afisare()
        {
            for(int i=0; i<9; i++)
            {
                string s = "";
                for (int j = 0; j < 9; j++)
                    s += matrix[i, j] + " ";
                listBox1.Items.Add(s);
            }
            listBox1.Items.Add("");
        }
    }
}

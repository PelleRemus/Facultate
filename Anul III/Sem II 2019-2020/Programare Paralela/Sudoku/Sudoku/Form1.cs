using System;
using System.IO;
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

            SolveSudoku();
            Afisare();
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

        bool IsSafe(int row, int col, int num)
        { 
            for (int i = 0; i < 9; i++)
                if (matrix[row, i] == num)
                    return false;
            
            for (int i = 0; i < 9; i++)
                if (matrix[i, col] == num)
                    return false;
            
            int boxRowStart = row - row % 3;
            int boxColStart = col - col % 3;

            for (int i = boxRowStart; i < boxRowStart + 3; i++)
                for (int j = boxColStart; j < boxColStart + 3; j++)
                    if (matrix[i, j] == num)
                        return false;
            return true;
        }

        bool SolveSudoku()
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                if (!isEmpty)
                    break;
            }
            
            if (isEmpty)
                return true;
 
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num))
                {
                    matrix[row, col] = num;
                    if (SolveSudoku())
                        return true;
                    else
                        matrix[row, col] = 0;
                }
            }
            return false;
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

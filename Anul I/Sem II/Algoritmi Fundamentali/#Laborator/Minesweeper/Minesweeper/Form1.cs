using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Tile[,] matrix;
        bool[,] b, flag;
        int n, m, mines = 7;
        Bitmap bmp, b1, b2, b3;
        Graphics grp, g1, g2, g3;
        Random r = new Random();
        Color c = Color.FromArgb(110, 150, 210);

        public Form1()
        {
            InitializeComponent();
            b1 = new Bitmap(92, 30); b2 = new Bitmap(92, 30); b3 = new Bitmap(92, 30);
            g1 = Graphics.FromImage(b1); g2 = Graphics.FromImage(b2); g3 = Graphics.FromImage(b3);
            g1.Clear(Color.White); g2.Clear(c); g3.Clear(Color.White);
            Easy.Image = b1; Med.Image = b2; Hard.Image = b3;
        }

        void Start_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            matrix = new Tile[pictureBox1.Width / 20, pictureBox1.Height / 20];
            n = matrix.GetLength(0);
            m = matrix.GetLength(1);
            b = new bool[n, m];
            flag = new bool[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = new Tile("0", Color.Gray);
            int N = n * m / mines;
            for (int k = 0; k < N; k++)
            {
                bool ok = true;
                while (ok)
                {
                    int i = r.Next(n), j = r.Next(m);
                    if (matrix[i, j].x == "0")
                    {
                        matrix[i, j].x = "X";
                        ok = false;
                    }
                }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int x = 0;
                    if (matrix[i, j].x == "X") continue;
                    for (int k = i - 1; k <= i + 1; k++)
                        for (int l = j - 1; l <= j + 1; l++)
                            if (k >= 0 && k < n && l >= 0 && l < m)
                                if (matrix[k, l].x == "X") x++;
                    matrix[i, j].x = x.ToString();
                    switch (x)
                    {
                        case 1: matrix[i, j].color = Color.FromArgb(20, 100, 200); break;
                        case 2: matrix[i, j].color = Color.Green; break;
                        case 3: matrix[i, j].color = Color.Red; break;
                        case 4: matrix[i, j].color = Color.DarkBlue; break;
                        case 5: matrix[i, j].color = Color.DarkRed; break;
                        case 6: matrix[i, j].color = Color.DarkTurquoise; break;
                        case 7: matrix[i, j].color = Color.Black; break;
                        default: break;
                    }
                }

            grp.Clear(Color.LightGray);
            for (int i = 1; i < n; i++)
            {
                int x1 = i * 20, x2, y1 = 0, y2 = pictureBox1.Height;
                grp.DrawLine(Pens.Black, x1, y1, x1, y2);
                x1 = 0; x2 = pictureBox1.Width; y1 = i * 20;
                grp.DrawLine(Pens.Black, x1, y1, x2, y1);
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.X / 20, j = e.Y / 20;
            if (e.Button==MouseButtons.Left)
            {
                if (!flag[i,j])
                {
                    if (matrix[i, j].x == "X")
                        GameOver();
                    else
                        Parcurgere(i, j);
                }
            }
            else
            {
                if (!b[i, j])
                {
                    if (flag[i,j])
                    {
                        grp.FillRectangle(new SolidBrush(Color.LightGray), i * 20, j * 20, 20, 20);
                        flag[i, j] = false;
                    }
                    else
                    {
                        grp.FillRectangle(new SolidBrush(Color.Red), i * 20, j * 20, 20, 20);
                        flag[i,j] = true;
                    }
                }
            }

            bool ok = true;
            for(int k=0; k<n; k++)
                for(int l=0; l<m; l++)
                {
                    if (matrix[k, l].x == "X")
                        if (!flag[k, l])
                            ok = false;
                    if (flag[k, l])
                        if (matrix[k, l].x != "X")
                            ok = false;
                }
            pictureBox1.Image = bmp;
            if (ok)
            {
                MessageBox.Show("You Win!");
                pictureBox1.Enabled = false;
            }
        }

        void GameOver()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j].x == "0") continue;
                    SolidBrush brush = new SolidBrush(matrix[i,j].color);
                    grp.DrawString(matrix[i, j].x, new Font("Arial", 15, FontStyle.Bold), brush, new Point(i * 20, j * 20));
                }
            pictureBox1.Image = bmp;
            pictureBox1.Enabled = false;
            MessageBox.Show("You Lose!");
        }

        void Parcurgere(int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < m && b[i, j] == false)
            {
                b[i, j] = true;
                grp.FillRectangle(new SolidBrush(Color.White), i * 20, j * 20, 20, 20);
                if (matrix[i, j].x == "0")
                {
                    Parcurgere(i - 1, j);
                    Parcurgere(i, j + 1);
                    Parcurgere(i + 1, j);
                    Parcurgere(i, j - 1);
                }
                else
                    grp.DrawString(matrix[i, j].x, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(matrix[i, j].color), new Point(i * 20, j * 20));
            }
        }

        private void Easy_MouseDown(object sender, MouseEventArgs e)
        {
            g1.Clear(c);
            g2.Clear(Color.White);
            g3.Clear(Color.White);
            mines = 10;
            Easy.Image = b1; Med.Image = b2; Hard.Image = b3;
        }

        private void Med_MouseDown(object sender, MouseEventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(c);
            g3.Clear(Color.White);
            mines = 7;
            Easy.Image = b1; Med.Image = b2; Hard.Image = b3;
        }

        private void Hard_MouseDown(object sender, MouseEventArgs e)
        {
            g1.Clear(Color.White);
            g2.Clear(Color.White);
            g3.Clear(c);
            mines = 5;
            Easy.Image = b1; Med.Image = b2; Hard.Image = b3;
        }
    }

    public class Tile
    {
        public string x;
        public Color color;
        public Tile(string x, Color c)
        {
            this.x = x;
            color = c;
        }
    }
}

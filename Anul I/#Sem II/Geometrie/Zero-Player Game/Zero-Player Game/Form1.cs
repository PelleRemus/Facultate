using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.IEnumerable;

namespace Zero_Player_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        int[,] matrix;
        int n = 10, m, k = 50;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            Random r = new Random();
            m = pictureBox1.Width / n;
            matrix = new int[n, n];
            while (k > 0)
            {
                int i = r.Next(n);
                int j = r.Next(n);
                while (matrix[i, j] != 0)
                {
                    i = r.Next(n);
                    j = r.Next(n);
                }
                matrix[i, j] = 1;
                k--;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Point[] points = new Point[4];
                    points[0] = new Point(i * m, j * m);
                    points[1] = new Point((i + 1) * m, j * m);
                    points[2] = new Point((i + 1) * m, (j + 1) * m);
                    points[3] = new Point(i * m, (j + 1) * m);
                    if (matrix[i, j] == 1)
                        grp.FillPolygon(new SolidBrush(Color.Black), points);
                    else
                        grp.FillPolygon(new SolidBrush(Color.White), points);
                }
            pictureBox1.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Evolution();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Evolution()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Point[] points = new Point[4];
                    points[0] = new Point(i * m, j * m);
                    points[1] = new Point((i + 1) * m, j * m);
                    points[2] = new Point((i + 1) * m, (j + 1) * m);
                    points[3] = new Point(i * m, (j + 1) * m);

                    int count = 0;
                    if (i > 0 && j > 0) if (matrix[i - 1, j - 1] == 1) count++;
                    if (i > 0 && j < n - 1) if (matrix[i - 1, j + 1] == 1) count++;
                    if (i < n - 1 && j < n - 1) if (matrix[i + 1, j + 1] == 1) count++;
                    if (i < n - 1 && j > 0) if (matrix[i + 1, j - 1] == 1) count++;
                    if (matrix[i, j] == 1)
                    {
                        if (count <= 1) grp.FillPolygon(new SolidBrush(Color.White), points);
                        else if (count == 4) grp.FillPolygon(new SolidBrush(Color.White), points);
                    }
                    else
                        if (count == 3) grp.FillPolygon(new SolidBrush(Color.Black), points);
                }
            pictureBox1.Image = bmp;
        }
    }
}

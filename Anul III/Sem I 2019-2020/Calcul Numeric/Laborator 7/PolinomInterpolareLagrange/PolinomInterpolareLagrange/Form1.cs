using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolinomInterpolareLagrange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m = 4;
            a = new double[] { 0, 1.1, 1.3, 1.5, 1.6 };
            f = new double[] { 0, 1.032, 1.091, 1.145, 1.17 };
            d = new double[m + 1, m + 1];
            N = new double[m + 1];
        }

        int m, i;
        double alpha, epsilon, h;
        double[] a, f, N;
        double[,] d;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawSketch();

            h = 0.0016;
            epsilon = 1e-4;

            for (int j = 0; j <= m; j++)
                d[0, j] = f[j];
            for (i = 1; i <= m; i++)
                for (int j = 0; j < m - i; j++)
                    d[i, j] = (d[i - 1, j + 1] - d[i - 1, j]) / (a[i + j] - a[j]);
            N[0] = f[0];

            for (int k = 0; k <= 1000; k++)
            {
                alpha = k * h;
                double p = 1;
                for (i = 1; i <= m; i++)
                {
                    p *= alpha - a[i - 1];
                    N[i] = N[i - 1] + p * d[i, 0];

                    if (Math.Abs(N[i] - N[i - 1]) <= epsilon)
                        break;
                }
                listBox1.Items.Add(alpha + ", " + N[i]);
                grp.FillEllipse(new SolidBrush(Color.Black), center.X + (float)(alpha * (pictureBox1.Width - 20) / 1.6) - 1, center.Y - (float)(N[i] * (pictureBox1.Height - 20) / 1.6) - 1, 3, 3);
            }
            pictureBox1.Image = bmp;
        }

        void DrawSketch()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.DrawLine(Pens.Black, 0, pictureBox1.Height - 20, pictureBox1.Width, pictureBox1.Height - 20);
            grp.DrawLine(Pens.Black, 20, 0, 20, pictureBox1.Height);
            center = new Point(20, pictureBox1.Height - 20);

            for (int i = 0; i <= m; i++)
                grp.FillEllipse(new SolidBrush(Color.Red), center.X + (float)(a[i] * (pictureBox1.Width - 20) / 1.61) - 5, center.Y - (float)(f[i] * (pictureBox1.Height - 20) / 1.61) - 5, 9, 9);
            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreaptaRegresie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            n = 5;
            x = new double[] { 1, 3, 4, 6, 8, 9 };
            y = new double[] { 1, 2, 4, 4, 5, 3 };
        }

        double[] x, y;
        double scaleX, scaleY, ymin, ymax;
        int height, width, n;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            ymin = 1; ymax = 5;
            scaleX = x[n] - x[0] + 0.05;
            scaleY = ymax - ymin + 0.05;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            double p = (x[n] - x[0]) / 1000;
            double S1 = 0, S2 = 0, t0 = 0, t1 = 0;
            for(int i=0; i<=n; i++)
            {
                S1 += x[i];
                S2 += x[i] * x[i];
                t0 += y[i];
                t1 += x[i] * y[i];
            }

            double d = (n + 1) * S2 - S1 * S1,
                d1 = S2 * t0 - S1 * t1,
                d2 = (n + 1) * t1 - S1 * t0;

            for(int k=0; k<=1000; k++)
            {
                double alpha = x[0] + k * p;
                double R = d1 / d + d2 / d * alpha;

                float X = center.X + (float)((alpha - x[0]) * width / scaleX) - 1;
                float Y = center.Y - (float)((R - ymin) * height / scaleY) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), X, Y, 3, 3);
            }

        }

        void DrawSketch()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.DrawLine(Pens.Black, 0, height, pictureBox1.Width, height);
            grp.DrawLine(Pens.Black, 20, 0, 20, pictureBox1.Height);
            center = new Point(20, height);

            grp.DrawString(ymin.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 0, height - 15);
            grp.DrawString(ymax.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 0, 0);
            grp.DrawString(x[0].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, height);
            grp.DrawString(x[n].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 5, height);

            for (int i = 0; i <= n; i++)
            {
                float X = center.X + (float)((x[i] - x[0]) * width / scaleX) - 4;
                float Y = center.Y - (float)((y[i] - ymin) * height / scaleY) - 4;
                grp.FillEllipse(new SolidBrush(Color.Red), X, Y, 9, 9);
            }
            pictureBox1.Image = bmp;
        }
    }
}

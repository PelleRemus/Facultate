using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParabolaRegresie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            n = 6;
            x = new double[] { -3, -2, -1, 0, 1, 2, 3 };
            y = new double[] { 6, 4, 1, 2, 3, 8, 11 };
        }

        double[] x, y;
        double scaleX, scaleY, ymin, ymax;
        int height, width, n;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            ymin = 1; ymax = 11;
            scaleX = x[n] - x[0] + 0.05;
            scaleY = ymax - ymin + 0.05;
            width = pictureBox1.Width;
            height = pictureBox1.Height - 20;
            DrawSketch();

            double p = (x[n] - x[0]) / 1000;
            double S0 = 0, S1 = 0, S2 = 0, S3 = 0, t0 = 0, t1 = 0, t2 = 0;
            for(int i=0; i<=n; i++)
            {
                S0 += x[i];
                S1 += x[i] * x[i];
                S2 += x[i] * x[i] * x[i];
                S3 += x[i] * x[i] * x[i] * x[i];
                t0 += y[i];
                t1 += x[i] * y[i];
                t2 += x[i] * x[i] * y[i];
            }

            double d = (n + 1) * S1 * S3 + 2 * S0 * S1 * S2 - S1 * S1 * S1 - (n + 1) * S2 * S2 - S0 * S0 * S3,
               d1 = t0 * S1 * S3 + t1 * S1 * S2 + t2 * S0 * S2 - t2 * S1 * S1 - t0 * S2 * S2 - t1 * S0 * S3,
               d2 = (n + 1) * t1 * S3 + t2 * S0 * S1 + t0 * S1 * S2 - t1 * S1 * S1 - t0 * S0 * S3 - (n + 1) * t2 * S2,
               d3 = (n + 1) * t2 * S1 + t0 * S0 * S2 + t1 * S0 * S1 - t0 * S1 * S1 - (n + 1) * t1 * S2 - t2 * S0 * S0;

            for (int k = 0; k <= 1000; k++)
            {
                double alpha = x[0] + k * p;
                double R = d1 / d + d2 / d * alpha + d3 / d * alpha * alpha;
                listBox1.Items.Add(alpha.ToString("0.000") + ", " + R.ToString("0.000"));

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
            grp.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            center = new Point(0, height);

            grp.DrawString(ymin.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), pictureBox1.Width / 2 - 20, height - 15);
            grp.DrawString(ymax.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), pictureBox1.Width / 2 - 20, 0);
            grp.DrawString(x[0].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 0, height);
            grp.DrawString(x[n].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 25, height);

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

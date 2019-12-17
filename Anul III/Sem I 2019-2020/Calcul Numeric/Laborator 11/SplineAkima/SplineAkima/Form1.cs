using System;
using System.Drawing;
using System.Windows.Forms;

namespace SplineAkima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            n = 7;
            x = new double[] { 0.5, 3.5, 6, 9, 12, 15, 18, 21 };
            y = new double[] { 72, 85, 101, 120, 124, 90, 96, 129 };
            h = new double[n + 1]; m = new double[n + 1];
            p = new double[n + 4];
        }

        double[] x, y, h, m, p;
        double scaleX, scaleY, ymin, ymax;
        int height, width, n;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            ymin = 72; ymax = 129;
            scaleX = x[n];
            scaleY = ymax - ymin;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            double q = (x[n] - x[0]) / 1000;
            for (int i = 1; i <= n; i++)
                h[i] = x[i] - x[i - 1];

            for (int i = 0; i < n; i++)
                p[i + 2] = (y[i + 1] - y[i]) / h[i + 1];
            p[0] = 3 * p[2] - 2 * p[3];
            p[1] = 2 * p[2] - p[3];
            p[n + 2] = 2 * p[n + 1] - p[n];
            p[n + 3] = 3 * p[n + 1] - 2 * p[n];

            for (int i = 0; i <= n; i++)
                m[i] = (Math.Abs(p[i + 3] - p[i + 2]) * p[i + 1] + Math.Abs(p[i + 1] - p[i]) * p[i + 2]) / 
                    (Math.Abs(p[i + 3] - p[i + 2]) + Math.Abs(p[i + 1] - p[i]));

            for(int k=0; k<1000; k++)
            {
                double alpha = x[0] + k * q;
                double S = 0;
                for (int i = 1; i <= n; i++)
                    if (x[i - 1] <= alpha && alpha <= x[i])
                        S = (((x[i] - alpha) * (x[i] - alpha) * (2 * (alpha - x[i - 1]) + h[i])) / (h[i] * h[i] * h[i])) * y[i - 1] +
                            (((alpha - x[i - 1]) * (alpha - x[i - 1]) * (2 * (x[i] - alpha) + h[i])) / (h[i] * h[i] * h[i])) * y[i] +
                            (((x[i] - alpha) * (x[i] - alpha) * (alpha - x[i - 1])) / (h[i] * h[i])) * m[i - 1] -
                            (((alpha - x[i - 1]) * (alpha - x[i - 1]) * (x[i] - alpha)) / (h[i] * h[i])) * m[i];

                float X = center.X + (float)((alpha - x[0]) * width / scaleX) - 1;
                float Y = center.Y - (float)((S - ymin) * height / scaleY) - 1;
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

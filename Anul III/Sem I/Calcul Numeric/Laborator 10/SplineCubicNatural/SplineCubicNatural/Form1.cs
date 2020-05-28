using System;
using System.Drawing;
using System.Windows.Forms;

namespace SplineCubicNatural
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            n = 7;
            x = new double[] { 0.5, 3.5, 6, 8.5, 11, 14, 17, 20 };
            y = new double[] { 130, 121, 128, 96, 122, 138, 114, 90 };
            h = new double[n + 1]; m = new double[n + 1];
            a = new double[n + 1]; b = new double[n + 1];
            c = new double[n + 1]; d = new double[n + 1];
            u = new double[n + 1]; w = new double[n + 1];
            z = new double[n + 1];
        }

        double[] x, y, h, m;
        double[] a, b, c, d, u, w, z;
        double scaleX, scaleY, ymin, ymax;
        int height, width, n;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            ymin = 90; ymax = 139;
            scaleX = x[n];
            scaleY = ymax - ymin;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            #region Calcule Initiale
            for (int i = 1; i <= n; i++)
                h[i] = x[i] - x[i - 1];

            a[0] = 2; a[n] = 2;
            c[0] = 1; b[n] = 1;
            for (int i = 1; i < n; i++)
            {
                a[i] = 2 * (1.0 / h[i] + 1.0 / h[i + 1]);
                b[i] = 1.0 / h[i];
                c[i] = 1.0 / h[i + 1];
            }

            d[0] = (3.0 / h[1]) * (y[1] - y[0]);
            d[n] = (3.0 / h[n]) * (y[n] - y[n - 1]);
            for (int i = 1; i < n; i++)
                d[i] = (3.0 / (h[i] * h[i])) * (y[i] - y[i - 1]) + 
                    (3.0 / (h[i + 1] * h[i + 1])) * (y[i + 1] - y[i]);

            u[0] = c[0] / a[0];
            for (int i = 1; i < n; i++)
            {
                w[i] = a[i] - u[i - 1] * b[i];
                u[i] = c[i] / w[i];
            }
            w[n] = a[n] - u[n - 1] * b[n];

            z[0] = d[0] / 2;
            for (int i = 1; i < n; i++)
                z[i] = (d[i] - b[i] * z[i - 1]) / w[i];
            #endregion

            m[n] = z[n];
            for (int i = n - 1; i >= 0; i--)
                m[i] = z[i] - u[i] * m[i + 1];

            double p = (x[n] - x[0]) / 1000;
            for (int k = 0; k <= 1000; k++)
            {
                double alpha = x[0] + p * k;
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

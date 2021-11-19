using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spline_quadratic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //radical
            x = new double[] { 1, 2, 3, 4, 5, 7, 8, 9 };
            y = new double[] { 1, 1.4142, 1.732, 2, 2.2361, 2.6458, 2.8284, 3 };

            //functie aleatoare
            //x = new double[] { 0.5, 3.5, 6, 8.5, 11, 14, 17, 20 };
            //y = new double[] { 130, 121, 128, 96, 122, 138, 114, 90 };

            n = 7;
            h = new double[n + 1]; m = new double[n + 1];
        }

        double[] x, y, h, m;
        double scaleX, scaleY, ymin, ymax;
        int height, width, n;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            //radical
            ymin = y[0]; ymax = y[n];
            scaleX = x[n] - x[0] + 0.05;
            //functie aleatoare
            //ymin = 81; ymax = 166;
            //scaleX = x[n];

            scaleY = ymax - ymin;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            for (int i = 1; i <= n; i++)
                h[i] = x[i] - x[i - 1];
            m[0] = (2 * h[1] + h[2]) / (h[1] * (h[1] + h[2])) * (y[1] - y[0]) -
                h[1] * (y[2] - y[1]) / (h[2] * (h[1] + h[2]));
            //m[0] = 0.5; //radical 

            for (int i = 1; i <= n; i++)
                m[i] = -m[i - 1] + 2 / h[i] * (y[i] - y[i - 1]);

            double p = (x[n] - x[0]) / 1000;
            for(int k=0; k<=1000; k++)
            {
                double alpha = x[0] + p * k;
                double S = 0;
                for (int i = 1; i <= n; i++)
                    if (x[i - 1] <= alpha && alpha <= x[i])
                        S = (m[i] - m[i - 1]) / 2 / h[i] * (alpha - x[i - 1]) * (alpha - x[i - 1]) +
                            m[i - 1] * (alpha - x[i - 1]) + y[i - 1];
                //radical
                listBox1.Items.Add(alpha.ToString("0.000") + " " + S.ToString("0.0000") + " " + Math.Sqrt(alpha).ToString("0.0000"));
                //functie aleatoare
                //listBox1.Items.Add(alpha.ToString("0.000") + " " + S.ToString("0.000000"));

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

            //radical
            //*
            double p = (x[n] - x[0]) / 1000;
            for (int k=0; k<1000; k++)
            {
                double alpha = x[0] + p * k;
                float X = center.X + (float)((alpha-x[0]) * width / scaleX) - 1;
                float Y = center.Y - (float)((Math.Sqrt(alpha) - ymin) * height / scaleY) - 1;
                grp.FillEllipse(new SolidBrush(Color.Black), X, Y, 3, 3);
            }
            //*/
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

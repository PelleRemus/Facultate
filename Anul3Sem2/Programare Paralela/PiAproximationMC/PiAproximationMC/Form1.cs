using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiAproximationMC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Pi.Text = Math.PI.ToString();
        }

        Graphics grp;
        Bitmap bmp;
        List<PointF> pointList;
        int scale;

        private void Start_Click(object sender, EventArgs e)
        {
            scale = pictureBox1.Width;
            bmp = new Bitmap(scale, scale);
            grp = Graphics.FromImage(bmp);
            grp.DrawEllipse(new Pen(Color.Black, 2), -1, -1, scale - 1, scale - 1);

            try
            {
                Stopwatch watch = Stopwatch.StartNew();
                double result = CalculatePi(uint.Parse(nrOfThreads.Text), ulong.Parse(Points.Text));
                watch.Stop();
                Aprox.Text = result.ToString();
                Time.Text = watch.ElapsedMilliseconds + " ms";

                foreach (PointF p in pointList)
                    grp.DrawEllipse(Pens.Red, p.X, p.Y, 1, 1);
                pictureBox1.Image = bmp;
            }
            catch
            {
                MessageBox.Show("Please insert numbers greater than 0!", "Error");
            }
        }

        double CalculatePi(uint threads, ulong points)
        {
            ulong n = points / threads;
            int pointsInCircle = 0;
            Task<int>[] tasks = new Task<int>[threads];
            pointList = new List<PointF>();

            for (int i = 0; i < threads; i++)
            {
                tasks[i] = Task<int>.Factory.StartNew(() =>
                {
                    Random random = new Random();
                    int insideCircleCount = 0;
                    for (uint j = 0; j < n; j++)
                    {
                        double x = random.NextDouble();
                        double y = random.NextDouble();

                        double result = x * x + y * y;
                        if (result <= 1)
                            insideCircleCount++;

                        pointList.Add(new PointF((float)x * scale, (float)y * scale));
                    }
                    return insideCircleCount;
                });
            }

            for (int i = 0; i < threads; i++)
                pointsInCircle += tasks[i].Result;

            return 4.0 * pointsInCircle / points;
        }
    }
}

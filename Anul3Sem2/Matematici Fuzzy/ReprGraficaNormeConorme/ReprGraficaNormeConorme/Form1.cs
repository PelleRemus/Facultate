using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReprGraficaNormeConorme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int width, height;
        float h = 0.001f, scale = 3;
        Graphics grp;
        Bitmap bmp;
        Point center;

        void DrawSketch()
        {
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.DrawLine(Pens.Black, 0, height, pictureBox1.Width, height);
            grp.DrawLine(Pens.Black, 20, 0, 20, pictureBox1.Height);

            grp.DrawString("0", new Font("Arial", 15), new SolidBrush(Color.Black), 0, height - 15);
            grp.DrawString("1", new Font("Arial", 15), new SolidBrush(Color.Black), 0, 0);
            grp.DrawString("0", new Font("Arial", 15), new SolidBrush(Color.Black), 20, height);
            grp.DrawString(scale.ToString(), new Font("Arial", 15), new SolidBrush(Color.Black), width - 15, height);

            center = new Point(20, height);
            pictureBox1.Image = bmp;
        }

        void SetPoint(float n, Color c)
        {
            grp.DrawString(n.ToString(), new Font("Arial", 15), new SolidBrush(c), 10 + n * width / scale, height);
        }
        void Legend(string s, int i, Color c)
        {
            grp.FillRectangle(new SolidBrush(c), width - 90, 10 + i * 25, 15, 15);
            grp.DrawString(s, new Font("Arial", 15), new SolidBrush(Color.Black), width - 75, 5 + i * 25);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("1/(1+x^2)", 0, Color.Blue);
            Legend("1/(10^x)", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 3;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - B(k * h) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("TL", 0, Color.Blue);
            Legend("SL", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - TL(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - SL(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("TF∞", 0, Color.Blue);
            Legend("SF∞", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - TF(A(k * h), B(k * h), Int32.MaxValue) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - SF(A(k * h), B(k * h), Int32.MaxValue) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("TG", 0, Color.Blue);
            Legend("SG", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - TG(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - SG(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("TF1", 0, Color.Blue);
            Legend("SF1", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - TF(A(k * h), B(k * h), 1.00001f) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - SF(A(k * h), B(k * h), 1.00001f) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("A∧B", 1, Color.Blue);
            Legend("A∨B", 0, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - Math.Min(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - Math.Max(A(k * h), B(k * h)) * height + 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawSketch();
            Legend("TF0", 0, Color.Blue);
            Legend("SF0", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - TF(A(k * h), B(k * h), 0.00001f) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - SF(A(k * h), B(k * h), 0.00001f) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        float A(float x)
        {
            return 1f / (1 + x * x);
        }
        float B(float x)
        {
            return 1f / (float)Math.Pow(10, x);
        }

        float TL(float x, float y)
        {
            return Math.Max(x + y - 1, 0);
        }
        float SL(float x, float y)
        {
            return Math.Min(x + y, 1);
        }

        float TG(float x, float y)
        {
            return x * y;
        }
        float SG(float x, float y)
        {
            return x + y - x * y;
        }

        float TF(float x, float y, float s)
        {
            return (float)(Math.Log(1 + (Math.Pow(s, x) - 1) * (Math.Pow(s, y) - 1) / (s - 1)) / Math.Log(s));
        }
        float SF(float x, float y, float s)
        {
            return 1 - TF(1 - x, 1 - y, s);
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReprGraficaMultFuzzySiOperatii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int width, height;
        float h = 0.001f, scale = 11;
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
            grp.FillRectangle(new SolidBrush(c), 30, 10 + i * 25, 15, 15);
            grp.DrawString(s, new Font("Arial", 15), new SolidBrush(Color.Black), 45, 5 + i * 25);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawSketch();
            SetPoint(1, Color.Blue);
            SetPoint(2, Color.Red);
            SetPoint(3, Color.Red);
            SetPoint(4, Color.Red);
            SetPoint(6, Color.Red);
            SetPoint(7, Color.Blue);
            SetPoint(10, Color.Blue);
            Legend("A", 0, Color.Blue);
            Legend("B", 1, Color.Red);

            for (int k=0; k<11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 3;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - B(k * h) * height;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawSketch();
            grp.DrawString("1/2", new Font("Arial", 15), new SolidBrush(Color.Blue), 20, height / 2);
            SetPoint(4, Color.Blue);
            SetPoint(7, Color.Blue);
            SetPoint(8.5f, Color.Blue);
            Legend("A", 0, Color.LightGray);
            Legend("A1/2", 1, Color.Blue);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 1;

                Color c = Color.LightGray;
                if (A(k * h) >= 0.5)
                    c = Color.Blue;
                grp.FillEllipse(new SolidBrush(c), x, y, 3, 3);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawSketch();
            SetPoint(3, Color.Red);
            SetPoint(4, Color.Red);
            SetPoint(7, Color.Blue);
            Legend("A, B", 0, Color.LightGray);
            Legend("A1", 1, Color.Blue);
            Legend("B1", 2, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.LightGray), x, y, 3, 3);

                y = center.Y - B(k * h) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.LightGray), x, y, 3, 3);
            }

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 2;
                float y = center.Y - A(k * h) * height - 2;
                if (k == 7000)
                    grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 5, 5);

                y = center.Y - B(k * h) * height - 2;
                if (B(k * h) == 1)
                    grp.FillEllipse(new SolidBrush(Color.Red), x, y, 5, 5);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawSketch();
            SetPoint(1, Color.Blue);
            SetPoint(2, Color.Red);
            SetPoint(3, Color.Red);
            SetPoint(4, Color.Red);
            SetPoint(6, Color.Red);
            SetPoint(7, Color.Blue);
            SetPoint(10, Color.Blue);
            Legend("suppA", 0, Color.Blue);
            Legend("suppB", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 1;
                if (A(k * h) > 0)
                    grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - B(k * h) * height - 1;
                if (B(k * h) > 0)
                    grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawSketch();
            SetPoint(2.2f, Color.Red);
            SetPoint(4.75f, Color.Blue);
            Legend("A∨B", 0, Color.Blue);
            Legend("A∧B", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - Math.Max(A(k * h), B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - Math.Min(A(k * h), B(k * h)) * height + 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawSketch();
            grp.DrawLine(new Pen(Color.Green, 2), 0, height / 2, pictureBox1.Width, height / 2);
            grp.DrawString("1/2", new Font("Arial", 15), new SolidBrush(Color.Green), 20, height / 2);
            SetPoint(1, Color.Blue);
            SetPoint(4, Color.Green);
            SetPoint(7, Color.Red);
            SetPoint(8.5f, Color.Green);
            SetPoint(10, Color.Blue);
            Legend("A", 0, Color.Blue);
            Legend("1-A", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - A(k * h) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - (1 - A(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            scale = 7;
            DrawSketch();
            grp.DrawLine(new Pen(Color.Green, 2), 0, height / 2, pictureBox1.Width, height / 2);
            grp.DrawString("1/2", new Font("Arial", 15), new SolidBrush(Color.Green), 20, height / 2);
            SetPoint(2, Color.Blue);
            SetPoint(2.5f, Color.Green);
            SetPoint(3, Color.Red);
            SetPoint(4, Color.Red);
            SetPoint(5, Color.Green);
            SetPoint(6, Color.Blue);
            Legend("B", 0, Color.Blue);
            Legend("1-B", 1, Color.Red);

            for (int k = 0; k < 11000; k++)
            {
                float x = center.X + k * h * width / scale - 1;
                float y = center.Y - B(k * h) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - (1 - B(k * h)) * height - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
            }
            scale = 11;
        }

        float A(float x)
        {
            if (x < 1) return 0;
            if (x < 7) return (x - 1) / 6;
            if (x < 10) return (10 - x) / 3;
            return 0;
        }

        float B(float x)
        {
            if (x < 2) return 0;
            if (x < 3) return x - 2;
            if (x < 4) return 1;
            if (x < 6) return (6 - x) / 2;
            return 0;
        }
    }
}

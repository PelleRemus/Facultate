using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        static Random r = new Random();
        Pen pen = new Pen(Color.FromArgb(70, 70, 70), 2);
        //
        // Cerc
        //
        class Cerc
        {
            int l, o1, o2;
            public Cerc(int lenght, int x, int y)
            {
                l = lenght;
                o1 = x;
                o2 = y;
            }
            public void DeseneazaCerc(Graphics grp, Pen pen)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawEllipse(pen, o1 - 2, o2 - 2, 5, 5);
                pen.Color = Color.MediumBlue;
                for (int i = 1; i <= 1000; i++)
                {
                    float fi = (float)Math.PI * 2000 / i;
                    float x = o1 + l * (float)Math.Cos(fi);
                    float y = o2 + l * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x, y, 1, 1);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int l = r.Next(pictureBox1.Height / 2 - 10);
            int o1 = r.Next(l, pictureBox1.Width - l);
            int o2 = r.Next(l, pictureBox1.Height - l);

            Cerc cerc = new Cerc(l, o1, o2);
            cerc.DeseneazaCerc(grp, pen);
            pictureBox1.Image = bmp;
        }
        //
        // Elipsa
        //
        class Elipsa
        {
            int c, o1, o2, f1, f2, a;
            float b;
            public Elipsa(int l, int x, int y, int k)
            {
                c = l; o1 = x; o2 = y; a = k;
                f1 = o1 - c; f2 = o1 + c;
                b = (float)Math.Sqrt(a * a - c * c);
            }
            public void DeseneazaElipsa(Graphics grp, Pen pen)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawEllipse(pen, f1 - 2, o2 - 2, 5, 5);
                grp.DrawEllipse(pen, f2 - 2, o2 - 2, 5, 5);
                pen.Color = Color.MediumBlue;
                for (int i = 1; i <= 1000; i++)
                {
                    float fi = (float)Math.PI * 2000 / i;
                    float x = o1 + a * (float)Math.Cos(fi);
                    float y = o2 + b * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x, y, 2, 2);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int c = r.Next(pictureBox1.Height / 2);
            int o1 = r.Next(2 * c, pictureBox1.Width - 2 * c);
            int o2 = r.Next(c, pictureBox1.Height - c);
            int a = r.Next(c, o1);

            Elipsa elipsa = new Elipsa(c, o1, o2, a);
            elipsa.DeseneazaElipsa(grp, pen);
            pictureBox1.Image = bmp;
        }
        //
        // Hiperbola
        //
        class Hiperbola
        {
            int c, o1, o2, f1, f2, a;
            float b;
            public Hiperbola(int l, int x, int y, int k)
            {
                c = l; o1 = x; o2 = y; a = k;
                f1 = o1 - c; f2 = o1 + c;
                b = (float)Math.Sqrt(c * c - a * a);
            }
            public void DeseneazaHiperbola(Graphics grp, Pen pen)
            {
                pen.Color = Color.MediumBlue;
                for (int i = 1; i <= 10000; i++)
                {
                    float x, y, t;
                    t = 0.01f * i;
                    x = o1 + a / 2 * (t + 1 / t);
                    y = o2 + b / 2 * (t - 1 / t);
                    grp.DrawEllipse(pen, x, y, 2, 2);
                    grp.DrawEllipse(pen, x, 2 * o2 - y, 2, 2);
                    grp.DrawEllipse(pen, 2 * o1 - x, y, 2, 2);
                    grp.DrawEllipse(pen, 2 * o1 - x, 2 * o2 - y, 2, 2);
                }
            }
            public void DeseneazaAsimptote(Graphics grp, Pen pen)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                pen.Width = 1;
                grp.DrawEllipse(pen, f1 - 2, o2 - 2, 5, 5);
                grp.DrawEllipse(pen, f2 - 2, o2 - 2, 5, 5);
                grp.DrawEllipse(pen, o1 - 2, o2 - 2, 5, 5);
                for (int i = 1; i <= 10000; i++)
                {
                    float x, y;
                    y = 0.1f * i;
                    x = a * y / b;
                    grp.DrawEllipse(pen, o1 + x, o2 + y, 1, 1);
                    grp.DrawEllipse(pen, o1 - x, o2 + y, 1, 1);
                    grp.DrawEllipse(pen, o1 + x, o2 - y, 1, 1);
                    grp.DrawEllipse(pen, o1 - x, o2 - y, 1, 1);
                }
                pen.Width = 2;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int c = r.Next(pictureBox1.Height / 2);
            int o1 = r.Next(2 * c, pictureBox1.Width - 2 * c);
            int o2 = r.Next(c, pictureBox1.Height - c);
            int a = r.Next(c);

            Hiperbola hiperbola = new Hiperbola(c, o1, o2, a);
            hiperbola.DeseneazaHiperbola(grp, pen);
            hiperbola.DeseneazaAsimptote(grp, pen);
            pictureBox1.Image = bmp;
        }
        //
        // Parabola
        //
        class Parabola
        {
            int o1, o2, p, f;
            public Parabola(int x, int y, int k)
            {
                o1 = x; o2 = y; p = k; f = o1 + p;
            }
            public void DeseneazaParabola(Graphics grp, Pen pen)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawEllipse(pen, f - 2, o2 - 2, 5, 5);
                grp.DrawEllipse(pen, o1 - 2, o2 - 2, 5, 5);
                for (int i = 1; i < 10000; i++)
                {
                    float y = (float)i, x = o1 - p;
                    grp.DrawEllipse(pen, x, y, 1, 1);
                }
                pen.Color = Color.MediumBlue;
                for (int i=1; i<10000; i++)
                {
                    float y = 0.1f * i;
                    float x = y * y / (4 * p);
                    grp.DrawEllipse(pen, o1 + x, o2 + y, 2, 2);
                    grp.DrawEllipse(pen, o1 + x, o2 - y, 2, 2);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int o1 = r.Next(pictureBox1.Width), o2 = r.Next(pictureBox1.Height), p;
            if (o1 < pictureBox1.Width / 2)
                p = r.Next(o1);
            else
                p = r.Next(pictureBox1.Width - o1);
            Parabola parabola = new Parabola(o1, o2, p);
            parabola.DeseneazaParabola(grp, pen);
            pictureBox1.Image = bmp;
        }
        //
        // Cicloida
        //
        class Cicloida
        {
            int o1, o2, a;
            public Cicloida(int x, int y, int k)
            {
                o1 = x; o2 = y; a = k;
            }
            public void DeseneazaCerc(Graphics grp, Pen pen, int l)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawLine(pen, 0, o2, l, o2);
                grp.DrawEllipse(pen, o1 - 2, o2 - a - 2, 5, 5);

                for (int i = 0; i < 360; i++)
                {
                    float fi = (float)Math.PI / 180 * i;
                    float x = o1 + a * (float)Math.Cos(fi);
                    float y = o2 - a + a * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x, y, 1, 1);
                }
            }
            public void DeseneazaCicloida(Graphics grp, Pen pen)
            {
                pen.Color = Color.MediumBlue;
                for (int i = 1; i < 10000; i++)
                {
                    float t = (float)(Math.PI / 100 * i);
                    float x = o1 + a * (t - (float)Math.Sin(t));
                    float y = o2 - a * (1 - (float)Math.Cos(t));
                    grp.DrawEllipse(pen, x, y, 2, 2);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int o1 = r.Next(pictureBox1.Width / 3);
            int o2 = r.Next(pictureBox1.Height / 2, pictureBox1.Height);
            int a = r.Next(1, 100), l = pictureBox1.Width;

            Cicloida cicloida = new Cicloida(o1, o2, a);
            cicloida.DeseneazaCerc(grp, pen, l);
            cicloida.DeseneazaCicloida(grp, pen);
            pictureBox1.Image = bmp;
        }
        //
        // Spirala lui Arhimede
        //
        class SpiraArhimede
        {
            int o1, o2;
            public SpiraArhimede(int x, int y)
            {
                o1 = x; o2 = y;
            }
            public void DeseneazaSpirala(Graphics grp, Pen pen, int w, int h)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawLine(pen, o1, 0, o1, h);
                grp.DrawLine(pen, 0, o2, w, o2);
                float x1 = o1, y1 = o2;
                pen.Color = Color.MediumBlue;
                for (int i = 1; i < 1000; i++)
                {
                    float fi = 0.1f * i;
                    float x2 = o1 + i * (float)Math.Cos(fi);
                    float y2 = o2 + i * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x2 - 1, y2 - 1, 2, 2);
                    grp.DrawLine(pen, x1, y1, x2, y2);
                    x1 = x2; y1 = y2;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int o1 = pictureBox1.Width / 2, w = pictureBox1.Width;
            int o2 = pictureBox1.Height / 2, h = pictureBox1.Height;

            SpiraArhimede spirala = new SpiraArhimede(o1, o2);
            spirala.DeseneazaSpirala(grp, pen, w, h);
            pictureBox1.Image = bmp;
        }
        //
        // Spirala Logaritmica
        //
        class SpiraLog
        {
            int o1, o2;
            static float m = 0.03f;
            public SpiraLog(int x, int y)
            {
                o1 = x; o2 = y;
            }
            public void DeseneazaSpirala(Graphics grp, Pen pen, int w, int h)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawLine(pen, o1, 0, o1, h);
                grp.DrawLine(pen, 0, o2, w, o2);
                float x1 = o1, y1 = o2;
                pen.Color = Color.MediumBlue;
                for (int i = 1; i < 1000; i++)
                {
                    float fi = 0.1f * i;
                    float ro = i * (float)Math.Pow(Math.E, m * fi);
                    float x2 = o1 + ro * (float)Math.Cos(fi);
                    float y2 = o2 + ro * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x2 - 1, y2 - 1, 2, 2);
                    grp.DrawLine(pen, x1, y1, x2, y2);
                    x1 = x2; y1 = y2;
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int o1 = pictureBox1.Width / 2, w = pictureBox1.Width;
            int o2 = pictureBox1.Height / 2, h = pictureBox1.Height;

            SpiraLog spirala = new SpiraLog(o1, o2);
            spirala.DeseneazaSpirala(grp, pen, w, h);
            pictureBox1.Image = bmp;
        }
        //
        // Tetrafoliul
        //
        class Tetrafoliul
        {
            int o1, o2, a;
            public Tetrafoliul(int x, int y, int k)
            {
                o1 = x; o2 = y; a = k;
            }
            public void DeseneazaTetrafoliul(Graphics grp, Pen pen, int w, int h)
            {
                pen.Color = Color.FromArgb(70, 70, 70);
                grp.DrawLine(pen, o1, 0, o1, h);
                grp.DrawLine(pen, 0, o2, w, o2);
                float x1 = o1, y1 = o2;
                pen.Color = Color.MediumBlue;
                for (int i = 1; i < 1000; i++)
                {
                    float fi = 0.1f * i;
                    float x2 = o1 + a * (float)Math.Sin(2 * fi) * (float)Math.Cos(fi);
                    float y2 = o2 + a * (float)Math.Sin(2 * fi) * (float)Math.Sin(fi);
                    grp.DrawEllipse(pen, x2 - 1, y2 - 1, 2, 2);
                    grp.DrawLine(pen, x1, y1, x2, y2);
                    x1 = x2; y1 = y2;
                    a += 1;
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int o1 = pictureBox1.Width / 2, w = pictureBox1.Width;
            int o2 = pictureBox1.Height / 2, h = pictureBox1.Height;
            int a = r.Next(o2);

            Tetrafoliul tetra = new Tetrafoliul(o1, o2, a);
            tetra.DeseneazaTetrafoliul(grp, pen, w, h);
            pictureBox1.Image = bmp;
        }
    }
}

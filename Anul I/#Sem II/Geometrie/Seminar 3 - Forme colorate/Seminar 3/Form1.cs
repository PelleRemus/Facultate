using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_3
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

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        public void FigGeometrica(int n, float l, PointF center, float phi, Color fill, Color Draw)
        {
            Pen pen = new Pen(Color.Blue);
            float unghi = (float)(Math.PI * 2) / (float)n;
            PointF[] points = new PointF[n];
            for (int i=0; i<n; i++)
            {
                float x = center.X + l * (float)Math.Cos(unghi * i + phi);
                float y = center.Y + l * (float)Math.Sin(unghi * i + phi);
                points[i] = new PointF(x, y);
            }
            grp.FillPolygon(new SolidBrush(fill), points);
            grp.DrawPolygon(new Pen(Draw, 2), points);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, x, y;
            float l, a;
            Color fill, draw;
            for (int i = 0; i < 100; i++)
            {
                x = r.Next(pictureBox1.Width);
                y = r.Next(pictureBox1.Height);
                fill = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                n = r.Next(3, 20);
                l = (float)r.Next(10, 150);
                a = (float)(r.NextDouble() * Math.PI * 2);
                FigGeometrica(n, l, new PointF(x, y), a, fill, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //grp = Graphics.FromImage(bmp);
            for (int i = 0; i < 20; i++)
            {
                int n = 3, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color fill = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica(n, l, new PointF(x, y), a, fill, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < 20; i++)
            {
                int n = 3, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica2(n, l, new PointF(x, y), a, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < 20; i++)
            {
                int n = 100, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica2(n, l, new PointF(x, y), a, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //grp = Graphics.FromImage(bmp);
            for (int i = 0; i < 20; i++)
            {
                int n = 100, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color fill = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica(n, l, new PointF(x, y), a, fill, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           // grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < 20; i++)
            {
                int n = 4, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica2(n, l, new PointF(x, y), a, draw);
            }
            pictureBox1.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //grp = Graphics.FromImage(bmp);
            for (int i = 0; i < 20; i++)
            {
                int n = 4, x, y;
                float l = (float)r.Next(30, 100);
                x = r.Next((int)l, pictureBox1.Width - (int)l);
                y = r.Next((int)l, pictureBox1.Height - (int)l);
                float a = (float)r.NextDouble() * (float)Math.PI * 2;
                Color fill = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                Color draw = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                FigGeometrica(n, l, new PointF(x, y), a, fill, draw);
            }
            pictureBox1.Image = bmp;
        }

        public void FigGeometrica2(int n, float l, PointF center, float phi, Color Draw)
        {
            Pen pen = new Pen(Color.Blue);
            float unghi = (float)(Math.PI * 2) / (float)n;
            PointF[] points = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                float x = center.X + l * (float)Math.Cos(unghi * i + phi);
                float y = center.Y + l * (float)Math.Sin(unghi * i + phi);
                points[i] = new PointF(x, y);
            }
            grp.DrawPolygon(new Pen(Draw, 2), points);
        }
    }
}

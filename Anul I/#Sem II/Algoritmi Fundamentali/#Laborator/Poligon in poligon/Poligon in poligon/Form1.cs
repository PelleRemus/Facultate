using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poligon_in_poligon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grp;
        Bitmap bmp;
        PointF[] points;
        int n = 50;
        static Random rnd = new Random();
        PointF first, last;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            points = new PointF[n];
            for (int i = 0; i < n; i++)
                points[i] = GetRandomPoint();

            first = CG(points);
            Rec();
            last = CG(points);

            textBox1.Text += D(first, last);
            pictureBox1.Image = bmp;
        }

        public float D(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        public PointF GetRandomPoint()
        {
            float x = rnd.Next(pictureBox1.Width);
            float y = rnd.Next(pictureBox1.Height);
            return new PointF(x, y);
        }

        public void DrawMap(PointF[] points)
        {
            Pen pen = new Pen(GetRandomColor(), 2);
            grp.DrawPolygon(pen, points);
        }

        public Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public PointF[] S(PointF[] p)
        {
            PointF[] M = new PointF[p.Length];
            for (int i = 0; i < p.Length - 1; i++)
            {
                M[i].X = (p[i].X + p[i + 1].X) / 2;
                M[i].Y = (p[i].Y + p[i + 1].Y) / 2;
            }
            M[p.Length - 1].X = (p[p.Length - 1].X + p[0].X) / 2;
            M[p.Length - 1].Y = (p[p.Length - 1].Y + p[0].Y) / 2;
            return M;
        }

        public float Aria(PointF[] p)
        {
            float s = 0;
            for (int i = 0; i < p.Length - 1; i++)
                s += 0.5f * (p[i].X * p[i + 1].Y - p[i + 1].X * p[i].Y);
            s += 0.5f * (p[p.Length - 1].X * p[0].Y - p[0].X * p[p.Length - 1].Y);
            return Math.Abs(s);
        }

        public void Rec()
        {
            if (Aria(points) > 1)
            {
                DrawMap(points);
                points = S(points);
                Rec();
            }
        }

        public PointF CG(PointF[] points)
        {
            float x = 0, y = 0;
            for (int i = 0; i < points.Length; i++)
            {
                x += points[i].X;
                y += points[i].Y;
            }
            return new PointF(x / points.Length, y / points.Length);
        }
    }
}

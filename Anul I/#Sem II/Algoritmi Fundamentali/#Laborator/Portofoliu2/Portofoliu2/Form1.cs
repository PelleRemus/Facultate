using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portofoliu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
        }

        Bitmap bmp;
        Graphics grp;
        static Random r = new Random();
        Pen whitePen = new Pen(Color.White, 2);
        Pen blackPen = new Pen(Color.Black, 2);
        int y;

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            y = r.Next(pictureBox1.Height / 3);
            Point p1 = new Point(r.Next(pictureBox1.Width / 3), y);
            Point p2 = new Point(r.Next(2 * pictureBox1.Width / 3, pictureBox1.Width), y);
            Cantor(p1, p2);
            pictureBox1.Image = bmp;
        }

        private void Cantor(Point p1, Point p2)
        {
            if (p2.X - p1.X > 2)
            {
                y += 20;
                p1.Y = y; p2.Y = y;
                grp.DrawLine(blackPen, p1, p2);
                Point _p1 = new Point(p1.X + (p2.X - p1.X) / 3, p1.Y);
                Point _p2 = new Point(p2.X - (p2.X - p1.X) / 3, p2.Y);
                grp.DrawLine(whitePen, _p1, _p2);
                int x = y;
                Cantor(p1, _p1);
                y = x;
                Cantor(_p2, p2);
            }
            pictureBox1.Image = bmp;
        }

        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            y = pictureBox1.Height - 20;
            count = 0;
            PointF a = new PointF(r.Next(pictureBox1.Width / 3), y);
            PointF b = new PointF(r.Next(2 * pictureBox1.Width / 3, pictureBox1.Width), y);
            grp.DrawLine(blackPen, a, b);
            Koch(a, b);
            pictureBox1.Image = bmp;
        }

        private void Koch(PointF a, PointF b)
        {
            count++;
            float l = (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
            if (l > 10)
            {
                float Panta = -(b.Y - a.Y) / (b.X - a.X);
                float fi = -(float)Math.Atan(Panta);
                fi -= (float)Math.PI / 3;
                if (count >= 3) fi += (float)Math.PI;
                PointF c = new PointF(a.X + l * (float)Math.Cos(fi), a.Y + l * (float)Math.Sin(fi));
                grp.DrawLine(blackPen, a, c);
                grp.DrawLine(blackPen, b, c);
                PointF a1, b1, a2, b2;
                a1 = new PointF(a.X + l * (float)Math.Cos(fi) / 3, a.Y + l * (float)Math.Sin(fi) / 3);
                b1 = new PointF(a.X + 2 * l * (float)Math.Cos(fi) / 3, a.Y + 2 * l * (float)Math.Sin(fi) / 3);
                grp.DrawLine(whitePen, a1, b1);
                //grp.DrawLine(whitePen, a2, b2);
                Koch(a1, b1);
                //Koch(a2, b2);
            }
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            y = pictureBox1.Height - 20;
            PointF[] points = new PointF[3];
            points[0] = new PointF(r.Next(pictureBox1.Width / 3), y);
            points[1] = new PointF(r.Next(2 * pictureBox1.Width / 3, pictureBox1.Width), y);
            float l = (float)Math.Sqrt(3) * (points[1].X - points[0].X) / 2;
            points[2] = new PointF((points[1].X + points[0].X) / 2, y - l);
            grp.FillPolygon(new SolidBrush(Color.Black), points);
            Sierpinski(points);
            pictureBox1.Image = bmp;
        }

        private void Sierpinski(PointF[] points)
        {
            if (points[1].X - points[0].X > 15)
            {
                PointF a = points[0]; PointF b = points[1]; PointF c = points[2];
                points[0] = new PointF((b.X + c.X) / 2, (b.Y + c.Y) / 2);
                points[1] = new PointF((a.X + c.X) / 2, (a.Y + c.Y) / 2);
                points[2] = new PointF((a.X + b.X) / 2, (a.Y + b.Y) / 2);
                grp.FillPolygon(new SolidBrush(Color.White), points);
                Sierpinski(new PointF[] { a, points[2], points[1] });
                Sierpinski(new PointF[] { points[2], b, points[0] });
                Sierpinski(new PointF[] { points[1], points[0], c });
            }
            pictureBox1.Image = bmp;
        }
    }
}

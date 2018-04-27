using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickHull11
{

    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bmp;
        private List<Point> points;
        private List<Point> hull;
        private List<int> name;
        private int x = 0;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            points = new List<Point>();
            hull = new List<Point>();
            name = new List<int>();
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            if (e.Button == MouseButtons.Left)
            {
                x++;
                name.Add(x);
                points.Add(new Point(e.X, e.Y));
                graphics.DrawEllipse(pen, e.X-1, e.Y-1, 3, 3);
                graphics.DrawString(" " + x, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));
                pictureBox1.Invalidate();
                if(points.Count >= 3)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
        }

        private int Side(Point p1, Point p2, Point p)
        {
            int val = (p.Y - p1.Y) * (p2.X - p1.X) - (p2.Y - p1.Y) * (p.X - p1.X);
            if (val > 0) return 1;
            if (val < 0) return -1;
            return 0;
        }

        private int Distance(Point p1, Point p2, Point p)
        {
            return Math.Abs((p.Y - p1.Y) * (p2.X - p1.X) - (p2.Y - p1.Y) * (p.X - p1.X));
        }

        private void QuickHull()
        {
            if (points.Count <= 3)
            {
                foreach(var p in points)
                    hull.Add(p);
                return;
            }
                
            Point pmin = points
                .Select(p => new { point = p, x = p.X })
                .Aggregate((p1, p2) => p1.x < p2.x ? p1 : p2).point;
            Point pmax = points
                .Select(p => new { point = p, x = p.X })
                .Aggregate((p1, p2) => p1.x > p2.x ? p1 : p2).point;

            hull.Add(pmin);
            hull.Add(pmax);
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();

            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                if (Side(pmin, pmax, p) == 1)
                    left.Add(p);
                else if (Side(pmin, pmax, p) == -1)
                    right.Add(p);
            }

            float panta = -(pmin.Y - pmax.Y) / (pmax.X - pmin.X);
            Point pmaxLeft = left[0];
            for(int i = 1; i < left.Count; i++)
                if (Distance(pmin, pmax, left[i]) > Distance(pmin, pmax, pmaxLeft))
                    pmaxLeft = left[i];
            for (int i = 0; i < left.Count; i++)
            {
                PointF M = PunctMediatoare(left[i], pmin, pmax);
                graphics.DrawLine(Pens.Aqua, left[i].X, left[i].Y, M.X, M.Y);
            }

            Point pmaxRight = right[0];
            for (int i = 1; i < right.Count; i++)
                if (Distance(pmin, pmax, right[i]) > Distance(pmin, pmax, pmaxRight))
                    pmaxRight = right[i];
            for (int i = 0; i < right.Count; i++)
            {
                PointF M = PunctMediatoare(right[i], pmin, pmax);
                graphics.DrawLine(Pens.Aqua, right[i].X, right[i].Y, M.X, M.Y);
            }

            graphics.DrawLine(new Pen(Color.Aqua, 2), pmin, pmax);
            pictureBox1.Image = bmp;
            System.Threading.Thread.Sleep(500);
            CreateHull(pmin, pmax, left);
            CreateHull(pmax, pmin, right);
        }

        private void CreateHull(Point a, Point b, List<Point> points)
        {
            int pos = hull.IndexOf(b);
            if (points.Count == 0)
                return;
            if (points.Count == 1)
            {
                Point pp = points[0];
                hull.Insert(pos, pp);
                return;
            }

            int dist = int.MinValue;
            int point = 0;
            for (int i = 0; i < points.Count; i++)
            {
                Point pp = points[i];
                int distance = Distance(a, b, pp);
                if (distance > dist)
                {
                    dist = distance;
                    point = i;
                }
            }

            Point p = points[point];
            hull.Insert(pos, p);
            List<Point> ap = new List<Point>();
            List<Point> pb = new List<Point>();
            for (int i = 0; i < points.Count; i++)
            {
                Point pp = points[i];
                if (Side(a, p, pp) == 1)
                    ap.Add(pp);
            }
           
            for (int i = 0; i < points.Count; i++)
            {
                Point pp = points[i];
                if (Side(p, b, pp) == 1)
                    pb.Add(pp);
            }
            CreateHull(a, p, ap);
            CreateHull(p, b, pb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Red, 2);
            QuickHull();
            graphics.DrawPolygon(pen, hull.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            points.Clear();
            name.Clear();
            x = 0;
            hull.Clear();
            pictureBox1.Image = bmp;
        }

        public PointF PunctMediatoare(PointF A, PointF B, PointF C)
        {
            float Panta = -(B.Y - C.Y) / (C.X - B.X);
            float Ms = (C.X - B.X) - (B.Y - C.Y) * Panta;
            float Mx = (A.X + Panta * A.Y) * (C.X - B.X) - Panta * (B.Y * C.X - B.X * C.Y);
            float My = (B.Y * C.X - B.X * C.Y) - (A.X + Panta * A.Y) * (B.Y - C.Y);
            PointF M = new PointF(Mx / Ms, My / Ms);
            return M;
        }
    }
}

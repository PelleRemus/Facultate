using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurbeBezier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        List<PointF> points = new List<PointF>();

        Bitmap bmp;
        Graphics grp;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(new PointF(e.X, e.Y));
            DrawSketch();
            
            if (points.Count > 2)
            {
                for (float i = 0; i <= 1000; i++)
                {
                    PointF p = Bezier(points, i / 1000);
                    grp.FillEllipse(new SolidBrush(Color.Blue), p.X - 1, p.Y - 1, 3, 3);
                }
            }
            pictureBox1.Image = bmp;
        }

        void DrawSketch()
        {
            grp.Clear(Color.White);
            foreach (PointF p in points)
                grp.FillEllipse(new SolidBrush(Color.Red), p.X - 3, p.Y - 3, 7, 7);

            for (int j = 1; j < points.Count; j++)
                for (float i = 0; i < 100; i++)
                {
                    PointF p = Bezier(new List<PointF>() { points[j - 1], points[j] }, i / 100);
                    grp.DrawEllipse(Pens.Gray, p.X, p.Y, 1, 1);
                }
        }

        PointF Bezier(List<PointF> p, float t)
        {
            if (p.Count == 2)
                return new PointF((1 - t) * p[0].X + t * p[1].X, (1 - t) * p[0].Y + t * p[1].Y);
        
            List<PointF> left = new List<PointF>();
            left.AddRange(p); left.Remove(p[p.Count - 1]);
            List<PointF> right = new List<PointF>();
            right.AddRange(p); right.Remove(p[0]);

            PointF p1 = Bezier(left, t), p2 = Bezier(right, t);
            return new PointF((1 - t) * p1.X + t * p2.X, (1 - t) * p1.Y + t * p2.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            grp.Clear(Color.White);
            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galerii_de_arta
{
    class Punct
    {
        public float x, y;
        public Color culoare;
        public Punct(PointF p, Color c)
        {
            x = p.X; y = p.Y; culoare = c;
        }
    }

    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        private List<PointF> points;
        private List<int> name;
        int x = 0;
        Pen blackPen = new Pen(Color.Black, 2);
        Pen redPen = new Pen(Color.Red, 2);


        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            points = new List<PointF>();
            name = new List<int>();
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x++;
                name.Add(x);
                points.Add(new Point(e.X, e.Y));
                grp.DrawEllipse(blackPen, e.X - 2, e.Y - 2, 5, 5);
                grp.DrawString(" " + x, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));
                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count - 1; i++)
                grp.DrawLine(blackPen, points[i], points[i + 1]);
            grp.DrawLine(blackPen, points[points.Count - 1], points[0]);
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pen bluePen = new Pen(Color.Blue);
            bluePen.DashPattern = new float[] { 5, 3.5f };
            List<PointF> puncteIntermediare = new List<PointF>();
            puncteIntermediare.Add(points[0]);
            puncteIntermediare.Add(points[1]);
            for (int i=2; i<points.Count; i++)
            {
                puncteIntermediare.Add(points[i]);
                float det = Determinant(puncteIntermediare[puncteIntermediare.Count - 1], puncteIntermediare[puncteIntermediare.Count - 3], puncteIntermediare[puncteIntermediare.Count-2]);
                while (det > 0)
                {
                    grp.DrawLine(bluePen, puncteIntermediare[puncteIntermediare.Count - 3], puncteIntermediare[puncteIntermediare.Count - 1]);
                    pictureBox1.Refresh();
                    puncteIntermediare.RemoveAt(puncteIntermediare.Count - 2);
                    if (puncteIntermediare.Count < 3)
                        break;
                    det = Determinant(puncteIntermediare[puncteIntermediare.Count - 1], puncteIntermediare[puncteIntermediare.Count - 3], puncteIntermediare[puncteIntermediare.Count - 2]);
                }
                pictureBox1.Refresh();
            }
            pictureBox1.Image = bmp;
        }

        private float Determinant(PointF p1, PointF p2, PointF p3)
        {
            return (((p1.X * p2.Y) + (p2.X * p3.Y) + (p1.Y * p3.X)) - ((p3.X * p2.Y) + (p3.Y * p1.X) + (p2.X * p1.Y)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int redCount = 0, blueCount = 0, greenCount = 0;
            Punct[] puncteColorate = new Punct[points.Count];
            for (int i=0; i<points.Count; i++)
                puncteColorate[i] = new Punct(points[i], Color.White);
            puncteColorate[0].culoare = Color.Red; redCount++;
            puncteColorate[1].culoare = Color.Blue; blueCount++;
            for (int i=2; i<points.Count; i++)

        }
    }
}

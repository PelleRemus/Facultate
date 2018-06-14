using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmul_lui_Graham
{
    public partial class Form1 : Form
    {
        Point[] p = new Point[100];
        int n = 0, index;
        int[] finalPoint;
        double[] angle;
        Graphics grp;
        Pen redPen = new Pen(Color.Red, 2);
        Pen whitePen = new Pen(Color.White, 2);

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            grp = pictureBox1.CreateGraphics();
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            p[n] = new Point(e.X, e.Y);
            grp.DrawEllipse(redPen, e.X - 1, e.Y - 1, 3, 3);
            n++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindSmallestY();
            Angle();
            SortAngle();
            ConvexHull();
        }

        private void FindSmallestY()
        {
            float min = p[0].Y;
            int index = 0;
            for (int i = 1; i < n; i++)
                if (min < p[i].Y)
                {
                    min = p[i].Y;
                    index = i;
                }
            this.index = index;
        }

        private void Angle()
        {
            angle = new double[n];
            double k = 0;
            for (int i = 0; i < n; i++)
            {
                Point P = p[index];
                if (!(p[i].X == P.X && p[i].Y == P.Y))
                {
                    Point _P = new Point(p[i].X - P.X, p[i].Y - P.Y);
                    k = Check(_P.X, _P.Y);
                }
                angle[i] = k;
            }
        }

        private double Check(double x, double y)
        {
            double k = Math.Atan(Math.Abs(x / y)) * 180 / Math.PI;
            if (x < 0)
                k = 180 - k;
            return k;
        }

        private void SortAngle()
        {
            for (int i = n - 1; i >= 0; i--)
                for (int j = 1; j <= i; j++)
                    if (angle[j - 1] > angle[j])
                    {
                        double aux = angle[j - 1];
                        angle[j - 1] = angle[j];
                        angle[j] = aux;

                        Point Aux = p[j - 1];
                        p[j - 1] = p[j];
                        p[j] = Aux;
                    }
        }

        private bool ccw(int a, int b, int c)
        {
            if (p[a].X * (p[b].Y - p[c].Y) + p[b].X * (p[c].Y - p[a].Y) + p[c].X * (p[a].Y - p[b].Y) >= 0)
                return true;
            return false;
        }

        private void ConvexHull()
        {
            int a = 0, b = 1, c = 2;
            finalPoint = new int[n];
            finalPoint[a] = 1; finalPoint[b] = 1;
            grp.DrawLine(redPen, p[0], p[1]);

            while(true)
            {
                if (ccw(b, a, c) && c == n - 1)
                {
                    finalPoint[c] = 1;
                    grp.DrawLine(redPen, p[b], p[c]);
                    grp.DrawLine(redPen,p[c], p[0]);
                    break;
                }

                if (ccw(b, a, c))
                {
                    grp.DrawLine(redPen, p[b], p[c]);
                    finalPoint[c] = 1;
                    a = b;
                    b = c;
                    c++;
                }

                if (!ccw(b, a, c))
                {
                    grp.DrawLine(redPen, p[b], p[c]);
                    grp.DrawLine(whitePen, p[b], p[c]);
                    grp.DrawLine(whitePen, p[a], p[b]);
                    finalPoint[b] = 0;
                    b = a;
                    a = theTestBefore(a);
                }
            }
        }

        private int theTestBefore(int l)
        {
            int i;
            for (i = l - 1; i > 0; i--)
                if (finalPoint[i] == 1)
                    break;
            return i;
        }
    }
}

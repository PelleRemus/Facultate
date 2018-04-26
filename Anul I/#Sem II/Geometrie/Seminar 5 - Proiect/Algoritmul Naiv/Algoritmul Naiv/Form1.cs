using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmul_Naiv
{
    public partial class Form1 : Form
    {
        private PointF[] points = new PointF[100];
        private int n = 0;
        private Graphics grp;
        private int[] pointName = new int[100];
        Pen redPen = new Pen(Color.Red);
        Pen WhitePen = new Pen(Color.White, 2);

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            grp = pictureBox1.CreateGraphics();
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    for (int k = 0; k < n; k++)
                    {
                        if (i == k || j == k) continue;
                        grp.DrawLine(redPen, points[i].X, points[i].Y, points[j].X, points[j].Y);
                        System.Threading.Thread.Sleep(100);
                        if (ccw(i, j, k))
                        {
                            grp.DrawLine(WhitePen, points[i].X, points[i].Y, points[j].X, points[j].Y);
                            System.Threading.Thread.Sleep(100);
                            break;
                        }
                    }
            grp.DrawLine(redPen, points[0].X, points[0].Y, points[n - 1].X, points[n - 1].Y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            points[n].X = e.X;
            points[n].Y = e.Y;

            grp.DrawEllipse(redPen, e.X - 1, e.Y - 1, 3, 3);
            grp.DrawString(" " + (n + 1), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));

            pointName[n] = n + 1;
            n++;
        }

        private bool ccw(int a, int b, int c)
        {
            if (points[a].X * (points[b].Y - points[c].Y) + points[b].X * (points[c].Y - points[a].Y) + points[c].X * (points[a].Y - points[b].Y) >= 0) 
                return true;
            else
                return false;
        }
    }
}

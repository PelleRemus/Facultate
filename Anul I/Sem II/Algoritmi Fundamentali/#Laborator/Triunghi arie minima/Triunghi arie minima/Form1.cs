using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triunghi_arie_minima
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        int n;
        PointF[] points;
        Random r = new Random();
        Pen pen = new Pen(Color.Black);
        
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = 10;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            points = new PointF[n];
            for(int i = 0; i < n; i++)
            {
                points[i] = GenerateRandomPoint();
                grp.DrawEllipse(Pens.Black, points[i].X-2, points[i].Y-2, 5, 5);
            }
            int[] sol = new int[4];
            bool[] b = new bool[n];
            int[] minCurent = new int[4];
            minCurent[1] = 0;minCurent[2] = 1;minCurent[3] = 2;
            Back(1, n, 3, sol, b, minCurent);

            PointF[] trg = new PointF[3];
            trg[0] = points[minCurent[1]];
            trg[1] = points[minCurent[2]];
            trg[2] = points[minCurent[3]];

            grp.DrawPolygon(pen,trg);
            pictureBox1.Image = bmp;
        }

        private void Back(int k, int n, int p, int[] sol, bool[] b, int[] minCurent)
        {
            if (k > p)
            {
                PointF minA = points[minCurent[1]];
                PointF minB = points[minCurent[2]];
                PointF minC = points[minCurent[3]];

                PointF A = points[sol[1]];
                PointF B = points[sol[2]];
                PointF C = points[sol[3]];

                if(Aria(minA,minB,minC) > Aria(A,B,C))
                    for(int i = 1; i <= p; i++)
                        minCurent[i] = sol[i];
            }
            else
            {
                for(int i = sol[k - 1]; i < n; i++)
                {
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Back(k + 1, n, p, sol, b, minCurent);
                        b[i] = false;
                    }
                }
            }
        }

        private PointF GenerateRandomPoint()
        {
            return new PointF(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
        }

        float Aria(PointF a, PointF b, PointF c)
        {
            return Math.Abs(a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y))/2;
        }
    }
}

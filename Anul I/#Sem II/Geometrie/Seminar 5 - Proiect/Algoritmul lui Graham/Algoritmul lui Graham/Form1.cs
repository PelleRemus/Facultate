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
        int[] pointsX = new int[100];
        int[] pointsY = new int[100];
        int n = 0, index;
        int[] finalPoint;
        double[] angle;
        int[] pointName = new int[100];
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
            pointsX[n] = e.X;
            pointsY[n] = e.Y;

            grp.DrawEllipse(redPen, e.X - 1, e.Y - 1, 3, 3);
            grp.DrawString(" " + (n + 1), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));

            pointName[n] = n + 1;
            n++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindSmallestY();
            Angle();
            SortAngle();
            ConvexHull();

            string final = "" + pointName[0];
            for (int i = 1; i < n; i++)
                if (finalPoint[i] == 1)
                    final = final + ", " + pointName[i];
            richTextBox1.Text += "Convex Hull's Points Are \n (" + final + ")";
        }

        private void FindSmallestY()
        {
            float min = pointsY[0];
            int index = 0;
            for (int i = 1; i < n; i++)
                if (min < pointsY[i])
                {
                    min = pointsY[i];
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
                double pointX = pointsX[index];
                double pointY = pointsY[index];
                if (!(pointsX[i] == pointX && pointsY[i] == pointY))
                {
                    double _pointX = pointsX[i] - pointX;
                    double _pointY = pointsY[i] - pointY;
                    k = Check(_pointX, _pointY);
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

                        int Aux = pointsX[j - 1];
                        pointsX[j - 1] = pointsX[j];
                        pointsX[j] = Aux;

                        aux = pointsY[j - 1];
                        pointsY[j - 1] = pointsY[j];
                        pointsY[j] = Aux;

                        Aux = pointName[j - 1];
                        pointName[j - 1] = pointName[j];
                        pointName[j] = Aux;
                    }
        }

        private bool ccw(int a, int b, int c)
        {
            if (pointsX[a] * (pointsY[b] - pointsY[c]) + pointsX[b] * (pointsY[c] - pointsY[a]) + pointsX[c] * (pointsY[a] - pointsY[b]) >= 0)
                return true;
            else
                return false;
        }

        private void ConvexHull()
        {
            int a = 0, b = 1, c = 2;
            finalPoint = new int[n];
            finalPoint[a] = 1; finalPoint[b] = 1;
            grp.DrawLine(redPen, new Point(pointsX[0], pointsY[0]), new Point(pointsX[1], pointsY[1]));

            while(true)
            {
                System.Threading.Thread.Sleep(500);
                if (ccw(b, a, c) && c == n - 1)
                {
                    finalPoint[c] = 1;
                    grp.DrawLine(redPen, new Point(pointsX[b], pointsY[b]), new Point(pointsX[c], pointsX[c]));
                    System.Threading.Thread.Sleep(500);
                    grp.DrawLine(redPen, new Point(pointsX[c], pointsY[c]), new Point(pointsX[0], pointsY[0]));

                    richTextBox1.Text += "   This is the Convex Hull\n";
                    break;
                }

                if (ccw(b, a, c))
                {
                    richTextBox1.Text += "LEFT TURN Between The points (" + pointName[a] + ", " + pointName[b] + ", " + pointName[c] + ")\n";
                    grp.DrawLine(redPen, new Point(pointsX[b], pointsY[b]), new Point(pointsX[c], pointsY[c]));
                    System.Threading.Thread.Sleep(500);
                    finalPoint[c] = 1;
                    a = b;
                    b = c;
                    c++;
                }

                if (!ccw(b, a, c))
                {
                    richTextBox1.Text += "RIGHT TURN Between The points (" + pointName[a] + ", " + pointName[b] + ", " + pointName[c] + ")\n";
                    grp.DrawLine(redPen, new Point(pointsX[b], pointsY[b]), new Point(pointsX[c], pointsY[c]));
                    System.Threading.Thread.Sleep(500);

                    grp.DrawLine(whitePen, new Point(pointsX[b], pointsY[b]), new Point(pointsX[c], pointsY[c]));
                    grp.DrawString(" " + pointName[b], new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(pointsX[b] + 5, pointsY[b] + 5));

                    grp.DrawLine(whitePen, new Point(pointsX[a], pointsY[a]), new Point(pointsX[b], pointsY[b]));
                    grp.DrawString(" " + pointName[a], new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(pointsX[a] + 5, pointsY[a] + 5));

                    grp.DrawEllipse(redPen, pointsX[b], pointsY[b], 2, 2);
                    grp.DrawEllipse(redPen, pointsX[a], pointsY[a], 2, 2);
                    grp.DrawEllipse(redPen, pointsX[c], pointsY[c], 2, 2);
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

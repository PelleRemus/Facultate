using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidpointAlgorythm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            Point p1 = new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
            Point p2 = new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
            grp.FillEllipse(new SolidBrush(Color.Blue), p1.X - 4, p1.Y - 4, 9, 9);
            grp.FillEllipse(new SolidBrush(Color.Red), p2.X - 4, p2.Y - 4, 9, 9);

            if (p2.X < p1.X)
            {
                Point p = new Point(p1.X, p1.Y);
                p1 = new Point(p2.X, p2.Y);
                p2 = p;
            }
            if (p2.X - p1.X >= Math.Abs(p2.Y - p1.Y))
            {
                int sign = 1;
                if (p2.Y < p1.Y)
                    sign = -1;
                MidpointLineX(p1, p2, sign);
            }
            else
            {
                if (p2.Y < p1.Y)
                {
                    Point p = new Point(p1.X, p1.Y);
                    p1 = new Point(p2.X, p2.Y);
                    p2 = p;
                }
                int sign = 1;
                if (p2.X < p1.X)
                    sign = -1;
                MidpointLineY(p1, p2, sign);
            }
            pictureBox1.Image = bmp;
        }

        void MidpointLineX(Point p1, Point p2, int sign)
        {
            int dx = p2.X - p1.X, dy = Math.Abs(p2.Y - p1.Y);
            int d = 2 * dy - dx;
            int incrE = 2 * dy, incrNE = 2 * (dy - dx);
            int x = p1.X, y = p1.Y;
            grp.DrawEllipse(Pens.Black, x, y, 1, 1);

            while (x < p2.X)
            {
                if (d < 0)
                    d += incrE;
                else
                {
                    d += incrNE;
                    y += sign;
                }
                x++;
                grp.DrawEllipse(Pens.Black, x, y, 1, 1);
            }
        }

        void MidpointLineY(Point p1, Point p2, int sign)
        {
            int dx = Math.Abs(p2.X - p1.X), dy = p2.Y - p1.Y;
            int d = 2 * dy - dx;
            int incrE = 2 * dx, incrNE = 2 * (dx - dy);
            int x = p1.X, y = p1.Y;
            grp.DrawEllipse(Pens.Black, x, y, 1, 1);

            while (y < p2.Y)
            {
                if (d < 0)
                    d += incrE;
                else
                {
                    d += incrNE;
                    x += sign;
                }
                y++;
                grp.DrawEllipse(Pens.Black, x, y, 1, 1);
            }
        }
    }
}

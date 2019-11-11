using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerc
{
    public static class Engine
    {
        public static PictureBox display;
        public static Point center;
        public static Graphics grp;
        public static Bitmap bmp;
        public static Pen sketch = new Pen(Color.LightGray, 2);
        public static Color[] colors = new Color[] { Color.HotPink, Color.Red, Color.Yellow, Color.Orange, Color.Green, Color.Blue, Color.Gray, Color.Purple };
        public static int r = 100, n = 45, k = 0;
        public static double theta = Math.PI / (4*n);
        public static PointF[] points;

        public static int x, y, dE, dSE;
        public static double d;

        public static void Init(PictureBox p)
        {
            display = p;
            DrawSketch(new Point(p.Width / 2, p.Height / 2));
            points = new PointF[8];
            InitValues();
        }
        public static void InitValues()
        {
            x = 0; y = r;
            dE = 3; dSE = 5 - 2 * y;
            d = 1 - r;
        }

        public static void DrawSketch(Point newCenter)
        {
            center = newCenter;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            grp.DrawLine(sketch, 0, center.Y, display.Width, center.Y);
            grp.DrawLine(sketch, center.X, 0, center.X, display.Height);
            grp.DrawEllipse(sketch, center.X - r, center.Y - r, 2 * r, 2 * r);
            display.Image = bmp;
        }

        public static void Step()
        {
            /*if (k <= n)
            {
                for (int l = r; l > 0; l--)
                {
                    float x = l * (float)Math.Cos(theta * k);
                    float y = l * (float)Math.Sin(theta * k);
                    points[0] = new PointF(center.X + x, center.Y + y);
                    points[1] = new PointF(center.X + y, center.Y + x);
                    points[2] = new PointF(center.X - x, center.Y + y);
                    points[3] = new PointF(center.X - y, center.Y + x);
                    points[4] = new PointF(center.X - x, center.Y - y);
                    points[5] = new PointF(center.X - y, center.Y - x);
                    points[6] = new PointF(center.X + x, center.Y - y);
                    points[7] = new PointF(center.X + y, center.Y - x);

                    for (int i = 0; i < 8; i++)
                        grp.DrawEllipse(new Pen(colors[i], 2), points[i].X, points[i].Y, 1, 1);
                }
                display.Image = bmp;
                k++;
            }*/

            if (x <= y)
            {
                points[0] = new PointF(center.X + y, center.Y + x);
                points[1] = new PointF(center.X + x, center.Y + y);
                points[2] = new PointF(center.X - y, center.Y + x);
                points[3] = new PointF(center.X - x, center.Y + y);
                points[4] = new PointF(center.X - y, center.Y - x);
                points[5] = new PointF(center.X - x, center.Y - y);
                points[6] = new PointF(center.X + y, center.Y - x);
                points[7] = new PointF(center.X + x, center.Y - y);

                for (int i = 0; i < 8; i++)
                    grp.DrawEllipse(new Pen(colors[i]), points[i].X, points[i].Y, 1, 1);
                display.Image = bmp;

                if (d < 0)
                {
                    d += dE;
                    dE += 2;
                    dSE += 2;
                }
                else
                {
                    d += dSE;
                    dE += 2;
                    dSE += 4;
                    y--;
                }
                x++;
            }
            else if (r > 0)
            {
                r--;
                InitValues();
                Step();
            }
        }
    }
}

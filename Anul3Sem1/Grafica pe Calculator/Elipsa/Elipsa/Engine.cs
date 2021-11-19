using System.Drawing;
using System.Windows.Forms;

namespace Elipsa
{
    public static class Engine
    {
        public static PictureBox display;
        public static Point center;
        public static Graphics grp;
        public static Bitmap bmp;
        public static Pen sketch = new Pen(Color.LightGray, 2);
        public static Color[] colors = new Color[] { Color.Red, Color.Yellow, Color.Green, Color.Blue };
        public static int r1 = 100, r2 = 80;
        public static PointF[] points;

        public static int x, y, d, dx, dy;

        public static void Init(PictureBox p)
        {
            display = p;
            InitValues();
            DrawSketch(new Point(p.Width / 2, p.Height / 2));
            points = new PointF[4];
        }
        public static void InitValues()
        {
            x = 0;
            y = r2;
            d = r2 * r2 - r1 * r1 * r2 + r1 * r1 / 4;
            dx = 2 * r2 * r2 * x;
            dy = 2 * r1 * r1 * y;
        }

        public static void DrawSketch(Point newCenter)
        {
            center = newCenter;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            grp.DrawLine(sketch, 0, center.Y, display.Width, center.Y);
            grp.DrawLine(sketch, center.X, 0, center.X, display.Height);
            grp.DrawEllipse(sketch, center.X - (int)r1, center.Y - (int)r2, 2 * (int)r1, 2 * (int)r2);
            display.Image = bmp;
        }

        public static void Step()
        {
            if (x <= r1 && y >= 0)
            {
                points[0] = new PointF(center.X + x, center.Y + y);
                points[1] = new PointF(center.X - x, center.Y + y);
                points[2] = new PointF(center.X - x, center.Y - y);
                points[3] = new PointF(center.X + x, center.Y - y);

                for (int i = 0; i < 4; i++)
                    grp.DrawEllipse(new Pen(colors[i]), points[i].X, points[i].Y, 1, 1);
                display.Image = bmp;
                
                x++;
                dx += 2 * r2 * r2;
                d += dx + r2 * r2;

                if (d > 0)
                {
                    y--;
                    dy -= 2 * r1 * r1;
                    d -= dy;
                }
                if (d > 0)
                {
                    x--;
                    dx -= 2 * r2 * r2;
                    d -= dx + r2 * r2;
                }
            }
            else if (r1 > 0 && r2 > 0)
            {
                r1--; r2--;
                InitValues();
                Step();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ceas_Digital
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static int resx, resy;
        public static PictureBox pB;
        public static Color color = Color.Gold;
        public static Pen silverPen = new Pen(Color.Silver, 5);
        public static int R;
        public static float alpha;
        public static float fi = (float)(Math.PI * 3) / 2;
        public static int minute = 0;
        public static int ora = 0;

        public static void Init(PictureBox P)
        {
            pB = P;
            resx = P.Width;
            resy = P.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            grp.Clear(color);
            pB.Image = bmp;
        }

        public static void DrawMap()
        {
            R = (resx - 20) / 2;
            grp.FillEllipse(new SolidBrush(Color.AliceBlue), resx / 2 - R, resy / 2 - R, 2 * R, 2 * R);
            grp.DrawEllipse(silverPen, resx / 2 - R, resy / 2 - R, 2 * R, 2 * R);
            alpha = (float)Math.PI * 2 / 12;
            for( int i=0; i<12; i++)
            {
                float x = resx / 2 + (R - 40) * (float)Math.Cos(i * alpha + fi);
                float y = resy / 2 + (R - 40) * (float)Math.Sin(i * alpha + fi);
                float _x = resx / 2 + (R - 10) * (float)Math.Cos(i * alpha + fi);
                float _y = resy / 2 + (R - 10) * (float)Math.Sin(i * alpha + fi);
                grp.DrawLine(new Pen(Color.Gold, 5), _x, _y, x, y);
            }

            float m = (float)(Math.PI * 2) / 60;
            float xm = resx / 2 + (R - 20) * (float)Math.Cos(m * minute + fi);
            float ym = resy / 2 + (R - 20) * (float)Math.Sin(m * minute + fi);
            grp.DrawLine(silverPen, resx / 2, resy / 2, xm, ym);

            float gamma = (float)(Math.PI * 2) / (12 * 60);
            float o = (float)(Math.PI * 2) / 12;
            float xo = resx / 2 + (R - 70) * (float)Math.Cos(o * ora + fi + gamma * minute);
            float yo = resy / 2 + (R - 70) * (float)Math.Sin(o * ora + fi + gamma * minute);
            grp.DrawLine(silverPen, resx / 2, resy / 2, xo, yo);

            grp.FillEllipse(new SolidBrush(Color.Gold), resx / 2 - 25, resy / 2 - 25, 50, 50);
            pB.Image = bmp;
        }
    }
}

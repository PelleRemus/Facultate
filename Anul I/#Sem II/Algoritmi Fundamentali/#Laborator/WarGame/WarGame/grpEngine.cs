using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WarGame
{
    public static partial class Engine
    {
        public static PictureBox display;
        public static int resX, resY;
        public static Bitmap bmp;
        public static Graphics grp;
        public static Color backColor = Color.White;

        public static void InitGraf()
        {
            resX = display.Width;
            resY = display.Height;
            bmp = new Bitmap(resX, resY);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backColor);
            display.Image = bmp;
        }

        public static PointF GetRandomPoint()
        {
            return new PointF(r.Next(resX - 100), r.Next(resY - 100));
        }

        public static void DrawMap()
        {
            foreach(Unit u in army1)
            {
                u.Draw();
            }
            foreach (Unit u in army2)
            {
                u.Draw();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Drone
{
    public static partial class Engine
    {
        public static PictureBox display;
        public static int resx, resy;
        public static int dw, dh;
        public static Bitmap bmp;
        public static Graphics grp;
        public static Color backColor;

        public static void initGraph(PictureBox p)
        {
            display = p;
            resx = p.Width;
            resy = p.Height;
            dw = resx / n;
            dh = resy / m;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            backColor = Color.FromArgb(200, 200, 200);

            clearGraph();
            refreshGraph();
        }

        public static void DrawMap()
        {
            for(int i=0; i<n; i++)
                for(int j=0; j<m; j++)
                    map[i, j].Draw();
            refreshGraph();
        }

        public static void clearGraph()
        {
            grp.Clear(backColor);
        }

        public static void refreshGraph()
        {
            display.Image = bmp;
        }
    }
}

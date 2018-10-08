using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Joc
{
    public static class Engine
    {
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;

        public static void Init(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
        }
    }
}

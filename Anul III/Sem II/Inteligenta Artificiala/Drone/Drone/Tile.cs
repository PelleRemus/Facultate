using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class Tile
    {
        public int value;
        public int i, j;

        public Tile(int v, int i, int j)
        {
            value = v;
            this.i = i;
            this.j = j;
        }

        public void Draw()
        {
            Engine.grp.DrawRectangle(Pens.Black, i * Engine.dw, j * Engine.dh,
                Engine.dw, Engine.dh);
            if (value != 0)
                Engine.grp.DrawString(value.ToString(), new Font("Arial", 15, FontStyle.Regular),
                    new SolidBrush(Color.Green), new PointF(i * Engine.dw + 5, j * Engine.dh + 5));
        }
    }
}

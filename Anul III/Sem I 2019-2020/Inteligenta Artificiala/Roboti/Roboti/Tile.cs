using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public class Tile
    {
        public int i, j;

        public Tile(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public void DrawTile()
        {
            if (Engine.map[i, j] != 0)
                Engine.grp.DrawString(Engine.map[i, j].ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), i * Engine.length, j * Engine.length);
            if (Engine.map[i, j] == -1)
            {
                Engine.grp.FillRectangle(new SolidBrush(Color.Brown), i * Engine.length, j * Engine.length, Engine.length, Engine.length);
            }
            Engine.grp.DrawRectangle(Pens.Black, i * Engine.length, j * Engine.length, Engine.length, Engine.length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioGame
{
    internal class Fireball
    {
        internal PictureBox fire;
        internal static bool left, right;
        internal bool currentLeft, currentRight;
        internal int force;

        internal Fireball(Point p)
        {
            fire = new PictureBox();
            fire.Parent = Engine.form;
            fire.Size = new Size(Engine.x/2, Engine.x/2);
            fire.Left = p.X; fire.Top = p.Y;
            fire.Tag = "fireball";
            fire.BackColor = Color.OrangeRed;

            force = 0;
            if(left)
            {
                currentLeft = true;
                currentRight = false;
            }
            else
            {
                currentRight = true;
                currentLeft = false;
            }
        }

        internal void Disappear()
        {
            fire.Parent = null;
            fire.Top = 14 * Engine.x;
        }
    }
}

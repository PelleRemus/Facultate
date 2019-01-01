using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal class Bonus
    {
        internal PictureBox bonus;
        internal bool left, right;
        internal int force;

        internal Bonus(Point p, string s)
        {
            bonus = new PictureBox();
            bonus.Parent = Engine.form;
            bonus.Size = new Size(Engine.x, Engine.x);
            bonus.Left = p.X; bonus.Top = p.Y;
            bonus.Tag = "bonus";
            bonus.Name = s;
            force = 0;
            switch (s)
            {
                case "mushroom":
                    {
                        bonus.BackColor = Color.Orange;
                        right = true;
                        break;
                    }
                case "flower":
                    {
                        bonus.BackColor = Color.Wheat;
                        break;
                    }
                case "star":
                    {
                        bonus.BackColor = Color.LightYellow;
                        right = true;
                        force = Mario.jumpspeed;
                        break;
                    }
                case "oneUp":
                    {
                        bonus.BackColor = Color.LawnGreen;
                        right = true;
                        break;
                    }
            }
        }

        internal void Disappear()
        {
            bonus.Parent = null;
            bonus.Top = 14 * Engine.x;
        }
    }
}

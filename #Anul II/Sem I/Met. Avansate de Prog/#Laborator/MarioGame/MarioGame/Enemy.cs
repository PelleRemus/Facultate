using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal class Enemy
    {
        internal PictureBox enemy;
        internal bool left, right;
        internal int force;

        internal Enemy(Point p, string s)
        {
            enemy = new PictureBox();
            enemy.Parent = Engine.form;
            enemy.Size = new Size(Engine.x, Engine.x);
            enemy.Left = p.X; enemy.Top = p.Y;
            enemy.Tag = "enemy";
            enemy.Name = s;
            switch(s)
            {
                case "goomba":
                    {
                        enemy.BackColor = Color.Red;
                        break;
                    }
                case "turtle":
                    {
                        enemy.BackColor = Color.Black;
                        break;
                    }
            }
            left = true;
            force = 0;
        }

        internal void Die()
        {
            enemy.Parent = null;
            enemy.Top = 14 * Engine.x;
        }
    }
}

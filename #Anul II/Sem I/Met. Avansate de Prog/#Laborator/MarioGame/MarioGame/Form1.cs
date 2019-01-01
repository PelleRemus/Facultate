using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AutoScroll = true;
            Engine.InitGame(this, label1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                Mario.left = true;
                Fireball.left = true;
                Fireball.right = false;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                Mario.right = true;
                Fireball.right = true;
                Fireball.left = false;
            }

            if (!Mario.jump && (e.KeyCode == Keys.Up || e.KeyCode == Keys.W))
            {
                Mario.jump = true;
                Mario.force = Mario.jumpspeed;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                Mario.crouch = true;
                if (Mario.upgrade != 0)
                {
                    Mario.mario.Size = new Size(Engine.x, Engine.x);
                    Mario.mario.Top += Engine.x;
                }
            }

            if (Mario.upgrade == 2 && e.KeyCode == Keys.Space)
            {
                Fireball f = new Fireball(new Point(Mario.mario.Left, Mario.mario.Bottom - Engine.x));
                Resources.fireballs.Add(f);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                Mario.left = false;

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                Mario.right = false;

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                Mario.crouch = false;
                if (Mario.upgrade != 0)
                {
                    Mario.mario.Size = new Size(Engine.x, Engine.x * 2);
                    Mario.mario.Top -= Engine.x;
                }
            }
        }
    }
}

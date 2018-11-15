using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    public static class Mario
    {
        public static bool alive;
        public static bool left, right, jump;
        public static int speed, jumpspeed, force;
        public static PictureBox mario;
        public static Timer t;

        public static void Init()
        {
            mario = new PictureBox();
            mario.Parent = Engine.form;
            speed = 9; jumpspeed = 18;
            alive = true;
            left = false; right = false;

            mario.Size = new Size(Engine.x, Engine.x);
            mario.Left = 7 * Engine.x; mario.Top = 11 * Engine.x;
            mario.BackColor = Color.Green;
            mario.Tag = "mario";

            t = new Timer();
            t.Interval = 1;
            t.Tick += t_Tick;
            t.Start();
        }

        private static void t_Tick(object sender, EventArgs e)
        {
            Engine.Check();
            //
            // go left & right
            //
            if (left)
            {
                Engine.v -= speed;
                if (Engine.v < 0)
                    Engine.v = 0;
                else
                    mario.Left -= speed;
                Engine.form.HorizontalScroll.Value = Engine.v;
            }
            if (right)
            {
                mario.Left += speed;
                Engine.v += speed;
                Engine.form.HorizontalScroll.Value = Engine.v;
            }

            //
            // gravity
            //
            mario.Top -= force;
            force -= 1;
            if (force < -jumpspeed)
                force = -jumpspeed;
            Engine.Check();

            if (mario.Top >= 13 * Engine.x)
                Lose();

            Engine.EnemyCheck();
        }

        public static void Win()
        {
            t.Stop();
            MessageBox.Show("You Won!");
        }
        public static void Lose()
        {
            t.Stop();
            MessageBox.Show("You Lost!");
        }
    }
}

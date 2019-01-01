using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal static class Mario
    {
        internal static bool alive, invincible;
        internal static int upgrade, invincibleTime;
        internal static bool left, right, jump, crouch;
        internal static int speed, jumpspeed, force;
        internal static PictureBox mario;
        internal static Timer t;

        internal static void Init()
        {
            mario = new PictureBox();
            mario.Parent = Engine.form;
            speed = 9; jumpspeed = 18;
            alive = true; invincible = false;
            upgrade = 0; invincibleTime = 0;
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

        static void t_Tick(object sender, EventArgs e)
        {
            Engine.MarioCollisions();
            Engine.MarioMovements();
            Engine.MarioCollisions();
            if (mario.Top >= 13 * Engine.x)
                Lose();

            if (invincibleTime == 0)
            {
                invincible = false;
                if (upgrade == 2)
                    mario.BackColor = Color.White;
                else
                    mario.BackColor = Color.Green;
            }
            else
                invincibleTime--;

            Engine.EnemyCollisions();
            Engine.EnemyMovements();
            Engine.EnemyCollisions();

            if (Resources.levelOneBonuses.Count != 0)
            {
                Engine.BonusCollisions();
                Engine.BonusMovements();
                Engine.BonusCollisions();
            }

            if(Resources.fireballs.Count!=0)
            {
                Engine.FirballCollisions();
                Engine.FireballMovements();
                Engine.FirballCollisions();
            }
        }

        internal static void Win()
        {
            t.Stop();
            MessageBox.Show("You Won!");
        }
        internal static void Lose()
        {
            t.Stop();
            MessageBox.Show("You Lost!");
        }

        internal static void GotHit()
        {
            upgrade = 0;
            mario.Size = new Size(Engine.x, Engine.x);
            mario.Top += Engine.x;
            mario.BackColor = Color.FromArgb(150, Color.Green);
            invincible = true;
            invincibleTime = 100;
        }
    }
}

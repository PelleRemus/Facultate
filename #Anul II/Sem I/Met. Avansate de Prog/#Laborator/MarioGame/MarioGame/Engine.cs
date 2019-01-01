using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal static class Engine
    {
        internal static Form form;
        internal static Label label;
        internal static int x, v = 0, coins = 0;

        internal static void InitGame(Form f, Label l)
        {
            form = f;
            label = l;
            x = form.Height / 14;
            Resources.Init();
            Mario.Init();
        }

        #region Collisions
        static bool BottomCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Bottom <= pB2.Top + Mario.jumpspeed)
                return true;
            return false;
        }

        static bool TopCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Top >= pB2.Bottom - Mario.jumpspeed)
                return true;
            return false;
        }

        static bool RightCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Right > pB2.Left && pB1.Left < pB2.Left
                && pB1.Bottom > pB2.Top && pB1.Top < pB2.Bottom)
                return true;
            return false;
        }

        static bool LeftCollision(PictureBox pB1, PictureBox pB2)
        {
            if (pB1.Left < pB2.Right && pB1.Right > pB2.Right
                && pB1.Bottom > pB2.Top && pB1.Top < pB2.Bottom)
                return true;
            return false;
        }
        #endregion

        #region HelperFunctions
        static void QuestionMarkIsHit(Control c)
        {
            string bonusType = c.Name.Split(' ')[1];
            if (Mario.upgrade > 0 && bonusType == "mushroom")
                bonusType = "flower";

            switch (bonusType)
            {
                case "mushroom":
                    {
                        Bonus temp = Resources.getBonus(bonus.mushroom, new Point(c.Left, c.Top - x));
                        Resources.levelOneBonuses.Add(temp);
                        break;
                    }
                case "flower":
                    {
                        Bonus temp = Resources.getBonus(bonus.flower, new Point(c.Left, c.Top - x));
                        Resources.levelOneBonuses.Add(temp);
                        break;
                    }
                case "star":
                    {
                        Bonus temp = Resources.getBonus(bonus.star, new Point(c.Left, c.Top - x));
                        Resources.levelOneBonuses.Add(temp);
                        break;
                    }
                case "oneUp":
                    {
                        Bonus temp = Resources.getBonus(bonus.oneUp, new Point(c.Left, c.Top - x));
                        Resources.levelOneBonuses.Add(temp);
                        break;
                    }
            }

            c.Name = "disabledQ";
            c.Visible = true;
            c.BackColor = Color.Brown;

            coins++;
            label.Text = coins.ToString();
        }

        static void BrickIsHit(Control c)
        {
            if (Mario.upgrade > 0)
            {
                c.Parent = null;
                c.Top = 14 * x;
                c.Dispose();
            }

            /*Enemy deadEnemy = null;
            foreach (Enemy en in Resources.levelOneEnemies)
            {
                if (c.Bounds.IntersectsWith(en.enemy.Bounds))
                {
                    en.enemy.Parent = null;
                    en.enemy.Top = 14 * x;
                    deadEnemy = en;
                }
            }
            if (deadEnemy != null)
                Resources.levelOneEnemies.Remove(deadEnemy);

            foreach (Bonus bonus in Resources.levelOneBonuses)
                if (c.Bounds.IntersectsWith(bonus.bonus.Bounds))
                {
                    bonus.jump = true;
                    bonus.force = 8;
                }
            */
        }
        #endregion

        internal static void MarioCollisions()
        {
            foreach(Control c in form.Controls)
            {
                if (c is PictureBox && c.Tag == "block" && Math.Abs((c as PictureBox).Left - Mario.mario.Left) <= 18 * x)
                    if (Mario.mario.Bounds.IntersectsWith(c.Bounds))
                    {
                        if (BottomCollision(Mario.mario, c as PictureBox))
                        {
                            if (Mario.upgrade == 0 || Mario.crouch)
                                Mario.mario.Top = c.Top - x;
                            else
                                Mario.mario.Top = c.Top - 2 * x;
                            Mario.jump = false;
                            Mario.force = 0;
                        }
                        
                        if (TopCollision(Mario.mario, c as PictureBox))
                        {
                            Mario.mario.Top = c.Bottom;
                            Mario.force = 0;

                            if (c.Name.Split(' ')[0] == "questionMark")
                                QuestionMarkIsHit(c);

                            if (c.Name == "brick")
                                BrickIsHit(c);
                        }
                        
                        if (RightCollision(Mario.mario, c as PictureBox))
                        {
                            Mario.right = false;
                            Mario.mario.Left = c.Left - x;
                        }
                        
                        if (LeftCollision(Mario.mario, c as PictureBox))
                        {
                            Mario.left = false;
                            Mario.mario.Left = c.Right;
                        }
                        
                        if (c.Name == "flag")
                            Mario.Win();
                }
            }
        }

        internal static void MarioMovements()
        {
            if (Mario.left)
            {
                if (!(Mario.crouch && !Mario.jump))
                {
                    v -= Mario.speed;
                    if (v < 0)
                        v = 0;
                    else
                    {
                        Mario.mario.Left -= Mario.speed;
                        label.Left -= Mario.speed;
                        form.HorizontalScroll.Value = v;
                    }
                }
            }

            if (Mario.right)
            {
                if (!(Mario.crouch && !Mario.jump))
                {
                    Mario.mario.Left += Mario.speed;
                    label.Left += Mario.speed;
                    v += Mario.speed;
                    form.HorizontalScroll.Value = v;
                }
            }

            // gravity
            Mario.mario.Top -= Mario.force;
            Mario.force -= 1;
            if (Mario.force < -Mario.jumpspeed)
                Mario.force = -Mario.jumpspeed;
        }

        internal static void EnemyCollisions()
        {
            Enemy deadEnemy = null;

            foreach (Enemy en in Resources.levelOneEnemies)
                if (Math.Abs(en.enemy.Left - Mario.mario.Left) <= 18 * x)
                {
                    foreach (Control c in form.Controls)
                    {
                        if (c is PictureBox && c.Tag == "block" && Math.Abs((c as PictureBox).Left - Mario.mario.Left) <= 20 * x)
                            if (en.enemy.Bounds.IntersectsWith(c.Bounds))
                            {
                                if (BottomCollision(en.enemy, c as PictureBox))
                                {
                                    en.enemy.Top = c.Top - x;
                                    en.force = 0;
                                }
                                
                                if (RightCollision(en.enemy, c as PictureBox))
                                {
                                    en.right = false;
                                    en.enemy.Left = c.Left - x;
                                    en.left = true;
                                }
                                
                                if (LeftCollision(en.enemy, c as PictureBox))
                                {
                                    en.left = false;
                                    en.enemy.Left = c.Right;
                                    en.right = true;
                                }
                            }
                    }
                    if (Mario.mario.Bounds.IntersectsWith(en.enemy.Bounds))
                    {
                        if (BottomCollision(Mario.mario, en.enemy))
                        {
                            Mario.jump = true;
                            Mario.force = 8;
                            en.Die();
                            deadEnemy = en;
                        }
                        else
                        {
                            if (!Mario.invincible)
                            {
                                if (Mario.upgrade == 0)
                                    Mario.Lose();
                                else
                                    Mario.GotHit();
                            }
                        }
                    }
                }

            if (deadEnemy != null)
                Resources.levelOneEnemies.Remove(deadEnemy);
        }

        internal static void EnemyMovements()
        {
            Enemy fallenEnemy = null;

            foreach (Enemy en in Resources.levelOneEnemies)
                if (Math.Abs(en.enemy.Left - Mario.mario.Left) <= 18 * x)
                {
                    if (en.left)
                        en.enemy.Left -= 3;
                    else
                        en.enemy.Left += 3;

                    en.enemy.Top -= en.force;
                    en.force -= 1;
                    if (en.force < -Mario.jumpspeed)
                        en.force = -Mario.jumpspeed;
                    if (en.enemy.Top >= 14 * x)
                    {
                        en.enemy.Parent = null;
                        fallenEnemy = en;
                    }
                }

            if (fallenEnemy != null)
                Resources.levelOneEnemies.Remove(fallenEnemy);
        }

        internal static void BonusCollisions()
        {
            Bonus collectedBonus = null;

            foreach (Bonus bonus in Resources.levelOneBonuses)
            {
                foreach (Control c in form.Controls)
                {
                    if (c is PictureBox && c.Tag == "block" && Math.Abs((c as PictureBox).Left - Mario.mario.Left) <= 20 * x)
                        if (bonus.bonus.Bounds.IntersectsWith(c.Bounds))
                        {
                            if (BottomCollision(bonus.bonus, c as PictureBox))
                            {
                                bonus.bonus.Top = c.Top - x;
                                if (bonus.bonus.Name == "star")
                                    bonus.force = Mario.jumpspeed;
                                else
                                    bonus.force = 0;
                            }

                            if (TopCollision(bonus.bonus, c as PictureBox))
                            {
                                bonus.bonus.Top = c.Bottom;
                                bonus.force = 0;
                            }
                            
                            if (RightCollision(bonus.bonus, c as PictureBox))
                            {
                                bonus.right = false;
                                bonus.bonus.Left = c.Left - x;
                                bonus.left = true;
                            }
                            
                            if (LeftCollision(bonus.bonus, c as PictureBox))
                            {
                                bonus.left = false;
                                bonus.bonus.Left = c.Right;
                                bonus.right = true;
                            }
                        }
                }
                if (Mario.mario.Bounds.IntersectsWith(bonus.bonus.Bounds))
                {
                    switch (bonus.bonus.Name)
                    {
                        case "mushroom":
                            {
                                Mario.upgrade = 1;
                                Mario.mario.Size = new Size(x, 2 * x);
                                Mario.mario.Top -= x;
                                break;
                            }
                        case "flower":
                            {
                                Mario.upgrade++;
                                if (Mario.upgrade == 1)
                                {
                                    Mario.mario.Size = new Size(x, 2 * x);
                                    Mario.mario.Top -= x;
                                }
                                else
                                {
                                    Mario.upgrade = 2;
                                    if (Mario.invincible)
                                        Mario.mario.BackColor = Color.FromArgb(150, Color.White);
                                    else
                                        Mario.mario.BackColor = Color.White;
                                }
                                break;
                            }
                        case "star":
                            {
                                if (!Mario.invincible)
                                {
                                    Mario.invincible = true;
                                    Mario.mario.BackColor = Color.FromArgb(150, Mario.mario.BackColor);
                                }
                                Mario.invincibleTime = 500;
                                break;
                            }
                        case "oneUp":
                            {
                                break;
                            }
                    }
                    bonus.Disappear();
                    collectedBonus = bonus;
                }
            }

            if (collectedBonus != null)
                Resources.levelOneBonuses.Remove(collectedBonus);
        }

        internal static void BonusMovements()
        {
            Bonus lostBonus = null;

            foreach (Bonus bonus in Resources.levelOneBonuses)
            {
                if (Math.Abs(bonus.bonus.Left - Mario.mario.Left) <= 18 * x)
                {
                    if (bonus.left)
                        bonus.bonus.Left -= 3;
                    if (bonus.right)
                        bonus.bonus.Left += 3;
                }
                else
                {
                    bonus.Disappear();
                    lostBonus = bonus;
                }

                bonus.bonus.Top -= bonus.force;
                bonus.force -= 1;
                if (bonus.force < -Mario.jumpspeed)
                    bonus.force = -Mario.jumpspeed;
            }

            if (lostBonus != null)
                Resources.levelOneBonuses.Remove(lostBonus);
        }

        internal static void FirballCollisions()
        {
            Fireball usedFireball = null;

            foreach (Fireball f in Resources.fireballs)
            {
                foreach (Control c in form.Controls)
                    if (c is PictureBox && c.Tag == "block" && Math.Abs((c as PictureBox).Left - Mario.mario.Left) <= 20 * x)
                        if (f.fire.Bounds.IntersectsWith(c.Bounds))
                        {
                            if (BottomCollision(f.fire, c as PictureBox))
                            {
                                f.fire.Top = c.Top - x / 3;
                                f.force = 9;
                            }
                            else
                            {
                                f.Disappear();
                                usedFireball = f;
                            }
                        }

                Enemy deadEnemy = null;
                foreach (Enemy en in Resources.levelOneEnemies)
                    if (Math.Abs(en.enemy.Left - Mario.mario.Left) <= 20 * x)
                        if (f.fire.Bounds.IntersectsWith(en.enemy.Bounds))
                        {
                            en.Die();
                            deadEnemy = en;
                            f.Disappear();
                            usedFireball = f;
                        }
                if (deadEnemy != null)
                    Resources.levelOneEnemies.Remove(deadEnemy);
            }

            if (usedFireball != null)
                Resources.fireballs.Remove(usedFireball);
        }

        internal static void FireballMovements()
        {
            Fireball lostFireball = null;

            foreach (Fireball f in Resources.fireballs)
            {
                if (Math.Abs(f.fire.Left - Mario.mario.Left) <= 18 * x)
                {
                    if (f.currentLeft)
                        f.fire.Left -= 12;
                    else
                        f.fire.Left += 12;
                }
                else
                {
                    f.Disappear();
                    lostFireball = f;
                }

                f.fire.Top -= f.force;
                f.force -= 1;
                if (f.force < -Mario.jumpspeed)
                    f.force = -Mario.jumpspeed;
            }

            if (lostFireball != null)
                Resources.fireballs.Remove(lostFireball);
        }
    }
}

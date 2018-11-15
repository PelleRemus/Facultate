using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal static class Engine
    {
        internal static Form form;
        internal static int x, v = 0;
        internal static Block[,] b;
        internal static int[,] levelOne;
        internal static Enemy[] levelOneEnemies;

        internal static void InitGame(Form f)
        {
            form = f;
            x = form.Height / 14;
            
            b = new Block[212, 14];
            levelOne = new int[212, 14];
            levelOneEnemies = new Enemy[17];
            SettingTheBlocks();
            Mario.Init();
        }

        internal static MyAttribute getAtribute(blocks b)
        {
            return (MyAttribute)Attribute.GetCustomAttribute(
                typeof(blocks).GetField(Enum.GetName(typeof(blocks), b)),
                typeof(MyAttribute));
        }
        internal static Block getBlock(blocks b, Point p)
        {
            MyAttribute local = getAtribute(b);
            Block r = new Block(p, local.tag);
            return r;
        }

        internal static MyAttribute getAtribute(enemies en)
        {
            return (MyAttribute)Attribute.GetCustomAttribute(
                typeof(enemies).GetField(Enum.GetName(typeof(enemies), en)),
                typeof(MyAttribute));
        }
        internal static Enemy getEnemy(enemies en, Point p)
        {
            MyAttribute local = getAtribute(en);
            Enemy r = new Enemy(p, local.tag);
            return r;
        }

        internal static void Check()
        {
            foreach(Control c in form.Controls)
            {
                if(c is PictureBox && c.Tag == "block")
                    if (Mario.mario.Bounds.IntersectsWith(c.Bounds))
                    {
                        //
                        // top collision
                        //
                        if (Mario.mario.Top <= c.Top - x + Mario.jumpspeed)
                        {
                            Mario.mario.Top = c.Top - x;
                            Mario.jump = false;
                            Mario.force = 0;
                        }
                        //
                        // bottom collision
                        //
                        if (Mario.mario.Top >= c.Top + x - Mario.jumpspeed)
                        {
                            Mario.mario.Top = c.Top + x;
                            Mario.force = 0;
                            if(c.Name == "questionMark")
                            {
                                c.Name = "disabledQ";
                                c.BackColor = Color.Brown;
                            }
                        }
                        //
                        // right collision
                        //
                        if (Mario.mario.Right > c.Left
                            && Mario.mario.Left < c.Left
                            && Mario.mario.Bottom > c.Top
                            && Mario.mario.Top < c.Bottom)
                        {
                            Mario.right = false;
                            Mario.mario.Left = c.Left - x;
                        }
                        //
                        // left collision
                        //
                        if (Mario.mario.Left < c.Right
                            && Mario.mario.Right > c.Right
                            && Mario.mario.Bottom > c.Top
                            && Mario.mario.Top < c.Bottom)
                        {
                            Mario.left = false;
                            Mario.mario.Left = c.Right;
                        }
                        //
                        // You win
                        //
                        if (c.Name == "flag")
                            Mario.Win();
                }
            }
        }

        internal static void EnemyCheck()
        {
            for (int i = 0; i < 17; i++)
            {
                Enemy en = levelOneEnemies[i];
                if (en != null)
                {
                    foreach (Control c in form.Controls)
                    {
                        if (c is PictureBox && c.Tag == "block")
                            if (en.enemy.Bounds.IntersectsWith(c.Bounds))
                            {
                                //
                                // right collision
                                //
                                if (en.enemy.Right > c.Left
                                    && en.enemy.Left < c.Left
                                    && en.enemy.Bottom > c.Top
                                    && en.enemy.Top < c.Bottom)
                                {
                                    en.right = false;
                                    en.enemy.Left = c.Left - x;
                                    en.left = true;
                                }
                                //
                                // left collision
                                //
                                if (en.enemy.Left < c.Right
                                    && en.enemy.Right > c.Right
                                    && en.enemy.Bottom > c.Top
                                    && en.enemy.Top < c.Bottom)
                                {
                                    en.left = false;
                                    en.enemy.Left = c.Right;
                                    en.right = true;
                                }
                            }
                    }
                    if (en.enemy.Left - Mario.mario.Left <= 17 * x)
                    {
                        if (en.left == true)
                            en.enemy.Left -= 2;
                        else
                            en.enemy.Left += 2;
                    }
                    if (Mario.mario.Bounds.IntersectsWith(en.enemy.Bounds))
                    {
                        if (Mario.mario.Top <= en.enemy.Top - x + Mario.jumpspeed)
                        {
                            Mario.jump = true;
                            Mario.force = 8;
                            en.enemy.Parent = null;
                            en.enemy.Top = 14 * x;
                            en = null;
                        }
                        else
                            Mario.Lose();
                    }
                }
            }
        }

        static void SettingTheBlocks()
        {
            //
            // land
            //
            for(int i=0; i<212; i++)
            {
                if (i == 70 || i == 71 || i == 87 || i == 88 || i == 89 || i == 153 || i == 154)
                    continue;
                levelOne[i, 12] = 1;
                levelOne[i, 13] = 1;
            }

            //
            // brick
            //
            levelOne[20, 8] = 2; levelOne[22, 8] = 2; levelOne[24, 8] = 2;
            levelOne[77, 8] = 2; levelOne[79, 8] = 2;
            for (int i = 80; i < 88; i++)
                levelOne[i, 4] = 2;
            levelOne[91, 4] = 2; levelOne[92, 4] = 2; levelOne[93, 4] = 2;
            levelOne[100, 8] = 2;
            levelOne[118, 8] = 2;
            levelOne[121, 4] = 2; levelOne[122, 4] = 2; levelOne[123, 4] = 2;
            levelOne[128, 4] = 2; levelOne[129, 8] = 2; levelOne[130, 8] = 2; levelOne[131, 4] = 2;
            levelOne[168, 8] = 2; levelOne[169, 8] = 2; levelOne[171, 8] = 2;

            //
            // questionMark
            //
            levelOne[16, 8] = 3; levelOne[21, 8] = 3; levelOne[23, 8] = 3; levelOne[22, 4] = 3;
            levelOne[78, 8] = 3;
            levelOne[94, 4] = 3; levelOne[94, 8] = 3;
            levelOne[101, 8] = 3;
            levelOne[106, 8] = 3; levelOne[109, 8] = 3; levelOne[112, 8] = 3; levelOne[109, 4] = 3;
            levelOne[129, 4] = 3; levelOne[130, 4] = 3;
            levelOne[170, 8] = 3;

            //
            // disabledQ
            //
            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    levelOne[134 + j, 11 - i] = 4;
                    levelOne[143 - j, 11 - i] = 4;
                    levelOne[148 + j, 11 - i] = 4;
                    levelOne[158 - j, 11 - i] = 4;
                }
                levelOne[152, 11 - i] = 4;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = i; j < 8; j++)
                    levelOne[181 + j, 11 - i] = 4;
                levelOne[189, 11 - i] = 4;
            }
            levelOne[198, 11] = 4;

            //
            // pipe
            //
            levelOne[28, 11] = 5; levelOne[28, 10] = 5; levelOne[29, 11] = 5; levelOne[29, 10] = 5;
            for(int i=9; i<12; i++)
            {
                levelOne[38, i] = 5; levelOne[39, i] = 5;
            }
            for (int i = 8; i < 12; i++)
            {
                levelOne[46, i] = 5; levelOne[47, i] = 5;
                levelOne[57, i] = 5; levelOne[58, i] = 5;
            }
            levelOne[163, 11] = 5; levelOne[163, 10] = 5; levelOne[164, 11] = 5; levelOne[164, 10] = 5;
            levelOne[179, 11] = 5; levelOne[179, 10] = 5; levelOne[180, 11] = 5; levelOne[180, 10] = 5;

            //
            // flag
            //
            for (int i = 2; i < 11; i++)
                levelOne[198, i] = 6;

            //
            //set them blocks
            //
            for (int i = 0; i < 212; i++)
                for (int j = 0; j < 14; j++)
                    if (levelOne[i, j] != 0)
                        switch(levelOne[i,j])
                        {
                            case 1:
                                {
                                    b[i, j] = getBlock(blocks.land, new Point(i * x, j * x));
                                    break;
                                }
                            case 2:
                                {
                                    b[i, j] = getBlock(blocks.brick, new Point(i * x, j * x));
                                    break;
                                }
                            case 3:
                                {
                                    b[i, j] = getBlock(blocks.questionMark, new Point(i * x, j * x));
                                    break;
                                }
                            case 4:
                                {
                                    b[i, j] = getBlock(blocks.disabledQ, new Point(i * x, j * x));
                                    break;
                                }
                            case 5:
                                {
                                    b[i, j] = getBlock(blocks.pipe, new Point(i * x, j * x));
                                    break;
                                }
                            case 6:
                                {
                                    b[i, j] = getBlock(blocks.flag, new Point(i * x, j * x));
                                    break;
                                }
                        }

            levelOneEnemies[0] = getEnemy(enemies.goomba, new Point(22 * x, 11 * x));
            levelOneEnemies[1] = getEnemy(enemies.goomba, new Point(40 * x, 11 * x));
            levelOneEnemies[2] = getEnemy(enemies.goomba, new Point(51 * x, 11 * x));
            levelOneEnemies[3] = getEnemy(enemies.goomba, new Point(52 * x, 11 * x));
            levelOneEnemies[4] = getEnemy(enemies.goomba, new Point(80 * x, 3 * x));
            levelOneEnemies[5] = getEnemy(enemies.goomba, new Point(80 * x, 3 * x));
            levelOneEnemies[6] = getEnemy(enemies.goomba, new Point(97 * x, 11 * x));
            levelOneEnemies[7] = getEnemy(enemies.goomba, new Point(99 * x, 11 * x));
            levelOneEnemies[8] = getEnemy(enemies.turtle, new Point(107 * x, 11 * x));
            levelOneEnemies[9] = getEnemy(enemies.goomba, new Point(114 * x, 11 * x));
            levelOneEnemies[10] = getEnemy(enemies.goomba, new Point(115 * x, 11 * x));
            levelOneEnemies[11] = getEnemy(enemies.goomba, new Point(123 * x, 11 * x));
            levelOneEnemies[12] = getEnemy(enemies.goomba, new Point(125 * x, 11 * x));
            levelOneEnemies[13] = getEnemy(enemies.goomba, new Point(127 * x, 11 * x));
            levelOneEnemies[14] = getEnemy(enemies.goomba, new Point(129 * x, 11 * x));
            levelOneEnemies[15] = getEnemy(enemies.goomba, new Point(175 * x, 11 * x));
            levelOneEnemies[16] = getEnemy(enemies.goomba, new Point(176 * x, 11 * x));
        }
    }
}

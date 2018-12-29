using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace MineSweeper
{
    internal static class Resources
    {
        internal static int[,] matrix;
        internal static Block[,] blocks;
        internal static int n, m;
        internal static int mines, percent = 7;

        internal static Image defaultImage = Image.FromFile(@"../../Images/Default.jpg");
        internal static Image visitedImage = Image.FromFile(@"../../Images/Visited.jpg");
        internal static Image flaggedImage = Image.FromFile(@"../../Images/Flagged.png");
        internal static Image[] explodingImages = new Image[]
        {
            Image.FromFile(@"../../Images/Mine.jpg"),
            Image.FromFile(@"../../Images/Exploding1.jpg"),
            Image.FromFile(@"../../Images/Exploding2.jpg"),
            Image.FromFile(@"../../Images/Exploding3.jpg"),
            Image.FromFile(@"../../Images/Exploding4.jpg"),
        };

        internal static void InitGame()
        {
            n = Engine.display.Width / (Engine.x + 3);
            m = Engine.display.Height / (Engine.x + 3);
            blocks = new Block[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    blocks[i, j] = new Block(i, j);
        }

        internal static void Restart()
        {
            Engine.visited = new bool[n, m];
            Engine.flagged = new bool[n, m];
            Engine.display.Enabled = true;
            matrix = new int[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    blocks[i, j].Image = defaultImage;
        }

        internal static void GetBlocksValues()
        {
            mines = n * m / percent;
            for (int k = 0; k < mines; k++)
            {
                bool ok = true;
                while (ok)
                {
                    int i = Engine.rnd.Next(n);
                    int j = Engine.rnd.Next(m);
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, j] = 9;
                        ok = false;
                    }
                }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int counter = 0;
                    if (matrix[i, j] == 9)
                        continue;
                    for (int k = i - 1; k <= i + 1; k++)
                        for (int l = j - 1; l <= j + 1; l++)
                            if (k >= 0 && k < n && l >= 0 && l < m)
                                if (matrix[k, l] == 9)
                                    counter++;
                    matrix[i, j] = counter;
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    switch (matrix[i, j])
                    {
                        case 0: blocks[i, j].value = ""; break;
                        case 1: blocks[i, j].value = "1"; blocks[i, j].ForeColor = Color.FromArgb(20, 100, 200); break;
                        case 2: blocks[i, j].value = "2"; blocks[i, j].ForeColor = Color.Green; break;
                        case 3: blocks[i, j].value = "3"; blocks[i, j].ForeColor = Color.Red; break;
                        case 4: blocks[i, j].value = "4"; blocks[i, j].ForeColor = Color.DarkBlue; break;
                        case 5: blocks[i, j].value = "5"; blocks[i, j].ForeColor = Color.DarkRed; break;
                        case 6: blocks[i, j].value = "6"; blocks[i, j].ForeColor = Color.DarkTurquoise; break;
                        case 7: blocks[i, j].value = "7"; blocks[i, j].ForeColor = Color.Black; break;
                        case 8: blocks[i, j].value = "8"; blocks[i, j].ForeColor = Color.Black; break;
                        case 9: blocks[i, j].value = ""; break;
                    }
        }

        internal static void Show(int i, int j)
        {
            if (matrix[i, j] == 9)
            {
                blocks[i, j].Image = explodingImages[0];
            }
            else
            {
                Bitmap bmp = new Bitmap(blocks[i, j].Image);
                Graphics grp = Graphics.FromImage(bmp);
                grp.DrawString(blocks[i, j].value, blocks[i, j].Font, new SolidBrush(blocks[i, j].ForeColor), 2, 0);
                blocks[i, j].Image = bmp;
            }
        }

        internal static void Explodes(int k, int l)
        {
            int x = 0;
            while (x < n || x < m)
            {
                List<Block> mines = new List<Block>();
                for (int i = 0; i < 2 * x + 1; i++)
                {
                    if (k - x >= 0 && l - x + i >= 0 && l - x + i < m && matrix[k - x, l - x + i] == 9)
                        mines.Add(blocks[k - x, l - x + i]);
                    if (k - x + i >= 0 && k - x + i < n && l + x < m && matrix[k - x + i, l + x] == 9)
                        mines.Add(blocks[k - x + i, l + x]);
                    if (k + x < n && l + x - i >= 0 && l + x - i < m && matrix[k + x, l + x - i] == 9)
                        mines.Add(blocks[k + x, l + x - i]);
                    if (k + x - i >= 0 && k + x - i < n && l - x >= 0 && matrix[k + x - i, l - x] == 9)
                        mines.Add(blocks[k + x - i, l - x]);
                }

                if (mines.Count != 0)
                    for (int i = 1; i <= 4; i++)
                    {
                        foreach (Block mine in mines)
                            mine.Image = explodingImages[i];
                        Thread.Sleep(70);
                        Engine.form.Update();
                    }
                x++;
            }

        }
    }
}

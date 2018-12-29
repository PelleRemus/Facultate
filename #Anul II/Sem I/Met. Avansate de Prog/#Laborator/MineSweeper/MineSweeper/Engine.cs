using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    internal static class Engine
    {
        internal static Form form;
        internal static PictureBox display;
        internal static Label diff;
        internal static bool[,] visited, flagged;
        internal static bool wantsNewGame;
        internal static int x = 22;
        internal static Random rnd = new Random();

        internal static void InitGame(Form f, PictureBox p, Label l)
        {
            form = f;
            display = p;
            diff = l;
            wantsNewGame = false;
            p.Enabled = false;
            Resources.InitGame();
            visited = new bool[Resources.n, Resources.m];
            flagged = new bool[Resources.n, Resources.m];
        }

        internal static void StartNewGame()
        {
            if (wantsNewGame)
            {
                Resources.Restart();
                Resources.GetBlocksValues();
                wantsNewGame = false;
            }
        }

        internal static void Block_MouseHover(object sender, EventArgs e)
        {
            int i = (sender as Block).line;
            int j = (sender as Block).col;

            if (!visited[i, j])
            {
                Bitmap bmp = new Bitmap(Resources.blocks[i, j].Image);
                Graphics grp = Graphics.FromImage(bmp);
                grp.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.White)), 0, 0, x, x);
                Resources.blocks[i, j].Image = bmp;
            }
        }

        internal static void Block_MouseLeave(object sender, EventArgs e)
        {
            int i = (sender as Block).line;
            int j = (sender as Block).col;

            if (!visited[i, j])
            {
                if (flagged[i, j])
                    Resources.blocks[i, j].Image = Resources.flaggedImage;
                else
                    Resources.blocks[i, j].Image = Resources.defaultImage;
            }
        }

        internal static void Block_MouseClick(object sender, MouseEventArgs e)
        {
            int i = (sender as Block).line;
            int j = (sender as Block).col;
            
            if (e.Button == MouseButtons.Left)
            {
                if (!flagged[i, j])
                {
                    if (Resources.matrix[i, j] == 9)
                        GameOver(i, j);
                    else
                        Parcurgere(i, j);
                }
            }
            else
            {
                if (!visited[i, j])
                {
                    if (flagged[i, j])
                    {
                        Resources.blocks[i, j].Image = Resources.defaultImage;
                        flagged[i, j] = false;
                    }
                    else
                    {
                        Resources.blocks[i, j].Image = Resources.flaggedImage;
                        flagged[i, j] = true;
                    }
                }
            }
            Check();
        }

        static void Parcurgere(int i, int j)
        {
            if (i >= 0 && i < Resources.n && j >= 0 && j < Resources.m && visited[i, j] == false)
            {
                visited[i, j] = true;
                Resources.blocks[i, j].Image = Resources.visitedImage;
                if (Resources.blocks[i, j].value == "")
                {
                    Parcurgere(i - 1, j);
                    Parcurgere(i, j + 1);
                    Parcurgere(i + 1, j);
                    Parcurgere(i, j - 1);
                }
                else
                    Resources.Show(i, j);
            }
        }

        static void GameOver(int k, int l)
        {
            for (int i = 0; i < Resources.n; i++)
                for (int j = 0; j < Resources.m; j++)
                    Resources.Show(i, j);
            display.Enabled = false;
            Resources.Explodes(k, l);
        }

        static void Check()
        {
            bool ok = true;

            for (int i = 0; i < Resources.n; i++)
                for (int j = 0; j < Resources.m; j++)
                    if ((Resources.matrix[i, j] == 9 && !flagged[i, j])
                        || (Resources.matrix[i, j] != 9 && flagged[i, j]))
                        ok = false;

            if (ok)
            {
                MessageBox.Show("You Win!");
                display.Enabled = false;
            }
        }
    }
}

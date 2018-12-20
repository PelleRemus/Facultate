using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    internal static class Engine
    {
        internal static PictureBox display;
        internal static Label diff;
        internal static bool[,] visited, flagged;
        internal static bool wantsNewGame;
        internal static int x = 22;
        internal static Random rnd = new Random();
        internal static Color buttonColor = Color.FromArgb(110, 150, 210);

        internal static void InitGame(PictureBox p, Label l)
        {
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

        internal static void Block_MouseClick(object sender, MouseEventArgs e)
        {
            int i = (sender as Block).line;
            int j = (sender as Block).col;
            
            if (e.Button == MouseButtons.Left)
            {
                if (!flagged[i, j])
                {
                    if (Resources.matrix[i, j] == 9)
                        GameOver();
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

        static void GameOver()
        {
            for (int i = 0; i < Resources.n; i++)
                for (int j = 0; j < Resources.m; j++)
                    Resources.Show(i, j);
            display.Enabled = false;
            MessageBox.Show("You Lose!");
        }

        static void Check()
        {
            bool ok = true;
            for (int k = 0; k < Resources.n; k++)
                for (int l = 0; l < Resources.m; l++)
                {
                    if (Resources.matrix[k, l]==9)
                        if (!flagged[k, l])
                            ok = false;
                    if (flagged[k, l])
                        if (Resources.matrix[k, l]!=9)
                            ok = false;
                }

            if (ok)
            {
                MessageBox.Show("You Win!");
                display.Enabled = false;
            }
        }
    }
}

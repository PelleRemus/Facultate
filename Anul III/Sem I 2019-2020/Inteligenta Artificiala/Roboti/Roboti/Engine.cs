using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public static class Engine
    {
        public static int[,] map;
        public static Tile[,] tiles;
        public static int n, m, length = 25;

        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Random rnd = new Random();

        public static Tester t;

        public static void Init(PictureBox p)
        {
            display = p;
            n = p.Width / length;
            m = p.Height / length;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.LimeGreen);

            map = new int[n, m];
            tiles = new Tile[n, m];

            for(int i=0; i<n; i++)
                for(int j=0; j<m; j++)
                {
                    tiles[i, j] = new Tile(i, j);
                }

            for(int i=0; i<150; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = -1;
            }
            AddPollution();

            t = new Tester();
        }

        public static void AddPollution()
        {
            for (int i = 0; i < 150; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = rnd.Next(100);
                HeadQuarter.AddTarget(new Point(x, y));
            }
        }

        public static int DistManhatan(Point a, Point b)
        {
            int dist = Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
            if (dist == 0)
                return 1000;
            return dist;
        }

        public static int AMC(float[] ponderi)
        {
            float suma = 0;
            for (int i = 0; i < length; i++)
                suma += ponderi[i];
            float t = (float)rnd.NextDouble() * suma;
            int poz = length - 1;
            do
            {
                t -= ponderi[poz];
                poz--;
            } while (t >= 0);
            return poz + 1;
        }

        public static void DrawMap()
        {
            grp.Clear(Color.LimeGreen);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    tiles[i, j].DrawTile();
                }
            t.DrawRobot();
            display.Image = bmp;
        }

        public static List<string> ShowMatrix(int[,] matrix)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                s.Add("");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        s[i] += "[] ";
                    else
                        s[i] += matrix[i, j].ToString("00") + " ";
                }
            }
            return s;
        }
    }
}

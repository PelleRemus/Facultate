using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace LicentaDemo
{
    public static class Engine
    {
        public static Random rnd = new Random();
        public static List<Planet> planets = new List<Planet>();
        public static List<Player> players = new List<Player>();
        public static int[,] ma;
        public static int n;
        public static float zoomX = 1, zoomY = 1;

        public static Color backColor = Color.FromArgb(20, 20, 50);
        public static PictureBox display;
        public static Graphics grp;
        public static Bitmap bmp;

        public static void InitGraph(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backColor);

            display.Image = bmp;
        }

        public static void InitDemo()
        {
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());
        }

        public static void Load(string fileName, string fileName2)
        {
            TextReader dataLoad = new StreamReader(fileName);
            string buffer;

            while ((buffer = dataLoad.ReadLine()) != "end_planets")
            {
                planets.Add(new Planet(buffer));
            }

            n = planets.Count;
            ma = new int[n, n];
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                int i = int.Parse(local[0]);
                int j = int.Parse(local[1]);
                int value = int.Parse(local[2]);
                ma[i, j] = value;
                ma[j, i] = value;
            }

            dataLoad = new StreamReader(fileName2);
            while((buffer = dataLoad.ReadLine()) != null)
            {
                Fleet temp = new Fleet(buffer);
                while ((buffer = dataLoad.ReadLine()) != "end_fleet")
                {
                    if (buffer == null)
                        break;
                    temp.ships.Add(new Ship(buffer));
                }
            }
        }

        public static void DrawMap()
        {
            for(int i=0; i<n-1; i++)
                for(int j=i+1; j<n; j++)
                {
                    if (ma[i, j] != 0)
                        grp.DrawLine(new Pen(Color.White, 5), new Point((int)(planets[i].location.X * zoomX), (int)(planets[i].location.Y * zoomY)), 
                            new Point((int)(planets[j].location.X * zoomX), (int)(planets[j].location.Y * zoomY)));
                }

            foreach (Planet p in planets)
            {
                p.Draw();
            }
        }

        public static void RefreshMap()
        {
            display.Image = bmp;
        }

        public static void BattleWave(Fleet a, Fleet b)
        {
            foreach(Ship ship in a.ships)
            {
                int target = rnd.Next(b.ships.Count);
                float attack = ship.beam - b.ships[target].shield;
                if (attack < 0)
                    attack = 0;

                attack += ship.gun - b.ships[target].armor;
                if (attack < 0)
                    attack = 0;

                attack += ship.missile - b.ships[target].pointDef;
                if (attack < 0)
                    attack = 0;

                if (attack > 0)
                    b.ships[target].damage += attack;

                if (b.ships[target].damage >= b.ships[target].size)
                    b.ships[target].destroyed = true;
            }
        }

        public static void BattleCycle(Fleet a, Fleet b)
        {
            BattleWave(a, b);
            BattleWave(b, a);

            a.ships = a.ships.FindAll(delegate (Ship ship)
            {
                return !ship.destroyed;
            });

            b.ships = b.ships.FindAll(delegate (Ship ship)
            {
                return !ship.destroyed;
            });
        }
    }
}

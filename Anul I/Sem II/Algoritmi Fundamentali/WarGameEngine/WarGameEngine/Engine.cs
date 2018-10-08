using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WarGameEngine
{
    public static class Engine
    {
        public static PictureBox display;
        public static Random r = new Random();
        public static Player player1, player2;
        public static List<Unit> army1 = new List<Unit>();
        public static List<Unit> army2 = new List<Unit>();
        public static Bitmap bmp;
        public static Graphics grp;

        public static void InitGraf()
        {
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);

        }

        public static PointF GetRandomPoint()
        {
            return new PointF(r.Next(display.Width), r.Next(display.Height));
        }
        public static void InitGame()
        {
            player1 = new Player();
            player2 = new Player();
            for (int i=1; i<=10; i++)
            {
                army1.Add(new Unit("peasant" + i, GetRandomPoint(), 10, 0, 5, 5, 5, 5, 20));
            }
            army1.Add(new Unit("Sefu", GetRandomPoint(), 20, 5, 5, 5, 5, 5, 20));

            for (int i = 1; i <= 5; i++)
            {
                army2.Add(new Unit("Ogre" + i, GetRandomPoint(), 25, 10, 15, 15, 15, 15, 10));
            }
            army2.Add(new Unit("Black Dragon", GetRandomPoint(), 100, 50, 25, 25, 25, 25, 20));

            foreach (Unit u in army1)
            {
                u.owner = player1;
            }
            foreach (Unit u in army2)
            {
                u.owner = player2;
            }
        }

        public static void DrawMap()
        {
            foreach (Unit u in army1)
            {
                u.Draw();
            }
            foreach (Unit u in army2)
            {
                u.Draw();
            }
        }
        
        public static bool T(int a, int b)
        {
            int l = r.Next(a + b);
            if (l <= a) return true;
            return false;
        }

        public static void Battle(Unit a, Unit b)
        {
            int dev = r.Next((int)a.accuracy);
            if (dev < b.size)
            {
                if (T((int)a.speed, (int)b.dexterity))
                {
                    if (T((int)a.damage, (int)b.armor))
                    {
                        b.hp -= a.damage;
                    }
                    else
                    {
                        // defended
                    }
                }
                else
                {
                    //dodge
                }
            }
            else
            {
                // miss
            }
        }

    }
}

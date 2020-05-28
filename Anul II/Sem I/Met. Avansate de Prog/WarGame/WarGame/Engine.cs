using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WarGame
{
    public static class Engine
    {
        public static List<Unit> army1;
        public static List<Unit> army2;
        public static Random r = new Random();
        public static int resx, resy;
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;

        public static void initSesion()
        {
            army1 = new List<Unit>();
            army2 = new List<Unit>();

            for(int i=0; i<10; i++)
            {
                army1.Add(getUnit(unitType.human));
            }
            for(int i=0; i<3; i++)
            {
                army2.Add(getUnit(unitType.orc));
                army2.Add(getUnit(unitType.troll));
            }

            // numarul de elemente dintr-o enumerare
            int n = Enum.GetValues(typeof(unitType)).Length;

            int t = r.Next(n);
            army2.Add(getUnit((unitType)Enum.GetValues(typeof(unitType)).GetValue(t)));

        }

        public static void initGraf(PictureBox p)
        {
            display = p;
            resx = p.Width;
            resy = p.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
        }

        public static void DrawMap()
        {
            foreach(Unit u in army1)
            {
                if(!u.destroy)
                u.Draw();
            }
            foreach (Unit u in army2)
            {
                if(!u.destroy)
                u.Draw();
            }
            display.Image = bmp;
        }

        public static void Battle(Unit a, Unit b)
        {
            int t = r.Next(a.AS + 5);
            int d = r.Next(b.DS);
            if (t > d)
                b.destroy = true;
            DrawMap();
        }

        public static UnitAttribute getAtribute(unitType t)
        {
            return (UnitAttribute)Attribute.GetCustomAttribute(
                typeof(unitType).GetField(Enum.GetName(typeof(unitType), t)),
                typeof(UnitAttribute));
        }

        public static Unit getUnit(unitType t)
        {
            UnitAttribute local = getAtribute(t);
            Unit r = new Unit(local.AS, local.DS, local.size);
            return r;
        }
    }
}

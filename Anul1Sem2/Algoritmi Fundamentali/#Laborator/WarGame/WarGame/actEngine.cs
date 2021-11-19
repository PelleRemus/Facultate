using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WarGame
{
    public static partial class Engine
    {
        public static List<Unit> army1 = new List<Unit>();
        public static List<Unit> army2 = new List<Unit>();
        public static Random r = new Random();

        public static void InitGame()
        {
            army1.Add(new Unit("nume: Pascal, size: 2, throwingPower: 8, accuracy: 40, armor: 2, dexterity: 5, hp: 20"));
            army1.Add(new Unit("nume: Maximus, size: 20, throwingPower: 30, accuracy: 30, armor: 15, dexterity: 35, hp: 120"));
            army1.Add(new Unit("nume: Nemo, size: 5, throwingPower: 2, accuracy: 5, armor: 1, dexterity: 50, hp: 10"));

            army2.Add(new Unit("nume: Curaj, size: 12, throwingPower: 100, accuracy: 50, armor: 50, dexterity: 20, hp: 100"));
            army2.Add(new Unit("nume: Duchess, size: 10, throwingPower: 10, accuracy: 30, armor: 5, dexterity: 40, hp: 20"));
            army2.Add(new Unit("nume: Remy, size: 3, throwingPower: 3, accuracy: 50, armor: 2, dexterity: 60, hp: 10"));

            foreach (Unit u in army1)
            {
                PointF t = GetRandomPoint();
                u.SetMapLocation(t);
            }
            foreach (Unit u in army2)
            {
                PointF t = GetRandomPoint();
                u.SetMapLocation(t);
            }
        }

        public static void Battle(Unit a, Unit b)
        {
            float attack = a.accuracy + b.size;
            float defense = b.dexterity;
            int t = r.Next(1, (int)(attack + defense + 1));

            if (t <= attack)
            {
                attack = r.Next(1, (int)a.throwingPower + 1);
                defense = r.Next(1, (int)b.armor + 1);
                if (attack>defense)
                {
                    b.hp -= attack;
                    if (b.hp <= 0)
                    {
                        b.ko = true;
                    }
                }
                else
                {
                    //armor too high
                }
            }
            else
            {
                //dodge
            }
        }

        public static void War()
        {
            foreach (Unit u in army1)
            {
                int t = r.Next(army2.Count);
                Battle(u, army2[t]);
            }
            foreach (Unit u in army2)
            {
                int t = r.Next(army1.Count);
                Battle(u, army1[t]);
            }

            army1 = army1.FindAll(delegate (Unit u) { return !u.ko; });
            army2 = army2.FindAll(delegate (Unit u) { return !u.ko; });
        }

    }
}

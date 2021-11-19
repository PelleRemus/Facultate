using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WarGame
{
    public class Unit
    {
        public int AS, DS, size;
        public Point position;
        public bool destroy;

        public Unit(int a, int d, int s)
        {
            AS = a;
            DS = d;
            size = s;
            destroy = false;
            position = new Point(Engine.r.Next(Engine.resx), Engine.r.Next(Engine.resy));
        }

        public void Draw()
        {
            Engine.grp.DrawEllipse(new Pen(Color.Black, 3), position.X, position.Y, size, size);
        }
    }
}

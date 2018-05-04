using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WarGameEngine
{
    public class Unit
    {
        public float accuracy;
        public float damage;
        public float speed;
        public float size;
        public float dexterity;
        public float armor;
        public float hp;
        public PointF location;
        public string name;
        public Player owner;

        public Unit(string name, PointF location, float hp, float armor, float dexterity, float size, float speed, float damage, float accuracy)
        {
            this.name = name;
            this.location = location;
            this.hp = hp;
            this.armor = armor;
            this.dexterity = dexterity;
            this.size = size;
            this.speed = speed;
            this.damage = damage;
            this.accuracy = accuracy;
        }

        public void Draw()
        {
            Engine.grp.DrawEllipse(new Pen(owner.backColor), location.X - size, location.Y - size, 2 * size, 2 * size);
        }
    }
}

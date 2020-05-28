using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaDemo
{
    public class Ship
    {
        public string name;
        public float beam, gun, missile;
        public float shield, armor, pointDef;
        public float size, damage;
        public bool destroyed;

        public Ship(float beam, float gun, float missile, float shield, float armor, float pointDef, float size)
        {
            this.beam = beam;
            this.gun = gun;
            this.missile = missile;
            this.shield = shield;
            this.armor = armor;
            this.pointDef = pointDef;
            this.size = size;
            name = "default";
            damage = 0;
            destroyed = false;
        }

        public Ship(string data)
        {
            string[] local = data.Split(' ');
            beam = int.Parse(local[0]);
            gun = int.Parse(local[1]);
            missile = int.Parse(local[2]);
            shield = int.Parse(local[3]);
            armor = int.Parse(local[4]);
            pointDef = int.Parse(local[5]);
            size = int.Parse(local[6]);
            name = local[7];
            damage = 0;
            destroyed = false;
        }
    }
}

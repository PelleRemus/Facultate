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
        public Image image;
        string name;
        public float size;
        public float throwingPower;
        public float damage;
        public float accuracy;
        public float armor;
        public float dexterity;
        public float hp;
        int x, y;
        public bool ko;

        // "name: soarece, size: 2, throwingPower: 0.4, accuracy: 2, armor: 0.4, dexterity: 5, hp: 5"
        // "name: elefant, size: 40, throwingPower: 8, accuracy: 5, armor: 10, dexterity: 0, hp: 50"
        public Unit(string s)
        {
            char[] sep = new char[] { ':', ',' };
            string[] local = s.Split(sep);
            this.name = local[1].Trim(' ');
            this.size = float.Parse(local[3]);
            this.throwingPower = float.Parse(local[5]);
            this.accuracy = float.Parse(local[7]);
            this.armor = float.Parse(local[9]);
            this.dexterity = float.Parse(local[11]);
            this.hp = float.Parse(local[13]);
            this.damage = 0;
            this.ko = false;

            try
            {
                this.image = Image.FromFile(@"..\..\Resurse\" + this.name + ".png");
            }
            catch
            {
                //nu facem nimic
            }
        }

        public void Draw()
        {
            if (image!=null)
            {
                Engine.grp.DrawImage(image, x, y, 100 + (int)size, 100 + (int)size);
            }
            else
            {
                Engine.grp.FillEllipse(new SolidBrush(Color.Red), x - 50, y - 50, 100, 100);
                Engine.grp.DrawString(this.name, new Font("Arial", 10, FontStyle.Bold),
                    new SolidBrush(Color.Black), new Point(this.x, this.y));
            }

            Engine.grp.DrawString(this.hp.ToString(), new Font("Arial", 10, FontStyle.Bold),
                    new SolidBrush(Color.Black), new Point(this.x, this.y + 15));
        }

        public void SetMapLocation(PointF t)
        {
            this.x = (int)t.X;
            this.y = (int)t.Y;
        }
    }
}

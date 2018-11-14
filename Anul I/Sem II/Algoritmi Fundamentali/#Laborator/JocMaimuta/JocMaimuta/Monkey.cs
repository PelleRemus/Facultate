using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace JocMaimuta
{
    public class Monkey
    {
        public int health;
        public int speed;
        public int x;
        public int y;
        public int dimensiune;
        public PictureBox monkey = new PictureBox();
        Form form;

        public Monkey(int h, int s, int d, Point p, Image img, Form form)
        {
            health = h;
            speed = s;
            x = p.X; y = p.Y;
            dimensiune = d;
            this.form = form;

            monkey.Size = new Size(dimensiune, dimensiune);
            monkey.Left = x;
            monkey.Top = y;
            monkey.BackColor = Color.Transparent;
            monkey.Image = img;
            monkey.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void Draw()
        {
            monkey.Left = x;
            monkey.Top = y;
        }
    }
}

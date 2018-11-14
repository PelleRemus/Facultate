using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace JocMaimuta
{
    public static class Engine
    {
        public static Random r = new Random();
        public static Monkey player;
        public static Monkey computer;

        public static void InitGame(Form form)
        {
            player = new Monkey(5, 10, 75, new Point(50, 50), Image.FromFile(@"../../Resurse/maimutica.png"), form);
            computer = new Monkey(15, 30, 125,new Point(650, 250), Image.FromFile(@"../../Resurse/maimuta.png"), form);
            form.Controls.Add(player.monkey);
            form.Controls.Add(computer.monkey);
            player.Draw();
            computer.Draw();
        }

        public static void Check(Form form)
        {
            foreach (Control x in form.Controls)
                if (x is PictureBox && x.Tag == "banana")
                { 
                    if (((PictureBox)x).Bounds.IntersectsWith(player.monkey.Bounds))
                    {
                        player.health--;
                        form.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                    if (((PictureBox)x).Bounds.IntersectsWith(computer.monkey.Bounds))
                    {
                        computer.health--;
                        form.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }
        }
    }
}

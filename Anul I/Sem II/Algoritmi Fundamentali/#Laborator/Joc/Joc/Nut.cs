using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Joc
{
    public class Nut
    {
        public PointF position, destination;
        public int speed = 1;
        public int x = 115, y = 80;
        public PictureBox nut = new PictureBox();
        Timer tm = new Timer();
        Form form;
        float t = 0;

        public Nut(PointF p, Image img, Form form)
        {
            this.form = form;
            destination = p;
            position = new PointF(x, y);
            tm.Interval = speed;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();

            nut.Size = new Size(20, 20);
            Update();
            nut.Image = img;
            nut.SizeMode = PictureBoxSizeMode.Zoom;
            nut.Tag = "Nut";
            nut.BringToFront();
            form.Controls.Add(nut);
        }

        public void tm_Tick(object sender, EventArgs e)
        {
            t += 0.03f;
            position.X = (1 - t) * x + t * destination.X;
            position.Y = (1 - t) * y + t * destination.Y;
            if (position.X >= form.Width || position.Y >= form.Height)
                form.Controls.Remove(nut);
            Update();
        }
        void Update()
        {
            nut.Left = (int)position.X;
            nut.Top = (int)position.Y;
        }
    }
}

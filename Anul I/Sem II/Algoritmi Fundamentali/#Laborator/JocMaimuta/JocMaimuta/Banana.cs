using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace JocMaimuta
{
    public class Banana
    {
        public string direction;
        public int speed = 20;
        PictureBox banana = new PictureBox();
        Timer tm = new Timer();
        public int x;
        public int y;

        public Banana(Point p, Form form, Image img, string s)
        {
            x = p.X;
            y = p.Y;
            direction = s;

            banana.BackColor = Color.Transparent;
            banana.Size = new Size(30, 30);
            banana.Left = x;
            banana.Top = y;
            banana.Tag = "banana";
            banana.Image = img;
            banana.SizeMode = PictureBoxSizeMode.Zoom;
            banana.BringToFront();
            form.Controls.Add(banana);

            tm.Interval = speed;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
        }

        public void tm_Tick(object sender, EventArgs e)
        {
            if (direction == "left")
                banana.Left -= speed;
            if (direction == "right")
                banana.Left += speed;
            if (direction == "up")
                banana.Top -= speed;
            if (direction == "down")
                banana.Top += speed;

            if (banana.Left < 30 || banana.Left > 840 || banana.Top < 30 || banana.Top > 420)
            {
                tm.Stop();
                tm.Dispose();
                banana.Dispose();
                tm = null;
                banana = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidpointAlgorythm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            Point p1 = new Point();
            Point p2 = new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
            grp.FillEllipse(new SolidBrush(Color.Red), p2.X - 2, p2.Y - 2, 5, 5);
            MidpointLine(p1, p2);

            pictureBox1.Image = bmp;
        }

        void MidpointLine(Point p1, Point p2)
        {
            int dx = p2.X - p1.X, dy = p2.Y - p1.Y;
            int d = 2 * dy - dx;
            int incrE = 2 * dy, incrNE = 2 * (dy - dx);
            int x = p1.X, y = p1.Y;
            grp.DrawEllipse(Pens.Black, x, y, 1, 1);

            while (x < p2.X)
            {
                if (d < 0)
                    d += incrE;
                else
                {
                    d += incrNE;
                    y++;
                }
                x++;
                grp.DrawEllipse(Pens.Black, x, y, 1, 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fr01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b;
        Graphics g;
        static int resx, resy;

        private void Form1_Load(object sender, EventArgs e)
        {
            resx = pictureBox1.Width;
            resy = pictureBox1.Height;
            b = new Bitmap(resx,resy);
            g = Graphics.FromImage(b);
            /*g.DrawLine(new Pen(Color.Red, 2), 0, 0, resx, resy);
            g.DrawLine(new Pen(Color.Red, 2), 0, resy, resx, 0);
            g.DrawLine(new Pen(Color.Red, 2), 0, resy/2, resx/2, 0);*/
            T(resx / 2, resy / 2, 300);
            pictureBox1.Image = b;
        }

        public void patrat(int x, int y, int l)
        {
            g.DrawLine(new Pen(Color.Red, 2), x - l / 2, y - l / 2, x - l / 2, y + l / 2);
            g.DrawLine(new Pen(Color.Red, 2), x - l / 2, y + l / 2, x + l / 2, y + l / 2);
            g.DrawLine(new Pen(Color.Red, 2), x + l / 2, y + l / 2, x + l / 2, y - l / 2);
            g.DrawLine(new Pen(Color.Red, 2), x + l / 2, y - l / 2, x - l / 2, y - l / 2);
        }

        public void T(int x, int y, int l)
        {
            if (l>1)
            {
                patrat(x, y, l);
                T(x - l / 2, y - l / 2, l / 2);
                T(x + l / 2, y - l / 2, l / 2);
                T(x + l / 2, y + l / 2, l / 2);
                T(x - l / 2, y + l / 2, l / 2);
            }
        }


    }
}

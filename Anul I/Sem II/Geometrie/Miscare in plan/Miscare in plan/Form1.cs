using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miscare_in_plan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        static Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Gray);
            //int x1 = 100, y1 = 33, x2 = 29, y2 = 10;
            int x1 = rnd.Next(pictureBox1.Width), x2 = rnd.Next(pictureBox1.Width), y1 = rnd.Next(pictureBox1.Height), y2 = rnd.Next(pictureBox1.Height);
            grp.DrawEllipse(pen, x1 - 3, y1 - 3, 7, 7);
            grp.DrawEllipse(pen, x2 - 3, y2 - 3, 7, 7);
            grp.DrawLine(pen, x1, y1, x2, y2);
            //int a1 = 400, b1 = 300, a2 = 300, b2 = 400;
            int a1 = rnd.Next(pictureBox1.Width), a2 = rnd.Next(pictureBox1.Width), b1 = rnd.Next(pictureBox1.Height), b2 = rnd.Next(pictureBox1.Height);
            grp.DrawEllipse(pen, a1 - 3, b1 - 3, 7, 7);
            grp.DrawEllipse(pen, a2 - 3, b2 - 3, 7, 7);
            grp.DrawLine(pen, a1, b1, a2, b2);

            float x, y, a, b;
            for (int i = 0; i <= 100; i++)
            {
                float t = i * (float)0.01;
                x = (1 - t) * x1 + t * x2;
                y = (1 - t) * y1 + t * y2;
                a = (1 - t) * a1 + t * a2;
                b = (1 - t) * b1 + t * b2;
                grp.DrawEllipse(pen, x, y, 1, 1);
                grp.DrawEllipse(pen, a, b, 1, 1);
                Pen pen2 = new Pen(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                switch (i / 13)
                {
                    case 0:
                        pen2 = new Pen(Color.Red); break;
                    case 1:
                        pen2 = new Pen(Color.Orange); break;
                    case 2:
                        pen2 = new Pen(Color.Yellow); break;
                    case 3:
                        pen2 = new Pen(Color.Green); break;
                    case 4:
                        pen2 = new Pen(Color.Blue); break;
                    case 5:
                        pen2 = new Pen(Color.Indigo); break;
                    case 6:
                        pen2 = new Pen(Color.Purple); break;
                    case 7:
                        pen2 = new Pen(Color.Magenta); break;
                }
                float _x1 = x, _y1 = y;
                //int r1 = rnd.Next(150), r2 = rnd.Next(20);
                for (int j = 1; j <= 1000; j++)
                {
                    float _t = j * (float)0.001;
                    /*float p = (float)Math.Pow(_t, r1);
                    float q = (float)Math.Pow(_t, r2);*/
                    float p = (float)Math.Pow(_t, 150);
                    float q = (float)Math.Pow(_t, 10);
                    float _x2 = (1 - p) * x + q * a;
                    float _y2 = (1 - p) * y + q * b;
                    grp.DrawEllipse(pen2, _x2, _y2, 1, 1);
                    grp.DrawLine(pen2, _x1, _y1, _x2, _y2);
                    _x1 = _x2; _y1 = _y2;
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}

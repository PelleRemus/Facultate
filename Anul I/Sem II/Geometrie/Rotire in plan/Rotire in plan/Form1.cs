using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rotire_in_plan
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
            int o1 = pictureBox1.Width / 4, o2 = pictureBox1.Height / 2;
            Pen blackPen = new Pen(Color.Black);
            grp.DrawLine(blackPen, o1, 0, o1, pictureBox1.Height);
            grp.DrawLine(blackPen, 0, o2, pictureBox1.Width, o2);

            //int x1 = 100, y1 = 33, x2 = 29, y2 = 10;
            int x1 = rnd.Next(pictureBox1.Width/2), x2 = rnd.Next(pictureBox1.Width/2), y1 = rnd.Next(pictureBox1.Height/2), y2 = rnd.Next(pictureBox1.Height/2);
            Pen pen = new Pen(Color.Gray);
            grp.DrawEllipse(pen, x1 + o1 - 3, y1 + o2 - 3, 7, 7);
            grp.DrawEllipse(pen, x2 + o1 - 3, y2 + o2 - 3, 7, 7);
            grp.DrawLine(pen, x1 + o1, y1 + o2, x2 + o1, y2 + o2);

            float teta = (float)Math.PI / 2, x, y;
            for (int i = 0; i <= 100; i++)
            {
                float t = i * 0.01f;
                x = (1 - t) * x1 + t * x2;
                y = (1 - t) * y1 + t * y2;
                grp.DrawEllipse(pen, x + o1, y + o2, 1, 1);
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
                int r1 = rnd.Next(150), r2 = rnd.Next(20);
                for (int j = 0; j < 1000; j++)
                {
                    float _t = j * (float)0.001;
                    float p = (float)Math.Pow(_t, r1);
                    float q = (float)Math.Pow(_t, r2);
                    /*float p = (float)Math.Pow(_t, 150);
                    float q = (float)Math.Pow(_t, 20);*/
                    float _x2, _y2, a, b;
                    a = x1 * (float)Math.Cos(t * teta) + y1 * (float)Math.Sin(t * teta);
                    b = -x1 * (float)Math.Sin(t * teta) + y1 * (float)Math.Cos(t * teta);
                    _x2 = (1 - p) * x + q * a;
                    _y2 = (1 - p) * y + q * b;
                    grp.DrawEllipse(pen2, _x2 + o1, _y2 + o2, 1, 1);
                    grp.DrawLine(pen2, _x1 + o1, _y1 + o2, _x2 + o1, _y2 + o2);
                    _x1 = _x2; _y1 = _y2;
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}

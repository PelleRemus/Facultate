using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Populatii
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        static Random r = new Random();
        PointF origin;
        Pen grayPen = new Pen(Color.Gray, 2);
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            origin = new PointF(35, pictureBox1.Height - 35);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.DrawLine(grayPen, 0, pictureBox1.Height - 35, pictureBox1.Width, pictureBox1.Height - 35);
            grp.DrawLine(grayPen, 35, 0, 35, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)), r.Next(2, 5));
            float a = (float)r.NextDouble();
            float y0 = (float)r.NextDouble(), y1;
            int _t = 10;
            for (int t = _t; t < 1000; t += _t)
            {
                y1 = y0 + a * y0 * (1 - y0);
                grp.DrawEllipse(pen, origin.X + t - 2, origin.Y - 300 * y1 - 2, 5, 5);
                grp.DrawLine(pen, new PointF(origin.X + t - 10, origin.Y - 300 * y0), new PointF(origin.X + t, origin.Y - 300 * y1));
                y0 = y1;
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.DrawLine(grayPen, 0, pictureBox1.Height - 35, pictureBox1.Width, pictureBox1.Height - 35);
            grp.DrawLine(grayPen, 35, 0, 35, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }
    }
}

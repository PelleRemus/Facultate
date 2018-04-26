using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotirePatrat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        static int k = 0, x;
        float l;
        static int red = 255, green = 0, blue = 0;
        static Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            x = pictureBox1.Width / 2;
            l = pictureBox1.Width / 2 + 20;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k += 1;
            Patrat(k);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Patrat(int k)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float fi = (float)Math.PI / 180 * k/4;
            float unghi = (float)Math.PI / 2;
            Color color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            PointF[] points = new PointF[4];
            int y = pictureBox1.Height/2;

            color = Color.FromArgb(red, green, blue);
            red -= 10; green += 10; blue += 10;
            if (red<0)
            {
                red = 255;
                green = 0;
                blue = 0;
            }
            switch (k/7%11)
            {
                case 0: { color = Color.Red; break; }
                case 1: { color = Color.OrangeRed; break; }
                case 2: { color = Color.Orange; break; }
                case 3: { color = Color.Yellow; break; }
                case 4: { color = Color.GreenYellow; break; }
                case 5: { color = Color.LawnGreen; break; }
                case 6: { color = Color.Green; break; }
                case 7: { color = Color.MediumBlue; break; }
                case 8: { color = Color.BlueViolet; break; }
                case 9: { color = Color.Violet; break; }
                case 10: { color = Color.MediumVioletRed; break; }
            }

            for (int i=0; i<4; i++)
            {
                float _x = x + l * (float)Math.Cos(unghi * i + fi);
                float _y = y + l * (float)Math.Sin(unghi * i + fi);
                points[i] = new PointF(_x, _y);
            }
            l -= 1/4f;
            if (l == 0) timer1.Enabled = false;
            //x += 1;
            grp.FillPolygon(new SolidBrush(color), points);
            grp.DrawPolygon(new Pen(color, 2), points);
            pictureBox1.Image = bmp;
        }
    }
}

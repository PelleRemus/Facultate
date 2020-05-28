using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolinomTaylor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            a = -2 * Math.PI; b = -a;
        }

        double a, b, h, alpha, f, scale;
        int height, width;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            h = (b - a) / 1000;
            scale = 4 * Math.PI;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            for (int k = 0; k <= 1000; k++)
            {
                alpha = a + k * h;
                float x = center.X + (float)(alpha * width / scale) - 1;
                
                //cosinus
                /*f = 1 - alpha * alpha / 2;
                float y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);

                f += alpha * alpha * alpha * alpha / 24;
                y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                f += Math.Pow(alpha, 6) / 720;
                y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Green), x, y, 3, 3);
                */
                //sinus
                f = alpha - alpha * alpha * alpha / 6;
                float y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);

                f += Math.Pow(alpha, 5) / 120;
                y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                f += Math.Pow(alpha, 7) / 5040;
                y = center.Y - (float)(f * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Green), x, y, 3, 3);
            }
        }

        void DrawSketch()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            grp.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            for (double x = a; x <= b; x += h)
            {
                float X = center.X + (float)(x * width / scale) - 1;
                //cosinus
                //float Y = center.Y - (float)(Math.Cos(x) * height / scale) - 1;

                //sinus
                float Y = center.Y - (float)(Math.Sin(x) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Black), X, Y, 3, 3);
            }
            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolinomulCubicHermite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //sinus
            //a = Math.PI / 6; b = Math.PI / 2;
            //fa = 0.5; fb = 1; dfa = 0.5 * Math.Sqrt(3); dfb = 0;

            //radical
            a = 4; b = 9;
            fa = 2; fb = 3; dfa = 0.5; dfb = 1.0 / 6;
        }

        double a, b, h, alpha, f, scale;
        double fa, fb, dfa, dfb;
        int height, width;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            h = (b - a) / 1000;
            //sinus
            //scale = Math.PI / 2 - Math.PI / 6;

            //radical
            scale = 5;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            for(int k=0; k<=1000; k++)
            {
                alpha = a + k * h;
                f = (b - alpha) * (b - alpha) * (2 * (alpha - a) + b - a) / (b - a) / (b - a) / (b - a) * fa +
                    (alpha - a) * (alpha - a) * (2 * (b - alpha) + b - a) / (b - a) / (b - a) / (b - a) * fb +
                    (b - alpha) * (b - alpha) * (alpha - a) / (b - a) / (b - a) * dfa -
                    (alpha - a) * (alpha - a) * (b - alpha) / (b - a) / (b - a) * dfb;
                //sinus
                //float X = center.X + (float)((alpha - 0.5) * width / scale) - 1;
                //float Y = center.Y - (float)((f - 0.5) * height * 2) - 1;

                //radical
                float X = center.X + (float)((alpha - 4) * width / scale) - 1;
                float Y = center.Y - (float)((f - 2) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), X, Y, 3, 3);
            }
        }

        void DrawSketch()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.DrawLine(Pens.Black, 0, height, pictureBox1.Width, height);
            grp.DrawLine(Pens.Black, 20, 0, 20, pictureBox1.Height);
            center = new Point(20, height);

            //sinus
            /*for (double x = a; x <= b; x += h)
            {
                float X = center.X + (float)((x - 0.5) * width / scale) - 1;
                float Y = center.Y - (float)((Math.Sin(x) - 0.5) * height * 2) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), X, Y, 3, 3);
            }*/

            //radical
            for (double x = a; x <= b; x += h)
            {
                float X = center.X + (float)((x - 4) * width / scale) - 1;
                float Y = center.Y - (float)((Math.Sqrt(x) - 2) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), X, Y, 3, 3);
            }
            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PolinoameBernstein
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int width, height;
        double h, scale;

        Graphics grp;
        Bitmap bmp;
        Point center;

        private void Form1_Load(object sender, EventArgs e)
        {
            h = 0.001;
            scale = Math.E - 1;
            width = pictureBox1.Width - 20;
            height = pictureBox1.Height - 20;
            DrawSketch();

            for(int k=0; k<1000; k++)
            {
                float x = center.X + (float)(k * h * width) - 1;
                float y = center.Y - (float)((f(k * h) - 1) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Gray), x, y, 3, 3);

                y = center.Y - (float)((B1(k * h) - 1) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Black), x, y, 3, 3);

                y = center.Y - (float)((B2(k * h) - 1) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - (float)((B3(k * h) - 1) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Green), x, y, 3, 3);

                y = center.Y - (float)((B4(k * h) - 1) * height / scale) - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);

                /*y = center.Y - (float)((b1(k * h) - 1) * height) - 1;
                grp.FillEllipse(new SolidBrush(Color.Black), x, y, 3, 3);

                y = center.Y - (float)((b2(k * h) - 1) * height) - 1;
                grp.FillEllipse(new SolidBrush(Color.Blue), x, y, 3, 3);

                y = center.Y - (float)((b4(k * h) - 1) * height) - 1;
                grp.FillEllipse(new SolidBrush(Color.Red), x, y, 3, 3);
                */
            }
        }
        
        void DrawSketch()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            grp.DrawLine(Pens.Black, 0, height, pictureBox1.Width, height);
            grp.DrawLine(Pens.Black, 20, 0, 20, pictureBox1.Height);

            grp.DrawString("1", new Font("Arial", 15), new SolidBrush(Color.Black), 0, height - 15);
            grp.DrawString("e", new Font("Arial", 15), new SolidBrush(Color.Black), 0, 0);
            grp.DrawString("0", new Font("Arial", 15), new SolidBrush(Color.Black), 20, height);
            grp.DrawString("1", new Font("Arial", 15), new SolidBrush(Color.Black), width, height);

            grp.FillRectangle(new SolidBrush(Color.Gray), 27, 10, 15, 15);
            grp.DrawString("f", new Font("Arial", 15), new SolidBrush(Color.Black), 43, 5);

            grp.FillRectangle(new SolidBrush(Color.Black), 27, 30, 15, 15);
            grp.DrawString("B1(f)", new Font("Arial", 15), new SolidBrush(Color.Black), 43, 25);

            grp.FillRectangle(new SolidBrush(Color.Blue), 27, 50, 15, 15);
            grp.DrawString("B2(f)", new Font("Arial", 15), new SolidBrush(Color.Black), 43, 45);

            grp.FillRectangle(new SolidBrush(Color.Green), 27, 70, 15, 15);
            grp.DrawString("B3(f)", new Font("Arial", 15), new SolidBrush(Color.Black), 43, 65);

            grp.FillRectangle(new SolidBrush(Color.Red), 27, 90, 15, 15);
            grp.DrawString("B4(f)", new Font("Arial", 15), new SolidBrush(Color.Black), 43, 85);

            center = new Point(20, height);
            pictureBox1.Image = bmp;
        }

        double f(double x)
        {
            return Math.Pow(Math.E, x);
        }

        #region e^x
        double B1(double x)
        {
            return 1 - x + x * Math.E;
        }
        double B2(double x)
        {
            return (1 - x) * (1 - x) + 2 * x * (1 - x) * Math.Sqrt(Math.E) + x * x * Math.E;
        }
        double B3(double x)
        {
            return (1 - x) * (1 - x) * (1 - x) +
                3 * x * (1 - x) * (1 - x) * Math.Pow(Math.E, 1.0 / 3) +
                3 * x * x * (1 - x) * Math.Pow(Math.E, 2.0 / 3) +
                x * x * x * Math.E;
        }
        double B4(double x)
        {
            return (1 - x) * (1 - x) * (1 - x) * (1 - x) +
                4 * x * (1 - x) * (1 - x) * (1 - x) * Math.Sqrt(Math.Sqrt(Math.E)) +
                6 * x * x * (1 - x) * (1 - x) * Math.Sqrt(Math.E) +
                4 * x * x * x * (1 - x) * Math.Sqrt(Math.Sqrt(Math.E * Math.E * Math.E)) +
                x * x * x * x * Math.E;
        }
        #endregion

        #region 1+sqrt(x)
        double b1(double x)
        {
            return 1 - x + 2 * x;
        }
        double b2(double x)
        {
            return (1 - x) * (1 - x) + 2 * x * (1 - x) * (1 + 0.5 * Math.Sqrt(2)) + x * x * 2;
        }
        double b4(double x)
        {
            return (1 - x) * (1 - x) * (1 - x) * (1 - x) +
                4 * x * (1 - x) * (1 - x) * (1 - x) * 1.5 +
                6 * x * x * (1 - x) * (1 - x) * (1 + 0.5 * Math.Sqrt(2)) +
                4 * x * x * x * (1 - x) * (1 + 0.5 * Math.Sqrt(3)) +
                2 * x * x * x * x;
        }
        #endregion
    }
}

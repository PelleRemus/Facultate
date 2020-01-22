using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLineSimplified
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

            Point p1 = new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
            Point p2 = new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height));
            grp.FillEllipse(new SolidBrush(Color.Blue), p1.X - 3, p1.Y - 3, 7, 7);
            grp.FillEllipse(new SolidBrush(Color.Red), p2.X - 3, p2.Y - 3, 7, 7);
            DrawLine(p1.X, p1.Y, p2.X, p2.Y);
            pictureBox1.Image = bmp;
        }

        void DrawLine(int x0, int y0, int x1, int y1)
        {
            int
                distX = Math.Abs(x1 - x0),
                signX = x0 < x1 ? 1 : -1,
                distY = Math.Abs(y1 - y0),
                signY = y0 < y1 ? 1 : -1,
                x = x0, y = y0,
                error = distX > distY ? distX / 2 : -distY / 2;
            
            while ((x != x1) || (y != y1))
            {
                bmp.SetPixel(x, y, Color.Black);
                int aux = error;

                if (aux > -distX)
                {
                    error -= distY;
                    x += signX;
                }
                if (aux < distY)
                {
                    error += distX;
                    y += signY;
                }
            }
        }
    }
}

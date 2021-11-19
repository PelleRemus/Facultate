using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AriePoligon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        List<Point> points;
        int n = 10;

        private void button1_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            for (int i = 0; i < n; i++)
                points.Add(new Point(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height)));
            points.Add(points[0]);

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.FillPolygon(new SolidBrush(Color.LightBlue), points.ToArray());
            grp.DrawPolygon(Pens.Blue, points.ToArray());
            pictureBox1.Image = bmp;

            double surface = 0;
            for(int i=0; i<n; i++)
                surface += 0.5 * (points[i].X * points[i + 1].Y - points[i + 1].X * points[i].Y);
            textBox1.Text = Math.Abs(surface).ToString("0.000");
        }
    }
}

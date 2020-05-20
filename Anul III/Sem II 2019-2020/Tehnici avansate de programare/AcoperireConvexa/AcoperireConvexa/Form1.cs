using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcoperireConvexa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        List<Point> points;
        int n = 20;

        private void button1_Click(object sender, EventArgs e)
        {
            //mii de multumiri lui Csongor pentru acest cod foarte curat :D

            points = new List<Point>();
            for (int i = 0; i < n; i++)
                points.Add(new Point(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height)));

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grp = Graphics.FromImage(bmp);
            foreach (Point p in points)
                grp.DrawEllipse(Pens.Red, p.X - 1, p.Y - 1, 3, 3);

            Jarvis jarvis = new Jarvis(points);
            grp.DrawPolygon(Pens.Black, jarvis.NicerJarvisMarch().ToArray());
            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbore
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

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen redPen = new Pen(Color.Red, 2);

            Point A = new Point();
            A.X = pictureBox1.Width / 2;
            A.Y = 15;
            grp.DrawEllipse(redPen, A.X - 15, A.Y - 15, 31, 31);

            pictureBox1.Image = bmp;
        }
    }
}

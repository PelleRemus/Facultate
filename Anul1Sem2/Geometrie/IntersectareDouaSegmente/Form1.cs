using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intersec
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        public List<PointF> line1;
        public List<PointF> line2;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            line1 = new List<PointF>();
            line2 = new List<PointF>();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (line1.Count == 2 && line2.Count == 2)
                    return;

                if (line1.Count < 2)
                {
                    line1.Add(new PointF(e.X, e.Y));
                    
                    if (line1.Count == 2)
                        grp.DrawPolygon(Pens.Black, line1.ToArray());
                }
                else
                {
                    line2.Add(new PointF(e.X, e.Y));
                    if (line2.Count == 2)
                        grp.DrawPolygon(Pens.Black,line2.ToArray());
                }
                grp.DrawEllipse(Pens.Black, e.X - 2, e.Y - 2, 5, 5);
                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (seIntersecteaza())
                button1.BackColor = Color.Green;
            else
                button1.BackColor = Color.Red;
        }

        private bool seIntersecteaza()
        {
            return (
                careParte(line1[0],line2[0]) != careParte(line1[0], line2[1])
                &&
                careParteUp(line2[0], line1[0]) != careParteUp(line2[0], line1[1])
            );
        }
        private string careParte(PointF p1, PointF p2)
        {
            if (p1.X - p2.X<0)
                return "dreapta";
            else
                return "stanga";
        }
        private string careParteUp(PointF p1, PointF p2)
        {
            if (p1.Y - p2.Y < 0)
                return "sus";
            else
                return "jos";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            grp.Clear(Color.White);
            pictureBox1.Image = bmp;
            line1 = new List<PointF>();
            line2 = new List<PointF>();
            button1.BackColor = Color.White;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voronoi
{
    public partial class Form1 : Form
    {
        int resx, resy, n = 15;
        List<Color> colors = new List<Color>();
        List<Point> points = new List<Point>();
        Random r = new Random();
        Graphics grp;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            resx = pictureBox1.Width;
            resy = pictureBox1.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pictureBox1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            points.Clear();
            colors.Clear();
            Init();
            Draw();
            pictureBox1.Image = bmp;
        }

        void Init()
        {
            for (int i = 0; i < n; i++)
            {
                points.Add(new Point(r.Next(resx), r.Next(resy)));
                colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            }
        }

        void Draw()
        {
            for (int i = 0; i < resx; i++)
                for (int j = 0; j < resy; j++)
                {
                    int min = Dist(new Point(i, j), points[0]);
                    int poz = 0;
                    for(int k=0; k<n; k++)
                        if(Dist(new Point(i,j), points[k])<min)
                        {
                            min = Dist(new Point(i, j), points[k]);
                            poz = k;
                        }
                    bmp.SetPixel(i, j, colors[poz]);
                }
            for (int i = 0; i < n; i++)
                grp.FillEllipse(new SolidBrush(Color.Black), points[i].X - 3, points[i].Y - 3, 7, 7);
        }

        int Dist(Point a, Point b)
        {
            return (int)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}

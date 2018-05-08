using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galerii2
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        private List<Punct> points;
        private List<int> name;
        int x = 0;
        Pen blackPen = new Pen(Color.Black, 2);
        Pen redPen = new Pen(Color.Red, 2);


        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            grp.Clear(Color.White);
            points = new List<Punct>();
            name = new List<int>();
            pictureBox1.Image = bmp;
        }

        /*private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x++;
                name.Add(x);
                points.Add(new Point(e.X, e.Y));
                grp.DrawEllipse(blackPen, e.X - 2, e.Y - 2, 5, 5);
                grp.DrawString(" " + x, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.DarkBlue), new Point(e.X + 5, e.Y + 5));
                pictureBox1.Invalidate();
            }
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            points.Add(new Punct(new PointF(90, 450))); 
            points.Add(new Punct(new PointF(75, 300)));
            points.Add(new Punct(new PointF(120, 150)));
            points.Add(new Punct(new PointF(180, 300)));
            points.Add(new Punct(new PointF(270, 150)));
            points.Add(new Punct(new PointF(450, 255)));
            points.Add(new Punct(new PointF(300, 390)));
            points.Add(new Punct(new PointF(480, 390)));
            points.Add(new Punct(new PointF(370, 450)));
            points.Add(new Punct(new PointF(270, 480)));
            grp.DrawEllipse(blackPen, points[0].pozitie.X - 2, points[0].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[1].pozitie.X - 2, points[1].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[2].pozitie.X - 2, points[2].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[3].pozitie.X - 2, points[3].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[4].pozitie.X - 2, points[4].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[5].pozitie.X - 2, points[5].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[6].pozitie.X - 2, points[6].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[7].pozitie.X - 2, points[7].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[8].pozitie.X - 2, points[8].pozitie.Y - 2, 5, 5);
            grp.DrawEllipse(blackPen, points[9].pozitie.X - 2, points[9].pozitie.Y - 2, 5, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                points[i].vecini.Add(points[i + 1]);
                grp.DrawLine(blackPen, points[i].pozitie, points[i + 1].pozitie);
            }
            points[points.Count-1].vecini.Add(points[0]);

            grp.DrawLine(blackPen, points[points.Count - 1].pozitie, points[0].pozitie);
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pen bluePen = new Pen(Color.Blue);
            bluePen.DashPattern = new float[] { 5, 3.5f };
            List<Punct> puncteIntermediare = new List<Punct>();
            puncteIntermediare.Add(points[0]);
            puncteIntermediare.Add(points[1]);
            for (int i = 2; i < points.Count; i++)
            {
                puncteIntermediare.Add(points[i]);
                float det = Determinant(
                    puncteIntermediare[puncteIntermediare.Count - 1].pozitie,
                    puncteIntermediare[puncteIntermediare.Count - 3].pozitie,
                    puncteIntermediare[puncteIntermediare.Count - 2].pozitie);

                while (det > 0)
                {
                    grp.DrawLine(bluePen,puncteIntermediare[puncteIntermediare.Count - 3].pozitie, puncteIntermediare[puncteIntermediare.Count - 1].pozitie);
                    points[puncteIntermediare.Count - 3].vecini.Add(puncteIntermediare[puncteIntermediare.Count - 1]);
                    pictureBox1.Refresh();

                    puncteIntermediare.RemoveAt(puncteIntermediare.Count - 2);
                    if (puncteIntermediare.Count < 3)
                        break;
                    det = Determinant(puncteIntermediare[puncteIntermediare.Count - 1].pozitie, puncteIntermediare[puncteIntermediare.Count - 3].pozitie, puncteIntermediare[puncteIntermediare.Count - 2].pozitie);
                }
                pictureBox1.Refresh();
            }
            pictureBox1.Image = bmp;
        }

        private float Determinant(PointF p1, PointF p2, PointF p3)
        {
            return (((p1.X * p2.Y) + (p2.X * p3.Y) + (p1.Y * p3.X)) - ((p3.X * p2.Y) + (p3.Y * p1.X) + (p2.X * p1.Y)));
        }

        public Color[] colors = { Color.Red, Color.Blue, Color.Green };

        private void button3_Click(object sender, EventArgs e)
        {
            int[] colorsCount = { 0, 0, 0 };

            points[0].culoare = 0; colorsCount[0]++;
            deseneazaPunct(points[0]);
            points[0].vecini[0].culoare = 1; colorsCount[1]++;
            deseneazaPunct(points[0].vecini[0]);

            for (int i = 1; i < points[0].vecini.Count; i++)
            {
                if (points[0].vecini[i].culoare == -1)
                {
                    int clrIndex = getColorIndex(0, points[0].vecini[i - 1].culoare);
                    points[0].vecini[i].culoare = clrIndex;
                    colorsCount[clrIndex]++;
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].culoare == -1)
                {
                    int clrIndex = getColorIndex(points[i].vecini[0].culoare, points[i].vecini[points[i].vecini.Count - 1].culoare);
                    points[i].culoare = clrIndex;
                    colorsCount[clrIndex]++;
                }
            }
            for (int i = 0; i < points.Count; i++)
                deseneazaPunct(points[i]);
            int minIndex = 0;
            for (int i = 1; i < colorsCount.Length; i++)
                if (colorsCount[i] < colorsCount[minIndex])
                    minIndex = i;
            String[] colorsName = { "Rosu", "Albastru", "Verde" };
            label1.Text = "Culoarea optima " + colorsName[minIndex] + " cu " + colorsCount[minIndex] + " aparitii";
        }

        private int getColorIndex(int colorA, int colorB = -1)
        {
            if (colorB < 0)
                return (colorA + 1) % colors.Length;
            int[] _colors = { 0, 0, 0 };
            _colors[colorA] = 1;
            _colors[colorB] = 1;
            for (int i = 0; i < _colors.Length; i++)
                if (_colors[i] == 0)
                    return i;
            return 0;
        }

        public void deseneazaPunct(Punct p)
        {
            if(p.culoare != -1)
            {
                grp.DrawEllipse(new Pen(colors[p.culoare], 10), p.pozitie.X - 2, p.pozitie.Y - 2, 5, 5);
                pictureBox1.Invalidate();
            }
        }
    }

    public class Punct
    {
        public PointF pozitie;
        public int culoare;
        public List<Punct> vecini;
        public Punct(PointF pos)
        {
            pozitie = pos;
            culoare = -1;
            vecini = new List<Punct>();
        }
    }
}

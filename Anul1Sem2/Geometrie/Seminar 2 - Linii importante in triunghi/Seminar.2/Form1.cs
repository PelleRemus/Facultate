using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PointF A, B, C, G, I, H, D;
        PointF[] triunghi = new PointF[3];
        Random rnd = new Random();
        Graphics grp;
        Bitmap bmp;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen orangePen = new Pen(Color.Orange, 2);
            PointF I = new PointF();
            A = triunghi[0]; B = triunghi[1]; C = triunghi[2];
            float a, b, c;
            a = dist(B, C); b = dist(A, C); c = dist(A, B);

            I.X = (a * A.X + b * B.X + c * C.X) / (a + b + c);
            I.Y = (a * A.Y + b * B.Y + c * C.Y) / (a + b + c);
            grp.DrawEllipse(orangePen, I.X - 3, I.Y - 3, 7, 7);

            grp.DrawLine(orangePen, A.X, A.Y, I.X, I.Y);
            grp.DrawLine(orangePen, B.X, B.Y, I.X, I.Y);
            grp.DrawLine(orangePen, C.X, C.Y, I.X, I.Y);

            PointF M = PunctMediatoare(I, B, C);
            float R = dist(I, M);
            grp.DrawEllipse(orangePen, I.X - R, I.Y - R, 2 * R - 1, 2 * R - 1);
            textBox5.Text += "I(" + I.X + "; " + I.Y + ")";
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            A = triunghi[0];
            B = triunghi[1];
            C = triunghi[2];
            Pen bluePen = new Pen(Color.MediumBlue, 2);

            float PantaA = -(B.Y - C.Y) / (C.X - B.X);
            PointF M = PunctMediatoare(A, B, C);
            grp.DrawLine(bluePen, A.X, A.Y, M.X, M.Y);

            float PantaB = -(C.Y - A.Y) / (A.X - C.X);
            PointF N = PunctMediatoare(B, C, A);
            grp.DrawLine(bluePen, B.X, B.Y, N.X, N.Y);

            PointF P = PunctMediatoare(C, A, B);
            grp.DrawLine(bluePen, C.X, C.Y, P.X, P.Y);

            float Hs = PantaB - PantaA;
            float Hx = (A.X + PantaA * A.Y) * PantaB - (B.X + PantaB * B.Y) * PantaA;
            float Hy = (B.X + PantaB * B.Y) - (A.X + PantaA * A.Y);
            H = new PointF(Hx / Hs, Hy / Hs);
            grp.DrawEllipse(bluePen, H.X - 3, H.Y - 3, 7, 7);

            bluePen.DashPattern = new float[] { 2, 2 };
            grp.DrawLine(bluePen, A, H);
            grp.DrawLine(bluePen, B, H);
            grp.DrawLine(bluePen, C, H);
            textBox4.Text = "H(" + H.X + "; " + H.Y + ")";

            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PointF mA = new PointF((triunghi[1].X + triunghi[2].X) / 2, (triunghi[1].Y + triunghi[2].Y) / 2);
            PointF mB = new PointF((triunghi[0].X + triunghi[2].X) / 2, (triunghi[0].Y + triunghi[2].Y) / 2);
            PointF mC = new PointF((triunghi[0].X + triunghi[1].X) / 2, (triunghi[0].Y + triunghi[1].Y) / 2);
            Pen redPen = new Pen(Color.Red, 2);

            float d = 2 * (triunghi[0].X * (triunghi[1].Y - triunghi[2].Y) + triunghi[1].X * (triunghi[2].Y - triunghi[0].Y) + triunghi[2].X * (triunghi[0].Y - triunghi[1].Y));
            float xs = (triunghi[0].X * triunghi[0].X + triunghi[0].Y * triunghi[0].Y) * (triunghi[1].Y - triunghi[2].Y) + (triunghi[1].X * triunghi[1].X + triunghi[1].Y * triunghi[1].Y) * (triunghi[2].Y - triunghi[0].Y) + (triunghi[2].X * triunghi[2].X + triunghi[2].Y * triunghi[2].Y) * (triunghi[0].Y - triunghi[1].Y);
            float ys = (triunghi[0].X * triunghi[0].X + triunghi[0].Y * triunghi[0].Y) * (triunghi[2].X - triunghi[1].X) + (triunghi[1].X * triunghi[1].X + triunghi[1].Y * triunghi[1].Y) * (triunghi[0].X - triunghi[2].X) + (triunghi[2].X * triunghi[2].X + triunghi[2].Y * triunghi[2].Y) * (triunghi[1].X - triunghi[0].X);

            D = new PointF(xs / d, ys / d);
            float R = dist(D, triunghi[0]);
            grp.DrawEllipse(redPen, D.X - 3, D.Y - 3, 7, 7);
            grp.DrawEllipse(redPen, D.X - R, D.Y - R, 2*R, 2*R);

            grp.DrawLine(redPen, D.X, D.Y, mA.X, mA.Y);
            grp.DrawLine(redPen, D.X, D.Y, mB.X, mB.Y);
            grp.DrawLine(redPen, D.X, D.Y, mC.X, mC.Y);
            textBox3.Text = "D(" + D.X + "; " + D.Y + ")";
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            A = triunghi[0]; B = triunghi[1]; C = triunghi[2];
            textBox6.Text += Aria(A, B, C);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PointF mA = new PointF((triunghi[1].X + triunghi[2].X) / 2, (triunghi[1].Y + triunghi[2].Y) / 2);
            PointF mB = new PointF((triunghi[0].X + triunghi[2].X) / 2, (triunghi[0].Y + triunghi[2].Y) / 2);
            PointF mC = new PointF((triunghi[0].X + triunghi[1].X) / 2, (triunghi[0].Y + triunghi[1].Y) / 2);
            Pen greenPen = new Pen(Color.Green, 2);

            grp.DrawLine(greenPen, triunghi[0], mA);
            grp.DrawLine(greenPen, triunghi[1], mB);
            grp.DrawLine(greenPen, triunghi[2], mC);

            G.X = (triunghi[0].X + triunghi[1].X + triunghi[2].X) / 3;
            G.Y = (triunghi[0].Y + triunghi[1].Y + triunghi[2].Y) / 3;
            grp.DrawEllipse(greenPen, G.X - 3, G.Y - 3, 7, 7);
            textBox2.Text = "G(" + G.X + "; " + G.Y + ")";
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            Pen blackPen = new Pen(Color.Black, 2);

            for (int i = 0; i < 3; i++)
                triunghi[i] = getRndPoint();
            grp.FillPolygon(new SolidBrush(Color.White), triunghi);
            grp.DrawPolygon(blackPen, triunghi);

            A = triunghi[0]; B = triunghi[1]; C = triunghi[2];
            textBox1.Text = "A(" + A.X + "; " + A.Y + "); B(" + B.X + "; " + B.Y + "); C(" + C.X + "; " + C.Y + ")";
            Refresh();
            pictureBox1.Image = bmp;
        }

        public PointF getRndPoint()
        {
            PointF toR = new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));
            return toR;
        }

        public PointF PunctMediatoare(PointF A, PointF B, PointF C)
        {
            float Panta = -(B.Y - C.Y) / (C.X - B.X);
            float Ms = (C.X - B.X) - (B.Y - C.Y) * Panta;
            float Mx = (A.X + Panta * A.Y) * (C.X - B.X) - Panta * (B.Y * C.X - B.X * C.Y);
            float My = (B.Y * C.X - B.X * C.Y) - (A.X + Panta * A.Y) * (B.Y - C.Y);
            PointF M = new PointF(Mx / Ms, My / Ms);
            return M;
        }

        float Aria(PointF A, PointF B, PointF C)
        {
            return (float)Math.Abs(A.X * B.Y + A.Y * C.X + B.X * C.Y - B.Y * C.X - A.Y * B.X - A.X * C.Y) / 2;
        }

        float dist(PointF A, PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }
}

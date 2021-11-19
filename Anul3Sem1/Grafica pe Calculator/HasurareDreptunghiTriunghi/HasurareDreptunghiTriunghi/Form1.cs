using System;
using System.Drawing;
using System.Windows.Forms;

namespace HasurareDreptunghiTriunghi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }
        
        Bitmap bmp;
        Graphics grp;
        Color culoare = Color.Blue;

        int cm = 38;

        private void HasurarePatrat_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)(float.Parse(XPatrat.Text) * cm);
                int y = (int)(float.Parse(YPatrat.Text) * cm);
                int l = (int)(float.Parse(Latura.Text) * cm);
                Patrat(x, y, l);
            }
            catch
            {
                MessageBox.Show("Valorile introduse nu sunt corecte");
            }
        }

        void Patrat(int x, int y, int latura)
        {
            while (latura > 0)
            {
                for (int i = 0; i < latura; i++)
                    grp.DrawEllipse(new Pen(culoare), x++, y, 1, 1);
                for (int i = 0; i < latura; i++)
                    grp.DrawEllipse(new Pen(culoare), x, y++, 1, 1);
                for (int i = 0; i < latura; i++)
                    grp.DrawEllipse(new Pen(culoare), x--, y, 1, 1);
                for (int i = 0; i < latura; i++)
                    grp.DrawEllipse(new Pen(culoare), x, y--, 1, 1);

                x++; y++; latura -= 1;
            }
            pictureBox1.Image = bmp;
        }

        private void HasurareDreptunghi_Click(object sender, EventArgs e)
        {
            try
            {
                int x = (int)(float.Parse(XDreptunghi.Text) * cm);
                int y = (int)(float.Parse(YDreptunghi.Text) * cm);
                int L = (int)(float.Parse(Lungime.Text) * cm);
                int l = (int)(float.Parse(latime.Text) * cm);
                Dreptunghi(x, y, L, l);
            }
            catch
            {
                MessageBox.Show("Valorile introduse nu sunt corecte");
            }
        }

        void Dreptunghi(int x, int y, int lungime, int latime)
        {
            while (lungime > 0 && latime > 0)
            {
                for (int i = 0; i < lungime; i++)
                    grp.DrawEllipse(new Pen(culoare), x++, y, 1, 1);
                for (int i = 0; i < latime; i++)
                    grp.DrawEllipse(new Pen(culoare), x, y++, 1, 1);
                for (int i = 0; i < lungime; i++)
                    grp.DrawEllipse(new Pen(culoare), x--, y, 1, 1);
                for (int i = 0; i < latime; i++)
                    grp.DrawEllipse(new Pen(culoare), x, y--, 1, 1);

                x++; y++; lungime -= 1; latime -= 1;
            }
            pictureBox1.Image = bmp;
        }

        private void HasurareTriunghi_Click(object sender, EventArgs e)
        {
            try
            {
                int xA = (int)(float.Parse(XA.Text) * cm);
                int yA = (int)(float.Parse(YA.Text) * cm);
                int xB = (int)(float.Parse(XB.Text) * cm);
                int yB = (int)(float.Parse(YB.Text) * cm);
                int xC = (int)(float.Parse(XC.Text) * cm);
                int yC = (int)(float.Parse(YC.Text) * cm);
                Triunghi(xA, yA, xB, yB, xC, yC);
            }
            catch
            {
                MessageBox.Show("Valorile introduse nu sunt corecte");
            }
        }

        void Triunghi(int xA, int yA, int xB, int yB, int xC, int yC)
        {
            while (Distanta(xA, yA, xB, yB) + Distanta(xA, yA, xC, yC) - Distanta(xB, yB, xC, yC) > 0.001)
            {
                MidPointLine(xA, yA, xB, yB);
                MidPointLine(xA, yA, xC, yC);
                MidPointLine(xB, yB, xC, yC);

                if (Distanta(xA, yA, xB, yB) + Distanta(xA, yA, xC, yC) > Distanta(xA + 1, yA, xB, yB) + Distanta(xA + 1, yA, xC, yC))
                    xA++;
                else
                    xA--;
                if (Distanta(xA, yA, xB, yB) + Distanta(xA, yA, xC, yC) > Distanta(xA, yA + 1, xB, yB) + Distanta(xA, yA + 1, xC, yC))
                    yA++;
                else
                    yA--;
            }
        }

        void MidPointLine(int x0, int y0, int x1, int y1)
        {
            int distX = Math.Abs(x1 - x0),
                semnX = x0 < x1 ? 1 : -1,
                distY = Math.Abs(y1 - y0),
                semnY = y0 < y1 ? 1 : -1,
                err = distX > distY ? distX / 2 : -distY / 2,
                x = x0, y = y0;

            while (x != x1 || y != y1)
            {
                grp.DrawEllipse(new Pen(culoare), x, y, 1, 1);
                int aux = err;

                if (aux > -distX)
                {
                    err -= distY;
                    x += semnX;
                }
                if (aux < distY)
                {
                    err += distX;
                    y += semnY;
                }
            }
            pictureBox1.Image = bmp;
        }

        double Distanta(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
        }

        private void Stergere_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
        }
    }
}

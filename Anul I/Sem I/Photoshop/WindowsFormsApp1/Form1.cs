using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        Graphics grp;
        Bitmap sursa;
        Bitmap destinatie;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sursa = new Bitmap(@"..\..\Resurse\Puii Mei.jpg");
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            pictureBox1.Image = sursa;
        }


        public void BW()
        {
            for (int i=0; i < sursa.Width; i++)
                for (int j=0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int t = (Get.R + Get.G + Get.B) / 3;
                    if (t < 128)
                        Set = Color.FromArgb(0, 0, 0);
                    else
                        Set = Color.FromArgb(255, 255, 255);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void GS()
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int t = (Get.R + Get.G + Get.B) / 3;
                    Set = Color.FromArgb(t, t, t);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Compl()
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int rp = Get.R;
                    int gp = Get.G;
                    int bp = Get.B;
                    Set = Color.FromArgb(255 - rp, 255 - gp, 255 - bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void RS()
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    Set = Color.FromArgb(Get.R, 0, 0);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Light(int k)
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int rp = Get.R + k;
                    if (rp > 255) rp = 255;
                    int gp = Get.G + k;
                    if (gp > 255) gp = 255;
                    int bp = Get.B + k;
                    if (bp > 255) bp = 255;
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Dark(int k)
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int rp = Get.R - k;
                    if (rp < 0) rp = 0;
                    int gp = Get.G - k;
                    if (gp < 0) gp = 0;
                    int bp = Get.B - k;
                    if (bp < 0) bp = 0;
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Contrast(int k)
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int t = (Get.R + Get.G + Get.B) / 3;
                    int rp, gp, bp;
                    if (t < 128)
                    {
                        rp = Get.R - k;
                        if (rp < 0) rp = 0;
                        gp = Get.G - k;
                        if (gp < 0) gp = 0;
                        bp = Get.B - k;
                        if (bp < 0) bp = 0;
                    }   
                    else
                    {
                        rp = Get.R + k;
                        if (rp > 255) rp = 255;
                        gp = Get.G + k;
                        if (gp > 255) gp = 255;
                        bp = Get.B + k;
                        if (bp > 255) bp = 255;
                    }
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void UK(int k)
        {
            for (int i = 0; i < sursa.Width; i++)
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Get = sursa.GetPixel(i, j);
                    Color Set;
                    int rp = (Get.R + k) % 255;
                    int gp = (Get.G + k) % 255;
                    int bp = (Get.B + k) % 255;
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Blurr()
        {
            for (int i = 1; i < sursa.Width-1; i++)
                for (int j = 1; j < sursa.Height-1; j++)
                {
                    Color Set;
                    int rp = 0;
                    int gp = 0;
                    int bp = 0;
                    for (int k=-1; k<=1; k++)
                        for (int l=-1; l<=1; l++)
                        {
                            Color tmp = sursa.GetPixel(i + k, j + l);
                            rp += tmp.R;
                            gp += tmp.G;
                            bp += tmp.B;
                        }
                    rp /= 9;
                    gp /= 9;
                    bp /= 9;
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Blurr3()
        {
            for (int i = 3; i < sursa.Width - 3; i++)
                for (int j = 3; j < sursa.Height - 3; j++)
                {
                    Color Set;
                    int rp = 0;
                    int gp = 0;
                    int bp = 0;
                    for (int k = -3; k <= 3; k++)
                        for (int l = -3; l <= 3; l++)
                        {
                            Color tmp = sursa.GetPixel(i + k, j + l);
                            rp += tmp.R;
                            gp += tmp.G;
                            bp += tmp.B;
                        }
                    rp /= 49;
                    gp /= 49;
                    bp /= 49;
                    Set = Color.FromArgb(rp, gp, bp);
                    destinatie.SetPixel(i, j, Set);
                }
            pictureBox2.Image = destinatie;
        }

        public void Fulgi()
        {
            for (int i=0; i<sursa.Width; i++)
                for (int j=0; j<sursa.Height; j++)
                    destinatie.SetPixel(i, j, sursa.GetPixel(i, j));

            for (int i=0; i<500; i++)
            {
                int x = rnd.Next(sursa.Width);
                int y = rnd.Next(sursa.Height);
                int s = rnd.Next(100, 500);
                for (int j=0; j<s; j++)
                {
                    int rp = rnd.Next(50);
                    int gp = rnd.Next(50);
                    int bp = rnd.Next(50);
                    float r = (float)(rnd.NextDouble() * 20);
                    float alfa=(float)(rnd.NextDouble()*(Math.PI*2));
                    float lx = (float)(x + r * Math.Cos(alfa));
                    float ly = (float)(y + r * Math.Sin(alfa));
                    if (lx >= 0 && ly > 0 && lx < sursa.Width && ly < sursa.Height)
                    {
                        Color t = sursa.GetPixel((int)lx, (int)ly);
                        int pr = t.R + rp;
                        if (pr > 255) pr = 255;
                        int pg = t.G + gp;
                        if (pg > 255) pg = 255;
                        int pb = t.B + bp;
                        if (pb > 255) pb = 255;
                        destinatie.SetPixel((int)lx, (int)ly, Color.FromArgb(pr, pg, pb));
                    }
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BW();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GS();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Compl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RS();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Light(trackBar1.Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dark(trackBar1.Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Contrast(trackBar1.Value);
        }

        int Value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Value += 5;
            UK(Value);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Blurr();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Blurr3();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Fulgi();
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TransferDeCaldura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(this);
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics grp = Graphics.FromImage(bmp);

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Rectangle(0, 0, 20, 125),
                Color.FromArgb(255, 0, 0),
                Color.FromArgb(250, 250, 0),
                90f );
            grp.FillRectangle(linGrBrush, 0, 0, 20, 125);

            linGrBrush = new LinearGradientBrush(
                new Rectangle(0, 0, 20, 125),
                Color.FromArgb(250, 250, 0),
                Color.FromArgb(0, 250, 0),
                90f);
            grp.FillRectangle(linGrBrush, 0, 125, 20, 250);

            linGrBrush = new LinearGradientBrush(
                new Rectangle(0, 0, 20, 125),
                Color.FromArgb(0, 250, 0),
                Color.FromArgb(0, 250, 250),
                90f);
            grp.FillRectangle(linGrBrush, 0, 250, 20, 375);

            linGrBrush = new LinearGradientBrush(
                new Rectangle(0, 0, 20, 125),
                Color.FromArgb(0, 250, 250),
                Color.FromArgb(0, 0, 250),
                90f);
            grp.FillRectangle(linGrBrush, 0, 375, 20, 500);
            pictureBox2.Image = bmp;
        }

        private void NextStep_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Engine.iterations; i++)
                Engine.Step();
            Engine.Afisare();
        }
        private void Toggle_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Engine.iterations; i++)
                Engine.Step();
            Engine.Afisare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.state = 0;
            Engine.InitialValues();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Engine.state = 1;
            Engine.InitialValues();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Engine.state = 2;
            Engine.InitialValues();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Engine.state = 3;
            Engine.InitialValues();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox1.Text);
                if (i > 0)
                    Engine.iterations = i;
            }
            catch
            {
                MessageBox.Show("Please insert a valid number!", "Error");
            }
        }
    }
}

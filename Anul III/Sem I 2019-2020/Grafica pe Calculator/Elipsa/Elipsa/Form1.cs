using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elipsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(pictureBox1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Engine.r1 = int.Parse(textBox1.Text);
                Engine.r2 = int.Parse(textBox2.Text);
                timer1.Interval = int.Parse(textBox4.Text);
                Engine.InitValues();
                Engine.DrawSketch(new Point(e.X, e.Y));
            }
            catch
            {
                MessageBox.Show("Please insert valid numbers.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Step();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Step();
        }
    }
}

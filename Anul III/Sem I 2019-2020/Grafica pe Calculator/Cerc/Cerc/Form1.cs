using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerc
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
                Engine.r = int.Parse(textBox1.Text);
                timer1.Interval = int.Parse(textBox3.Text);
                Engine.k = 0;
                Engine.theta = Math.PI / (4 * Engine.n);
                Engine.DrawSketch(new Point(e.X, e.Y));
                Engine.InitValues();
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

using System;
using System.Windows.Forms;

namespace VisualFredkin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(this, pictureBox1);
        }

        private void NextStep_Click(object sender, EventArgs e)
        {
            Engine.Step();
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Step();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int aux = int.Parse(textBox1.Text);
                if (aux == 0)
                    throw new Exception();
                Engine.t = aux + 1;
            }
            catch
            {
                MessageBox.Show("Please insert a valid number.");
            }
        }

        private void collor1_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(1, Engine.colors[1]);
            Colors myColors = new Colors();
        }
        private void collor2_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(2, Engine.colors[2]);
            Colors myColors = new Colors();
        }
        private void collor3_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(3, Engine.colors[3]);
            Colors myColors = new Colors();
        }
        private void collor4_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(4, Engine.colors[4]);
            Colors myColors = new Colors();
        }
        private void collor5_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(5, Engine.colors[5]);
            Colors myColors = new Colors();
        }
        private void collor6_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(6, Engine.colors[6]);
            Colors myColors = new Colors();
        }
        private void collor7_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(7, Engine.colors[7]);
            Colors myColors = new Colors();
        }
        private void collor8_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(8, Engine.colors[8]);
            Colors myColors = new Colors();
        }
        private void collor9_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(9, Engine.colors[9]);
            Colors myColors = new Colors();
        }
    }
}

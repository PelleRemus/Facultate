using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaDemo
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Engine.zoomX.ToString();
            textBox2.Text = Engine.zoomY.ToString();
            panel1.BackColor = Engine.backColor;
        }

        public void Save()
        {
            Engine.zoomX = int.Parse(textBox1.Text);
            Engine.zoomY = int.Parse(textBox2.Text);
            Engine.backColor = panel1.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "1";
            panel1.BackColor = Color.FromArgb(20, 20, 50);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panel1.BackColor = colorDialog1.Color;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1);
            Engine.DrawMap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.t.Move();
            listBox1.Items.Add(Engine.t.path.Count());
            Engine.DrawMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

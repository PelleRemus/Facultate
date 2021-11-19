using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceas_Digital
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
            Engine.minute++;
            if (Engine.minute == 60)
            {
                Engine.minute = 0;
                Engine.ora++;
            }
            if (Engine.ora == 12)
                Engine.ora = 0;
            Engine.DrawMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string s = textBox1.Text;
            Engine.ora = int.Parse(s.Split(':')[0]);
            Engine.minute = int.Parse(s.Split(':')[1]);
            Engine.DrawMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafCosturiDesen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < Engine.K; i++)
                listBox1.Items.Add(Engine.par[i].View());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 100; i++)
                Engine.Do();
            for (int i = 0; i < Engine.K; i++)
                listBox1.Items.Add(Engine.par[i].View());
        }
    }
}

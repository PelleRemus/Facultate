using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            load(Engine.index);
        }

        public void load(int index)
        {
            label1.Text = (index + 1) + "/" + Engine.help.Count;
            listBox1.Items.Clear();
            foreach (string s in Engine.help[index].help)
            {
                listBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.index++;
            if (Engine.index >= Engine.help.Count)
                Engine.index = Engine.help.Count - 1;
            load(Engine.index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Engine.index--;
            if (Engine.index < 0)
                Engine.index = 0;
            load(Engine.index);
        }
    }
}

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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
            this.Close();
        }

        public void Get()
        {
            numericUpDown1.Value = Settings.thumbW;
            numericUpDown2.Value = Settings.thumbH;
        }

        public void Set()
        {
            Settings.thumbW = (int)numericUpDown1.Value;
            Settings.thumbH = (int)numericUpDown2.Value;
        }

    }
}

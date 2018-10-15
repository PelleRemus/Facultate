using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    public partial class Ctrl : UserControl
    {
        string f;

        public Ctrl(string f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void Ctrl_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            Image i= Image.FromFile(f);
            pictureBox1.Image = i;
            string[] s = f.Split('\\');
            label1.Text = s[s.Length - 1] + i.Width + "x" + i.Height;
        }

        private void Ctrl_Click(object sender, EventArgs e)
        {
            Engine.transfer = f;
            Zoom t = new Zoom();
            t.ShowDialog();
        }
    }
}

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
            this.Width = Settings.thumbW;
            this.Height = Settings.thumbH;
            pictureBox1.Size = new Size(Settings.thumbW, Settings.thumbH - 30);
            label1.Size = new Size(Settings.thumbW, 30);
            label1.Location = new Point(0, Settings.thumbH - 30);
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

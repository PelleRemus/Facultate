using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.Default();
            Engine.LoadFromFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.files = Directory.GetFiles(@"D:\\Imagini\");
            foreach (string f in Engine.files)
            {
                listBox1.Items.Add(f);
            }

            Engine.thumbs = new List<Ctrl>();
            int line = 0;
            int col = 0;
            foreach(string f in Engine.files)
            {
                Ctrl t = new Ctrl(f);
                int dw = Settings.thumbW;
                int dh = Settings.thumbH;
                t.Location = new Point(5 + col * (dw + 2), 5 + line * (dh + 2));
                col++;
                if (col == 3)
                {
                    line++;
                    col = 0;
                }
                t.Parent = panel1;
                Engine.thumbs.Add(t);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Options MyOptions = new Options();
            MyOptions.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help MyHelp = new Help();
            MyHelp.ShowDialog();
        }
    }
}

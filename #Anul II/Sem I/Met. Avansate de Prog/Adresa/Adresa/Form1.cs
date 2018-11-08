using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adresa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init();
            t = new Display[Engine.adrese.Count];
        }

        Display[] t;

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int top = 5;
            foreach(Adresa a in Engine.adrese)
            {
                t[i] = new Display(a);
                t[i].Parent = panel1;
                t[i].Location = new Point(5, top);

                top += t[i].Height + 5;
                i++;
            }
        }
    }
}

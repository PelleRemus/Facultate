using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruskall_Algorythm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Load();
            Engine.View(listBox1);
            Engine.EdgeSort();
            listBox1.Items.Add("");
            Engine.EdgeView(listBox1);
            listBox1.Items.Add("");
            Engine.ArborePartialCostMinim(listBox1);
        }
    }
}

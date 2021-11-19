using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorareaHartii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraf(pictureBox1);
            Engine.Load();
            Engine.InitMap();
            Engine.BFS(listBox1);
            Engine.DrawMap();

            string s = "";
            for (int i = 0; i < Engine.n; i++)
                s += Engine.colors[i] + " ";
            listBox1.Items.Add(s);
        }


    }
}

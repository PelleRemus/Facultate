using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarGameEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.display = pictureBox1;
            Engine.InitGame();
            Engine.InitGraf();
            Engine.DrawMap();
            pictureBox1.Image = Engine.bmp;
        }
    }
}

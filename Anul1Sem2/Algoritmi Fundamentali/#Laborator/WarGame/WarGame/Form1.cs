using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarGame
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
            Engine.InitGraf();
            Engine.InitGame();
            Engine.DrawMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Engine.army1.Count != 0 && Engine.army2.Count != 0)
            {
                Engine.grp.Clear(Engine.backColor);
                Engine.War();
                Engine.DrawMap();
            }
            else
            {
                MessageBox.Show("Game Over");
            }
            pictureBox1.Image = Engine.bmp;
        }
    }
}

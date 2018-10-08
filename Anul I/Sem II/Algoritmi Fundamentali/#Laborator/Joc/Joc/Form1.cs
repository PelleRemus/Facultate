using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc
{
    public partial class Form1 : Form
    {
        PointF destination = new PointF(800, 450);
        Image img;

        public Form1()
        {
            InitializeComponent();
            img = Image.FromFile(@"../../Resurse/Nut.jpg");
            timer1.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            destination = new PointF(e.X, e.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Nut n = new Nut(destination, img, this);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

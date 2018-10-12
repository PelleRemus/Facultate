using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsiO_30x30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Buton[,] btn;
        int n = 30;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init();
            btn = new Buton[n, n];
            int bw = panel1.Width / 30;
            int bh = panel1.Height / 30;

            for (int i=0; i<n; i++)
                for(int j=0; j<n; j++)
                {
                    btn[i, j] = new Buton();
                    btn[i, j].Parent = panel1;
                    btn[i, j].Size = new Size(bw, bh);
                    btn[i, j].Location = new Point(i * bw, j * bh);
                    btn[i, j].BackColor = Color.Transparent;
                    btn[i, j].linie = i;
                    btn[i, j].coloana = j;
                    btn[i, j].Click += btn_Click;
                }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int l = (sender as Buton).linie;
            int c = (sender as Buton).coloana;

            if(Engine.crtPlayer==0)
            {
                (sender as Buton).BackColor = Color.Black;
                Engine.m[l, c] = 1;
                Engine.crtPlayer = 1;
            }
            else
            {
                (sender as Buton).BackColor = Color.White;
                Engine.m[l, c] = 10;
                Engine.crtPlayer = 0;
            }

            (sender as Buton).Enabled = false;
            if (Engine.IsGameOver() == true)
            {
                panel1.Enabled = false;
                MessageBox.Show("Player " + ((Engine.crtPlayer + 1) % 2 + 1) + " has Won!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Init();
            panel1.Enabled = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    btn[i, j].BackColor = Color.Transparent;
                    Engine.m[i, j] = 0;
                    btn[i, j].Enabled = true;
                }
        }
    }
}

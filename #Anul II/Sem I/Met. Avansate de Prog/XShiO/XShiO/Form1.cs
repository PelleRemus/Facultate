using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XShiO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IButton[,] btn;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.initGame();
            panel1.BackColor = Color.PeachPuff;
            float dw = (float)panel1.Width / (float)34;
            float dh = (float)panel1.Height / (float)34;

            btn = new IButton[3, 3];
            for(int i=0; i<3; i++)
                for(int j=0; j<3; j++)
                {
                    btn[i, j] = new IButton();
                    btn[i, j].Parent = panel1;
                    btn[i, j].Size = new Size((int)dw * 10, (int)dh * 10);
                    btn[i, j].Location = new Point((int)(dw + i * dw * 11), (int)(dh + j * dh * 11));
                    btn[i, j].Click += btn_Click;
                    btn[i, j].line = j;
                    btn[i, j].col = i;
                    btn[i, j].Font = new Font("Arial", dh*5 - 5, FontStyle.Bold);
                }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int l = (sender as IButton).line;
            int c = (sender as IButton).col;

            if (Engine.crtPlayer==0)
            {
                Engine.m[l, c] = 1;
                (sender as IButton).Text = "X";
                Engine.crtPlayer = 1;
            }
            else
            {
                Engine.m[l, c] = 10;
                (sender as IButton).Text = "O";
                Engine.crtPlayer = 0;
            }

            (sender as IButton).Enabled = false;
            if(Engine.isGameOver()==true)
            {
                panel1.Enabled = false;
                MessageBox.Show("Player " + ((Engine.crtPlayer + 1) % 2 + 1) + " has Won!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.initGame();
            panel1.Enabled = true;
            for(int i=0; i<3; i++)
                for (int j = 0; j < 3; j++)
                {
                    btn[i, j].Text = string.Empty;
                    Engine.m[i, j] = 0;
                    btn[i, j].Enabled = true;
                }
        }
    }
}

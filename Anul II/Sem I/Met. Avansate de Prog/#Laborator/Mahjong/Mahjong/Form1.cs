using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mahjong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(panel1);
            Engine.labels = new MyLabel[Engine.n, Engine.m];
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                {
                    Engine.labels[i, j] = new MyLabel();
                    Engine.labels[i, j].AutoSize = false;
                    Engine.labels[i, j].Size = new Size((int)Engine.dw, (int)Engine.dh);
                    Engine.labels[i, j].Location = new Point((int)(i * Engine.dw), (int)(j * Engine.dh));

                    Engine.labels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Engine.labels[i, j].Text = Engine.matrix[i, j].ToString();
                    Engine.labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    Engine.labels[i, j].Font = new Font("Arial", 21, FontStyle.Bold);
                    Engine.labels[i, j].Parent = panel1;

                    Engine.labels[i, j].linie = i;
                    Engine.labels[i, j].col = j;
                    Engine.labels[i, j].Click += label_Click;
                }
            Engine.Shuffle();
            Afisare();
        }

        MyLabel l1, l2;

        private void label_Click(object sender, EventArgs e)
        {
            MyLabel t = sender as MyLabel;
            if (t.isfree)
            {
                if (l1 == null)
                    l1 = t;
                else
                {
                    l2 = t;
                    if (l1.Text == l2.Text)
                    {
                        l1.Visible = false;
                        l2.Visible = false;

                        if (l1.linie - 1 >= 0)
                            if (Engine.labels[l1.linie - 1, l1.col] != null)
                                Engine.labels[l1.linie - 1, l1.col].isfree = true;
                        if (l2.linie - 1 >= 0)
                            if (Engine.labels[l2.linie - 1, l2.col] != null)
                                Engine.labels[l2.linie - 1, l2.col].isfree = true;
                        if (l1.linie + 1 < Engine.n)
                            if (Engine.labels[l1.linie + 1, l1.col] != null)
                                Engine.labels[l1.linie + 1, l1.col].isfree = true;
                        if (l2.linie + 1 < Engine.n)
                            if (Engine.labels[l2.linie + 1, l2.col] != null)
                                Engine.labels[l2.linie + 1, l2.col].isfree = true;

                        l1 = null;
                        l2 = null;
                    }
                    else
                    {
                        l1 = null;
                        l2 = null;
                    }
                }
                Afisare();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Shuffle();
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                    Engine.labels[i, j].Visible = true;
            Afisare();
        }

        void Afisare()
        {
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                {
                    if (Engine.labels[i, j].isfree)
                        Engine.labels[i, j].BackColor = Color.Green;
                    else
                        Engine.labels[i, j].BackColor = Color.PeachPuff;
                    Engine.labels[i, j].Text = Engine.matrix[i, j].ToString();
                }
        }
    }
}

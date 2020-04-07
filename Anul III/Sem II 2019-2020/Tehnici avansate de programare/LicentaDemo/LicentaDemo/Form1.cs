using System;
using System.Drawing;
using System.Windows.Forms;

namespace LicentaDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGraph(pictureBox1);
            Engine.InitDemo();
            Engine.Load(@"..\..\Resources\Maps\demo_map.map", @"..\..\Resources\Fleets\Fleet.txt");
            Engine.DrawMap();
            Engine.RefreshMap();
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.SelectNextPlayer();
            refresh();
        }

        FleetDisplay[] T;
        public void refresh()
        {
            textBox1.Text = Engine.crtPlayer.name;
            panel2.BackColor = Engine.crtPlayer.fillColor;
            panel3.Controls.Clear();
            T = new FleetDisplay[Engine.crtPlayer.fleets.Count];
            for(int i=0; i<Engine.crtPlayer.fleets.Count; i++)
            {
                T[i] = new FleetDisplay(Engine.crtPlayer.fleets[i]);
                T[i].Location = new Point(2, T[i].Height * i + 2);
                T[i].Parent = panel3;
                T[i].isFighting = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(15, 14);
            Engine.SpawnRes(10, 10, 3, 10, 10);
            Engine.SpawnRes(5, 5, 3, 10, 10);
            Engine.SpawnRes(10, 10, 4, 100, 10);
            Engine.SpawnRes(10, 10, 3, 10, 10);
            Engine.initGraph(pictureBox1);

            Robot tester = new Explorer();
            tester.startLocation = new Point(2, 2);
            tester.targetLocation = new Point(12, 5);
            tester.MoveToTarget();
            Engine.robots.Add(tester);
            Engine.DrawMap();

            foreach (string s in tester.messages)
                listBox1.Items.Add(s);

            foreach(Point p in tester.path)
            {
                listBox1.Items.Add(p.ToString());
            }

            listBox1.Items.Add("");
            foreach (string s in tester.View())
            {
                listBox1.Items.Add(s);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Engine.robots[0].Move();
            (Engine.robots[0] as Explorer).Scan();
            Engine.DrawMap();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

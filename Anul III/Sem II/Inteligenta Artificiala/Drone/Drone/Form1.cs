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
            Engine.DrawMap();

            Robot tester = new Robot();
            tester.startLocation = new Point(2, 2);
            tester.targetLocation = new Point(12, 12);
            tester.MoveToTarget();
            
            foreach(string s in tester.View())
            {
                listBox1.Items.Add(s);
            }
        }
    }
}

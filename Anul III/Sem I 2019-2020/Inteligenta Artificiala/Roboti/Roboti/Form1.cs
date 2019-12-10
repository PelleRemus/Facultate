using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1);
            List<Point> path = Utils.FindPath(Engine.map, new Point(0, 0), new Point(Engine.n - 1, Engine.m - 1));
            List<string> matrix = Engine.ShowMatrix(Engine.map);
            for (int i = 0; i < matrix.Count; i++)
                listBox1.Items.Add(matrix[i]);
            if (path != null) 
                for (int i = 0; i < path.Count; i++)
                    listBox1.Items.Add(path[i] + ": " + Engine.map[path[i].X, path[i].Y]);
        }
    }
}

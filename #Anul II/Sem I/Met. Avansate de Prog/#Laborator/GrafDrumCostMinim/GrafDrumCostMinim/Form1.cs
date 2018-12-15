using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GrafDrumCostMinim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pentru a vedea tot graful, pictureBox1 are nevoie de
            //minim 300 width si minim 200 height
            Grafica.InitPoints(pictureBox1);
            Grafica.InitLines();

            Grafica.DrawLines();
            Grafica.DrawPoints();

            //pentru listBox1, minim 300 width si fontul Consolas
            Grafica.AfisareMatrice(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //daca textBox1 nu contine doar un numar intre 1 si 9 inclusiv,
                //nu vom avea eroare la cod, ci vom primi mesajul din catch
                int nodS = int.Parse(textBox1.Text);
                string result = Engine.BFS(nodS - 1);
                listBox1.Items.Add(result);
            }
            catch
            {
                MessageBox.Show("Please insert a valid number.");
            }
        }
    }
}

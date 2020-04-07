using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaDemo
{
    public partial class FightForm : Form
    {
        List<Fleet> A, B;
        FleetDisplay[] ADisplay, BDisplay;

        public FightForm(List<Fleet> A, List<Fleet> B)
        {
            InitializeComponent();
            this.A = A;
            this.B = B;
            refresh();
        }

        public void refresh()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            ADisplay = new FleetDisplay[A.Count];
            BDisplay = new FleetDisplay[B.Count];

            for(int i = 0; i<A.Count; i++)
            {
                ADisplay[i] = new FleetDisplay(A[i]);
                ADisplay[i].Location = new Point(5, 5 + i * ADisplay[i].Height);
                ADisplay[i].Parent = panel1;
                ADisplay[i].isFighting = true;
                ADisplay[i].refresh();
            }
            for (int i = 0; i < B.Count; i++)
            {
                BDisplay[i] = new FleetDisplay(B[i]);
                BDisplay[i].Location = new Point(5, 5 + i * BDisplay[i].Height);
                BDisplay[i].Parent = panel2;
                BDisplay[i].isFighting = true;
                BDisplay[i].refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Battle(A, B);
            refresh();
        }
    }
}

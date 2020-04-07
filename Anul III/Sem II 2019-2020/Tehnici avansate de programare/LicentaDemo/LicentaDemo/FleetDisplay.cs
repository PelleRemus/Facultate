using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaDemo
{
    public partial class FleetDisplay : UserControl
    {
        public Fleet toBound;
        public bool isFighting;

        public FleetDisplay(Fleet toBound)
        {
            InitializeComponent();
            this.toBound = toBound;
            bool ok = false;
            foreach(Fleet fleet in toBound.planet.fleets)
            {
                if (fleet.owner != toBound.owner)
                    ok = true;
            }
            button1.Enabled = ok;
            isFighting = false;
        }

        private void FleetDisplay_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            textBox1.Text = toBound.name + " " + toBound.ships.Count;
            if(isFighting)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Fleet> A = new List<Fleet>();
            List<Fleet> B = new List<Fleet>();

            foreach(Fleet fleet in toBound.planet.fleets)
            {
                if (fleet.owner == toBound.owner)
                    A.Add(fleet);
                else
                    B.Add(fleet);
            }

            FightForm myFightForm = new FightForm(A, B);
            myFightForm.ShowDialog();
        }
    }
}

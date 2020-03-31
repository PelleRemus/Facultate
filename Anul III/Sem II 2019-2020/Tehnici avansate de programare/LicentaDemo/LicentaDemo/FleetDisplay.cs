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

        public FleetDisplay(Fleet toBound)
        {
            InitializeComponent();
            this.toBound = toBound;
        }

        private void FleetDisplay_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            textBox1.Text = toBound.name + " " + toBound.ships.Count;
        }
    }
}

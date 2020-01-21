using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualFredkin
{
    public partial class Colors : Form
    {
        public Colors()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                {
                    Engine.buttons[i, j].Parent = pictureBox1;
                    Engine.buttons[i, j].Size = new Size(25, 25);
                    Engine.buttons[i, j].Location = new Point(i * 25, j * 25);
                    Engine.buttons[i, j].Click += Colors_Click;
                }
            ShowDialog();
        }

        private void Colors_Click(object sender, EventArgs e)
        {
            Engine.selectedColor = (sender as Button).BackColor;
            Confirm.BackColor = Engine.selectedColor;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            Engine.ChangeColor(Engine.selectedIndex, Engine.selectedColor);
            Close();
        }
    }
}

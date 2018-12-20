using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Difficulty : Form
    {
        Color blue = Color.FromArgb(110, 150, 210);

        public Difficulty()
        {
            InitializeComponent();
            Easy.BackColor = Color.White;
            Medium.BackColor = Color.White;
            Hard.BackColor = Color.White;
        }

        private void Easy_Click(object sender, EventArgs e)
        {
            Easy.BackColor = blue;
            Medium.BackColor = Color.White;
            Hard.BackColor = Color.White;
            Resources.percent = 10;
            Engine.diff.Text = "Easy";
            Engine.wantsNewGame = true;
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            Easy.BackColor = Color.White;
            Medium.BackColor = blue;
            Hard.BackColor = Color.White;
            Resources.percent = 7;
            Engine.diff.Text = "Medium";
            Engine.wantsNewGame = true;
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            Easy.BackColor = Color.White;
            Medium.BackColor = Color.White;
            Hard.BackColor = blue;
            Resources.percent = 5;
            Engine.diff.Text = "Hard";
            Engine.wantsNewGame = true;
        }
    }
}

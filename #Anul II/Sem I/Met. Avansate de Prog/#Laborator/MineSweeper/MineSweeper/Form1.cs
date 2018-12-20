using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGame(pictureBox1, label2);
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.ShowDialog();
            Engine.StartNewGame();
        }
    }
}

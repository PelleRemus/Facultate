using System.Windows.Forms;

namespace MarioGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AutoScroll = true;
            Engine.InitGame(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                Mario.left = true;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                Mario.right = true;
            if (!Mario.jump && (e.KeyCode == Keys.Up || e.KeyCode == Keys.W))
            {
                Mario.jump = true;
                Mario.force = Mario.jumpspeed;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                Mario.left = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                Mario.right = false;
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    internal class Block: PictureBox
    {
        internal string value;
        internal int line, col;

        internal Block(int i, int j)
        {
            line = i; col = j;
            Size = new Size(Engine.x, Engine.x);
            Location = new Point(i * (Engine.x + 3), j * (Engine.x + 3));
            Parent = Engine.display;
            Font = new Font("Arial", 15, FontStyle.Bold);
            BackColor = Color.White;
            Image = Resources.defaultImage;
            SizeMode = PictureBoxSizeMode.Zoom;
            Cursor = Cursors.Hand;
            MouseClick += Engine.Block_MouseClick;
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace MarioGame
{
    internal class Block
    {
        internal PictureBox block;

        internal Block(Point p, string s)
        {
            block = new PictureBox();
            block.Parent = Engine.form;
            block.Size = new Size(Engine.x, Engine.x);
            block.Left = p.X; block.Top = p.Y;
            block.Tag = "block";
            block.Name = s;
            switch (s)
            {
                case "land":
                    {
                        block.BackColor = Color.SaddleBrown;
                        break;
                    }
                case "brick":
                    {
                        block.BackColor = Color.OrangeRed;
                        break;
                    }
                case "questionMark":
                    {
                        block.BackColor = Color.Yellow;
                        break;
                    }
                case "disabledQ":
                    {
                        block.BackColor = Color.Brown;
                        break;
                    }
                case "pipe":
                    {
                        block.BackColor = Color.FromArgb(10, 230, 25);
                        break;
                    }
                case "flag":
                    {
                        block.BackColor = Color.White;
                        break;
                    }
            }
        }

    }
}

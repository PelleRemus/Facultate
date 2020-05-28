using System.Windows.Forms;

namespace Mahjong
{
    public class MyLabel : Label
    {
        public bool isfree;
        public int linie, col;

        public MyLabel() : base()
        {
            isfree = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WarGameEngine
{
    public class Player
    {
        public Color backColor;
        public Player()
        {
            backColor = Color.FromArgb(Engine.r.Next(256), Engine.r.Next(256), Engine.r.Next(256));
        }
    }
}

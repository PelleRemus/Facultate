using System.Collections.Generic;
using System.Drawing;

namespace LicentaDemo
{
    public class Player
    {
        public string name;
        public Color fillColor;
        public List<Fleet> fleets;

        public Player(string name, Color fillColor)
        {
            this.name = name;
            this.fillColor = fillColor;
            fleets = new List<Fleet>();
        }
    }
}

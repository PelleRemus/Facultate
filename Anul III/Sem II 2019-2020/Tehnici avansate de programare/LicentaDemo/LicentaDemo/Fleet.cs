using System.Collections.Generic;

namespace LicentaDemo
{
    public class Fleet
    {
        public string name;
        public List<Ship> ships;
        public Player owner;
        public Planet planet;

        public Fleet()
        {
            ships = new List<Ship>();
        }

        public Fleet(string data)
        {
            ships = new List<Ship>();
            string[] local = data.Split(' ');
            name = local[0];
            owner = Engine.players[int.Parse(local[1])];
            owner.fleets.Add(this);
            planet = Engine.planets[int.Parse(local[2])];
            planet.fleets.Add(this);
        }
    }
}

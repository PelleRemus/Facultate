using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class Explorer: Robot
    {
        public int radius = 3;

        public Explorer(): base()
        {
            type = RobotTypes.Explorer;
        }

        public void Scan()
        {
            for(int r=1; r<=radius; r++)
                for(float alpha = 0; alpha<2*Math.PI; alpha+=0.1f)
                {
                    int x = (int)(startLocation.X + r * Math.Cos(alpha));
                    int y = (int)(startLocation.Y + r * (float)Math.Sin(alpha));
                    if (x >= 0 && y >= 0 && x < Engine.n && y < Engine.m)
                        Engine.fog[x, y] = 0;
                }
        }
    }
}

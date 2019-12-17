using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public abstract class Robot
    {
        public Point location, destination;
        public List<Point> path;

        public Robot()
        {
            location = new Point(0, 0);
            path = new List<Point>(); 
        }

        public abstract void Move();
        public abstract void GetTarget();

        public virtual void DrawRobot()
        {
            Engine.grp.FillEllipse(new SolidBrush(Color.Purple), location.X * Engine.length, location.Y * Engine.length, Engine.length, Engine.length);
            Engine.display.Image = Engine.bmp;
        }
    }

    
    public class Tester: Robot
    {
        public override void Move()
        {
            if (path.Count == 0)
                GetTarget();
            else
            {
                location.X = path[path.Count - 1].X;
                location.Y = path[path.Count - 1].Y;
                path.RemoveAt(path.Count - 1);
            }
        }

        public override void GetTarget()
        {
            float[] pounds = new float[HeadQuarter.targets.Count];
            for(int i=0; i<HeadQuarter.targets.Count; i++)
            {
                pounds[i] = Engine.map[HeadQuarter.targets[i].X, HeadQuarter.targets[i].Y] 
                    / (Engine.DistManhatan(location, HeadQuarter.targets[i]));
            }
            int targetIndex = Engine.AMC(pounds);
            destination = HeadQuarter.targets[targetIndex];

            int[,] local = new int[Engine.n, Engine.m];
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                {
                    if (Engine.map[i, j] <=0)
                        local[i, j] = Engine.map[i, j];
                    //robotii sunt si ei ziduri
                }

            path = Utils.FindPath(local, location, destination);
        }
    }
}

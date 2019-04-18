using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class Robot
    {
        public RobotTypes type;
        public Point startLocation, targetLocation;
        public List<Point> path = new List<Point>();
        public List<string> messages = new List<string>();
        public int[,] matrix;

        public Robot()
        {
            matrix = new int[Engine.n, Engine.m];
        }

        public void MoveToTarget()
        {
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                    matrix[i, j] = 0;

            matrix[startLocation.X, startLocation.Y] = 1; //sau costuri
            Queue list = new Queue();
            list.Add(new Data(startLocation.X, startLocation.Y, 1));

            while (list.n != 0)
            {
                Data toDel = list.Del();
                if (toDel.x - 1 >= 0 && Engine.map[toDel.x - 1, toDel.y].value == 0 
                    && matrix[toDel.x - 1, toDel.y] == 0)
                {
                    list.Add(new Data(toDel.x - 1, toDel.y, toDel.v + 1));
                    matrix[toDel.x - 1, toDel.y] = toDel.v + 1;
                }

                if (toDel.y - 1 >= 0 && Engine.map[toDel.x, toDel.y - 1].value == 0
                    && matrix[toDel.x, toDel.y - 1] == 0)
                {
                    list.Add(new Data(toDel.x, toDel.y - 1, toDel.v + 1));
                    matrix[toDel.x, toDel.y - 1] = toDel.v + 1;
                }

                if (toDel.x + 1 < Engine.n && Engine.map[toDel.x + 1, toDel.y].value == 0
                    && matrix[toDel.x + 1, toDel.y] == 0)
                {
                    list.Add(new Data(toDel.x + 1, toDel.y, toDel.v + 1));
                    matrix[toDel.x + 1, toDel.y] = toDel.v + 1;
                }

                if (toDel.y + 1 < Engine.m && Engine.map[toDel.x, toDel.y + 1].value == 0
                    && matrix[toDel.x, toDel.y + 1] == 0)
                {
                    list.Add(new Data(toDel.x, toDel.y + 1, toDel.v + 1));
                    matrix[toDel.x, toDel.y + 1] = toDel.v + 1;
                }
            }

            int value = matrix[targetLocation.X, targetLocation.Y];
            if (value != 0)
            {
                path.Add(targetLocation);
                Point loc = new Point(targetLocation.X, targetLocation.Y);

                while (value != 1)
                {
                    List<Point> pp = new List<Point>();
                    if (loc.X - 1 >= 0 && matrix[loc.X - 1, loc.Y] == value - 1)
                        pp.Add(new Point(loc.X - 1, loc.Y));
                    if (loc.Y - 1 >= 0 && matrix[loc.X, loc.Y - 1] == value - 1)
                        pp.Add(new Point(loc.X, loc.Y - 1));
                    if (loc.X + 1 < Engine.n && matrix[loc.X + 1, loc.Y] == value - 1)
                        pp.Add(new Point(loc.X + 1, loc.Y));
                    if (loc.Y + 1 < Engine.m && matrix[loc.X, loc.Y + 1] == value - 1)
                        pp.Add(new Point(loc.X, loc.Y + 1));

                    int i = Engine.rnd.Next(pp.Count);
                    path.Insert(0, pp[i]);
                    loc = pp[i];
                    value--;
                }
            }
            else
            {
                messages.Add("Unable to go to target.");
            }
        }

        public void Move()
        {
            if (path.Count > 1)
            {
                startLocation = path[1];
                path.RemoveAt(0);
            }
            else
            {
                messages.Add("Got to target.");
            }
        }

        public List<string> View()
        {
            List<string> toReturn = new List<string>();
            string local = "";

            for(int i=0; i<Engine.n; i++)
            {
                local = "\n";
                for (int j = 0; j < Engine.m; j++)
                    local += matrix[i, j] + " ";
                toReturn.Add(local);
            }

            return toReturn;
        }
    }
}

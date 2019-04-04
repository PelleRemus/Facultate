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
        public Point startLocation, crtLocation, targetLocation;
        public List<Point> path = new List<Point>();
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoperireConvexa
{
    public class Jarvis
    {
        public List<Point> puncte;

        public Jarvis(List<Point> puncte)
        {
            this.puncte = new List<Point>(puncte);
            SorteazaPuncte();
        }


        public void SorteazaPuncte()
        {
            puncte.Sort(delegate (Point a, Point b)
            {
                return a.X - b.X;
            });
        }


        public List<Point> NicerJarvisMarch()
        {
            List<Point> auxPoints = new List<Point>(puncte);
            List<Point> pointsInUse = new List<Point>();

            int leftMostPointIndex = 0;
            do
            {
                pointsInUse.Add(auxPoints[leftMostPointIndex]);
                auxPoints.RemoveAt(leftMostPointIndex);

                leftMostPointIndex = 0;

                for (int i = 1; i < auxPoints.Count; i++)
                {
                    if (LaStanga(pointsInUse[pointsInUse.Count - 1], auxPoints[leftMostPointIndex], auxPoints[i]))
                    {
                        leftMostPointIndex = i;
                    }
                }

            } while (auxPoints.Count != 0 && !LaStanga(pointsInUse[pointsInUse.Count - 1], auxPoints[leftMostPointIndex], pointsInUse[0]));

            return pointsInUse;
        }


        public bool LaStanga(Point a, Point b, Point c)
        {
            int valoare = ((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X));

            if (valoare > 0) { return true; }
            else { return false; }
        }


        public string PointsToString()
        {
            string pointsInString = "";

            for (int i = 0; i < puncte.Count; i++)
            {
                pointsInString += puncte[i].X + " , " + puncte[i].Y + "\n";
            }

            return pointsInString;
        }
    }
}

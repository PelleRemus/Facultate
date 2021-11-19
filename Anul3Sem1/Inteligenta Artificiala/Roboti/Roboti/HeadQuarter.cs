using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public static class HeadQuarter
    {
        public static List<Point> targets = new List<Point>();

        public static void AddTarget(Point p)
        {
            targets.Add(p);
        }
    }
}

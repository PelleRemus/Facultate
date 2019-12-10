using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Roboti
{
    public static class Utils
    {
        public static List<Point> FindPath(int[,] m, Point start, Point final)
        {
            List<Point> path = new List<Point>();
            //m are doar 0 si -1

            Queue A = new Queue();
            A.Push(new Node(start.X, start.Y, 1));
            m[start.X, start.Y] = 1;

            while (A.n != 0)
            {
                Node crt = A.Pop();
                if (crt.i - 1 >= 0 && m[crt.i - 1, crt.j] == 0)
                {
                    A.Push(new Node(crt.i - 1, crt.j, crt.value + 1));
                    m[crt.i - 1, crt.j] = crt.value + 1;
                }
                if (crt.i + 1 < Engine.n && m[crt.i + 1, crt.j] == 0)
                {
                    A.Push(new Node(crt.i + 1, crt.j, crt.value + 1));
                    m[crt.i + 1, crt.j] = crt.value + 1;
                }
                if (crt.j - 1 >= 0 && m[crt.i, crt.j - 1] == 0)
                {
                    A.Push(new Node(crt.i, crt.j - 1, crt.value + 1));
                    m[crt.i, crt.j - 1] = crt.value + 1;
                }
                if (crt.j + 1 < Engine.m && m[crt.i, crt.j + 1] == 0)
                {
                    A.Push(new Node(crt.i, crt.j + 1, crt.value + 1));
                    m[crt.i, crt.j + 1] = crt.value + 1;
                }
            }

            if (m[final.X, final.Y] == 0)
                return null;
            Node current = new Node(final.X, final.Y, m[final.X, final.Y]);
            path.Add(final);

            while (current.value > 1)
            {
                if (current.i - 1 >= 0 && m[current.i - 1, current.j] == current.value - 1)
                {
                    path.Add(new Point(current.i - 1, current.j));
                    current.i--;
                }
                else if (current.i + 1 < Engine.n && m[current.i + 1, current.j] == current.value - 1)
                {
                    path.Add(new Point(current.i + 1, current.j));
                    current.i++;
                }
                else if (current.j - 1 >= 0 && m[current.i, current.j - 1] == current.value - 1)
                {
                    path.Add(new Point(current.i, current.j - 1));
                    current.j--;
                }
                else if (current.j + 1 < Engine.m && m[current.i, current.j + 1] == current.value - 1)
                {
                    path.Add(new Point(current.i, current.j + 1));
                    current.j++;
                }
                current.value--;
            }

            return path;
        }
    }
}

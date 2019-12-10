using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roboti
{
    public static class Engine
    {
        public static int[,] map;
        public static int n, m, length = 20;

        public static PictureBox display;
        public static Random rnd = new Random();

        public static void Init(PictureBox p)
        {
            display = p;
            n = p.Width / length;
            m = p.Height / length;

            map = new int[n, m];
            for(int i=0; i<150; i++)
            {
                int x = rnd.Next(n), y = rnd.Next(m);
                map[x, y] = -1;
            }
        }

        public static List<string> ShowMatrix(int[,] matrix)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                s.Add("");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        s[i] += "[] ";
                    else
                        s[i] += matrix[i, j].ToString("00") + " ";
                }
            }
            return s;
        }
    }
}

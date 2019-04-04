using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public static partial class Engine
    {
        public static Tile[,] map;
        public static int n, m;

        public static Random rnd = new Random();

        public static void Init(int _n, int _m)
        {
            n = _n;
            m = _m;
            map = new Tile[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    map[i, j] = new Tile(0, i, j);
        }

        public static void SpawnRes(int x, int y, int size, int number, int val)
        {
            for(int i=0; i<number; i++)
            {
                float alpha = (float)(rnd.NextDouble() * Math.PI * 2);
                float _x = x + rnd.Next(size + 1) * (float)Math.Cos(alpha);
                float _y = y + rnd.Next(size + 1) * (float)Math.Sin(alpha);
                map[(int)_x, (int)_y].value += val;
            }
        }
    }
}

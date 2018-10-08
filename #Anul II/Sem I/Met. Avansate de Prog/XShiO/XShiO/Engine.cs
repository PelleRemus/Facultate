using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XShiO
{
    public static class Engine
    {
        public static int crtPlayer;
        public static int[,] m;

        public static void initGame()
        {
            m = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    m[i, j] = 0;
            crtPlayer = 0;
        }

        public static bool isGameOver()
        {
            int[] s = new int[8];
            s[0] = m[0, 0] + m[0, 1] + m[0, 2];
            s[1] = m[1, 0] + m[1, 1] + m[1, 2];
            s[2] = m[2, 0] + m[2, 1] + m[2, 2];
            s[3] = m[0, 0] + m[1, 0] + m[2, 0];
            s[4] = m[0, 1] + m[1, 1] + m[2, 1];
            s[5] = m[0, 2] + m[1, 2] + m[2, 2];
            s[6] = m[0, 0] + m[1, 1] + m[2, 2];
            s[7] = m[2, 0] + m[1, 1] + m[0, 2];

            for(int i=0; i<8; i++)
            {
                if (s[i] == 3 || s[i] == 30)
                    return true;
            }
            return false;
        }
    }
}

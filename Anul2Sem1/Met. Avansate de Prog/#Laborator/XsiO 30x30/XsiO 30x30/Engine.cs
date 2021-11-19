using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XsiO_30x30
{
    public static class Engine
    {
        public static int crtPlayer;
        public static int[,] m;
        public static int n = 30;

        public static void Init()
        {
            m = new int[n, n];
            crtPlayer = 0;
        }

        public static bool IsGameOver()
        {
            for(int i=0; i<n-5; i++)
                for(int j=0; j<n-5; j++)
                {
                    if (m[i, j] == 0) continue;
                    int[] sol = new int[3];
                    for(int k=0; k<5; k++)
                    {
                        sol[0] += m[i + k, j];
                        sol[1] += m[i, j + k];
                        sol[2] += m[i + k, j + k];
                    }
                    for (int k = 0; k < 3; k++)
                        if (sol[k] == 5 || sol[k] == 50)
                            return true;
                }
            return false;
        }
    }
}

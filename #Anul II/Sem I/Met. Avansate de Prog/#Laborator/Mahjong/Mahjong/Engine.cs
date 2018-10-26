using System;
using System.Windows.Forms;

namespace Mahjong
{
    public static class Engine
    {
        public static int n, m;
        public static float dw, dh;
        public static int[,] matrix;
        public static Random r = new Random();
        public static Panel display;
        public static MyLabel[,] labels;

        public static void Init(Panel p)
        {
            display = p;
            n = 8; m = 6;
            dw = (float)p.Width / (float)n;
            dh = (float)p.Height / (float)m;
            matrix = new int[n, m];

            int k = 0, count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = k;
                    count++;
                    if (count == 4)
                    {
                        k++;
                        count = 0;
                    }
                }
        }

        public static void Shuffle()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int l = r.Next(n);
                    int c = r.Next(m);
                    int aux = matrix[i, j];
                    matrix[i, j] = matrix[l, c];
                    matrix[l, c] = aux;
                    labels[i, j].isfree = false;
                }

            for (int i = 0; i < m; i++)
            {
                labels[0, i].isfree = true;
                labels[n - 1, i].isfree = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GrafCosturiDesen
{
    public static class Engine
    {
        public static int n = 4;
        public static int[,] ma = new int[n, n];
        public static float k = 2;
        public static int resx, resy;
        public static Random r = new Random();
        public static int N = 1000;
        public static List<Solution> sol = new List<Solution>();
        public static int K = 5;
        public static List<Solution> par = new List<Solution>();
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color backColor = Color.PeachPuff;

        public static void Do()
        {
            par.Clear();
            sol.Sort(delegate (Solution a, Solution b) {return a.FAdec().CompareTo(b.FAdec()); });
            for(int i=0; i<K; i++)
                par.Add(sol[i]);
            sol.Clear();

            sol.AddRange(par);
            for(int i=K; i<N; i++)
                sol.Add(Mutate(Cross(par[r.Next(K)], par[r.Next(K)])));
        }

        public static Solution Cross(Solution a, Solution b)
        {
            Solution mix = new Solution();
            for (int i = 0; i < n / 2; i++)
            {
                mix.values[i].X = a.values[i].X;
                mix.values[i].Y = a.values[i].Y;
            }
            for (int i = n/2; i < n; i++)
            {
                mix.values[i].X = b.values[i].X;
                mix.values[i].Y = b.values[i].Y;
            }
            return mix;
        }

        public static Solution Mutate(Solution T)
        {
            Solution mix = new Solution();
            for (int i = 0; i < n; i++)
            {
                mix.values[i].X = T.values[i].X;
                mix.values[i].Y = T.values[i].Y;
            }
            int m = r.Next(n);
            mix.values[m].X = r.Next(resx);
            mix.values[m].Y = r.Next(resy);
            return mix;
        }

        public static void Init(PictureBox p)
        {
            ma[0, 0] = 0; ma[0, 1] = 200; ma[0, 2] = -1; ma[0, 3] = 100;
            ma[1, 0] = 0; ma[1, 1] = 0; ma[1, 2] = -1; ma[1, 3] = 150;
            ma[2, 0] = 0; ma[2, 1] = 0; ma[2, 2] = 0; ma[2, 3] = 50;
            ma[3, 0] = 0; ma[3, 1] = 0; ma[3, 2] = 0; ma[3, 3] = 0;

            display = p;
            resx = p.Width;
            resy = p.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backColor);

            for (int i = 0; i < N; i++)
                sol.Add(new Solution());
            Do();
        }

        public static float D(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}

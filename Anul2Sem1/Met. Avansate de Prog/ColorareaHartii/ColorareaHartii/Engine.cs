using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ColorareaHartii
{
    public static class Engine
    {
        public static int[,] matrix;
        public static int n;
        public static int[] colors;
        public static Color[] defaultC = new Color[] 
        { Color.Red, Color.Blue, Color.Green, Color.Yellow};
        public static PointF[] points; 
        public static Graphics grp;
        public static Bitmap bmp;
        public static PictureBox display;
        public static Color c = Color.AliceBlue;
        public static int resx, resy;

        public static void InitGraf(PictureBox p)
        {
            display = p;
            resx = p.Width;
            resy = p.Height;
            bmp = new Bitmap(resx, resy);
            grp = Graphics.FromImage(bmp);
            grp.Clear(c);
            p.Image = bmp;
        }

        public static void InitMap()
        {
            float alpha = (float)(Math.PI * 2) / (float)n;
            float centerX = resx / 2;
            float centerY = resy / 2;
            float radius = resy / 2 - 30;

            for (int i = 0; i < n; i++)
            {
                float x = centerX + radius * (float)Math.Cos(alpha * i);
                float y = centerY + radius * (float)Math.Sin(alpha * i);
                points[i] = new PointF(x, y);
            }
        }

        public static void DrawMap()
        {
            for(int i=0; i<n; i++)
            {
                if (colors[i] == -1)
                    colors[i] = 0;

                grp.FillEllipse(new SolidBrush(defaultC[colors[i]]), points[i].X - 10, points[i].Y - 10, 21, 21);
                grp.DrawEllipse(Pens.Black, points[i].X - 10, points[i].Y - 10, 21, 21);
                grp.DrawString((i + 1).ToString(), 
                    new Font("Arial", 15, FontStyle.Regular), 
                    new SolidBrush(Color.Red), points[i]);
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                        grp.DrawLine(Pens.Black, points[i], points[j]);
                }
            display.Image = bmp;
        }

        public static void Load()
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");
            n = int.Parse(dataLoad.ReadLine());
            matrix = new int[n, n];
            points = new PointF[n];
            string s;

            while((s=dataLoad.ReadLine())!=null)
            {
                int x = int.Parse(s.Split(' ')[0]);
                int y = int.Parse(s.Split(' ')[1]);

                matrix[x-1, y-1] = 1;
                matrix[y-1, x-1] = 1;
            }
        }

        public static void BFS(ListBox l)
        {
            colors = new int[n];
            Coada c = new Coada();
            c.Add(0);
            l.Items.Add("0");
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
                colors[i] = -1;
            }
            visited[0] = true;
            colors[0] = MinColors(0);

            while (c.n != 0)
            {
                int t = c.Del();
                colors[t] = MinColors(t);

                for(int i=0; i<n; i++)
                    if(matrix[t, i]==1 && !visited[i])
                    {
                        c.Add(i);
                        l.Items.Add(i.ToString());
                        visited[i] = true;
                    }
            }
        }

        public static int MinColors(int v)
        {
            bool[] tc = new bool[n];
            for (int i = 0; i < n; i++)
                tc[i] = false;

            for (int i = 0; i < n; i++)
                if (matrix[v, i] == 1 && colors[i] != -1)
                    tc[colors[i]] = true;

            for (int i = 0; i < n; i++)
                if (!tc[i])
                    return i;
            return -1;
        }
    }
}

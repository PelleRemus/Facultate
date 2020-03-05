using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace LicentaDemo
{
    public static class Engine
    {
        public static List<Planet> planets = new List<Planet>();
        public static int[,] ma;
        public static int n;
        public static float zoomX = 1, zoomY = 1;

        public static Color backColor = Color.FromArgb(20, 20, 50);
        public static PictureBox display;
        public static Graphics grp;
        public static Bitmap bmp;

        public static void InitGraph(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backColor);

            display.Image = bmp;
        }

        public static void Load(string fileName)
        {
            TextReader dataLoad = new StreamReader(fileName);
            string buffer;

            while ((buffer = dataLoad.ReadLine()) != "end_planets")
            {
                planets.Add(new Planet(buffer));
            }

            n = planets.Count;
            ma = new int[n, n];
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                int i = int.Parse(local[0]);
                int j = int.Parse(local[1]);
                int value = int.Parse(local[2]);
                ma[i, j] = value;
                ma[j, i] = value;
            }
        }

        public static void DrawMap()
        {
            for(int i=0; i<n-1; i++)
                for(int j=i+1; j<n; j++)
                {
                    if (ma[i, j] != 0)
                        grp.DrawLine(new Pen(Color.White, 5), new Point((int)(planets[i].location.X * zoomX), (int)(planets[i].location.Y * zoomY)), 
                            new Point((int)(planets[j].location.X * zoomX), (int)(planets[j].location.Y * zoomY)));
                }

            foreach (Planet p in planets)
            {
                p.Draw();
            }
        }

        public static void RefreshMap()
        {
            display.Image = bmp;
        }
    }
}

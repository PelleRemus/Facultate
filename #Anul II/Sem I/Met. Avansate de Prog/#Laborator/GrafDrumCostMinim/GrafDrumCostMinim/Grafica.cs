using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafDrumCostMinim
{
    public static class Grafica
    {
        public static Point[] puncte;
        public static int n;
        public static Graphics grp;
        public static Bitmap bmp;
        public static int[,] matrix;

        public static void InitPoints(PictureBox p)
        {
            TextReader dataLoad = new StreamReader(@"../../Puncte.txt");
            n = int.Parse(dataLoad.ReadLine());
            puncte = new Point[n];

            string buffer;
            int i = 0;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int x = int.Parse(buffer.Split(' ')[0]);
                int y = int.Parse(buffer.Split(' ')[1]);
                puncte[i] = new Point(x, y);
                i++;
            }
            
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            p.Image = bmp;
        }

        public static void DrawPoints()
        {
            for(int i=0; i<n; i++)
            {
                Point tempPoint = new Point(puncte[i].X - 7, puncte[i].Y - 7);

                grp.FillEllipse(new SolidBrush(Color.White), tempPoint.X, tempPoint.Y, 15, 15);
                grp.DrawEllipse(Pens.Black, tempPoint.X, tempPoint.Y, 15, 15);

                grp.DrawString((i + 1).ToString(), new Font("Arial", 10, FontStyle.Regular),
                    new SolidBrush(Color.Black), tempPoint);
            }
        }

        public static void InitLines()
        {
            TextReader dataLoad = new StreamReader(@"../../Legaturi.txt");
            matrix = new int[n, n];

            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int i = int.Parse(buffer.Split(' ')[0]);
                int j = int.Parse(buffer.Split(' ')[1]);

                int value = Distanta(puncte[i - 1], puncte[j - 1]);
                matrix[i - 1, j - 1] = value;
                matrix[j - 1, i - 1] = value;
            }
        }

        public static void DrawLines()
        {
            for(int i=0; i<n; i++)
                for(int j=0; j<n; j++)
                {
                    if (matrix[i, j] != 0)
                        grp.DrawLine(Pens.Black, puncte[i], puncte[j]);
                }
        }

        public static void AfisareMatrice(ListBox list)
        {
            for(int i=0; i<n; i++)
            {
                string s = "";
                for (int j = 0; j < n; j++)
                {
                    s += matrix[i, j];
                    
                    if (matrix[i, j] > 99)
                        s += " ";
                    else if (matrix[i, j] > 9)
                        s += "  ";
                    else
                        s += "   ";
                }
                list.Items.Add(s);
            }
            list.Items.Add("");
        }

        public static int Distanta(Point p1, Point p2)
        {
            int x = (p2.X - p1.X) * (p2.X - p1.X);
            int y = (p2.Y - p1.Y) * (p2.Y - p1.Y);
            return (int)Math.Sqrt(x + y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualFredkin
{
    public static class Engine
    {
        public static PictureBox display;
        public static PictureBox[,] pbMatrix;
        public static int[,] matrix, temp;
        public static int n, length, t;

        public static void Init(PictureBox p)
        {
            //modificati valoarea lui n pentru rezultate diferite.
            n = 51;
            t = 9;
            length = p.Width / n;
            display = p;

            pbMatrix = new PictureBox[n, n];
            matrix = new int[n + 2, n + 2];
            temp = new int[n + 2, n + 2];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    pbMatrix[i, j] = new PictureBox();
                    pbMatrix[i, j].Parent = display;
                    pbMatrix[i, j].Size = new Size(length, length);
                    pbMatrix[i, j].Location = new Point(i * length, j * length);
                }

            //puteti modifica si valorile initiale ale acestei matrice pentru rezultate diferite
            matrix[n / 2 + 1, n / 2 + 1] = 1;
            matrix[n / 2, n / 2] = 1;
            matrix[n / 2 + 2, n / 2] = 1;
            matrix[n / 2, n / 2 + 2] = 1;
            matrix[n / 2 + 2, n / 2 + 2] = 1;

            Afisare();
        }

        public static void Step()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    //tema: modificati legea fiecarui pas pentru rezultate cat mai impresionante.
                    //trebuie modificat doar intre acoladele astea, eventual si n mai sus.
                    //primele 5 cele mai frumoase modele obtinute primesc un punct in plus la examen.
                    int s = matrix[i - 1, j];
                    s += matrix[i, j - 1];
                    s += matrix[i + 1, j];
                    s += matrix[i, j + 1];
                    temp[i, j] = s % t;
                }
            for (int i = 0; i < n + 2; i++)
                for (int j = 0; j < n + 2; j++)
                {
                    matrix[i, j] = temp[i, j];
                    temp[i, j] = 0;
                }
            Afisare();
        }

        public static void Afisare()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    switch(matrix[i, j])
                    {
                        case 1:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Red;
                            break;
                        case 2:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Blue;
                            break;
                        case 3:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Orange;
                            break;
                        case 4:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Green;
                            break;
                        case 5:
                            pbMatrix[i - 1, j - 1].BackColor = Color.MediumBlue;
                            break;
                        case 6:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Yellow;
                            break;
                        case 7:
                            pbMatrix[i - 1, j - 1].BackColor = Color.Violet;
                            break;
                        case 8:
                            pbMatrix[i - 1, j - 1].BackColor = Color.OrangeRed;
                            break;
                        case 9:
                            pbMatrix[i - 1, j - 1].BackColor = Color.YellowGreen;
                            break;
                        default:
                            pbMatrix[i - 1, j - 1].BackColor = Color.White;
                            break;
                    }
                }
        }
    }
}

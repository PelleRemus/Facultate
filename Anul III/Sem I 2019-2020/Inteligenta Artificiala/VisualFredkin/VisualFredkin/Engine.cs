using System.Drawing;
using System.Windows.Forms;

namespace VisualFredkin
{
    public static class Engine
    {
        public static Button[,] buttons = new Button[,]
        {
            { new Button() { BackColor = Color.Red }, new Button() { BackColor = Color.FromArgb(255,42,0) }, new Button() { BackColor = Color.FromArgb(255,85,0) }, new Button() { BackColor = Color.FromArgb(255,128,0) }, new Button() { BackColor = Color.FromArgb(255,170,0) }, new Button() { BackColor = Color.FromArgb(255,213,0) } },
            { new Button() { BackColor = Color.Yellow }, new Button() { BackColor = Color.FromArgb(212,255,0) }, new Button() { BackColor = Color.FromArgb(170,255,0) }, new Button() { BackColor = Color.FromArgb(128,255,0) }, new Button() { BackColor = Color.FromArgb(85,255,0) }, new Button() { BackColor = Color.FromArgb(42,255,0) } },
            { new Button() { BackColor = Color.Green }, new Button() { BackColor = Color.FromArgb(0,255,42) }, new Button() { BackColor = Color.FromArgb(0,255,85) }, new Button() { BackColor = Color.FromArgb(0,255,128) }, new Button() { BackColor = Color.FromArgb(0,255,170) }, new Button() { BackColor = Color.FromArgb(0,255,213) } },
            { new Button() { BackColor = Color.Aqua }, new Button() { BackColor = Color.FromArgb(0,213,255) }, new Button() { BackColor = Color.FromArgb(0,170,255) }, new Button() { BackColor = Color.FromArgb(0,128,255) }, new Button() { BackColor = Color.FromArgb(0,85,255) }, new Button() { BackColor = Color.FromArgb(0,42,255) } },
            { new Button() { BackColor = Color.Blue }, new Button() { BackColor = Color.FromArgb(42,0,255) }, new Button() { BackColor = Color.FromArgb(85,0,255) }, new Button() { BackColor = Color.FromArgb(128,0,255) }, new Button() { BackColor = Color.FromArgb(170,0,255) }, new Button() { BackColor = Color.FromArgb(213,0,255) } },
            { new Button() { BackColor = Color.HotPink }, new Button() { BackColor = Color.FromArgb(255,0,213) }, new Button() { BackColor = Color.FromArgb(255,0,170) }, new Button() { BackColor = Color.FromArgb(255,0,128) }, new Button() { BackColor = Color.FromArgb(255,0,85) }, new Button() { BackColor = Color.FromArgb(255,0,42) } },
            { new Button() { BackColor = Color.Black }, new Button() { BackColor = Color.FromArgb(42,42,42) }, new Button() { BackColor = Color.FromArgb(85,85,85) }, new Button() { BackColor = Color.FromArgb(128,128,128) }, new Button() { BackColor = Color.FromArgb(170,170,170) }, new Button() { BackColor = Color.FromArgb(213,213,213) } }
        };
        public static Color[] colors = new Color[10] { Color.White, Color.Red, Color.Black, Color.FromArgb(255, 85, 0), Color.FromArgb(0, 170, 255), Color.Yellow, Color.Green, Color.HotPink, Color.FromArgb(42, 0, 255), Color.FromArgb(170, 170, 170) };
        public static Color selectedColor;
        public static int selectedIndex;

        public static Form1 form;
        public static PictureBox display;
        public static PictureBox[,] pbMatrix;
        public static int[,] matrix, temp;
        public static int n, length, t;

        public static void Init(Form1 f, PictureBox p)
        {
            n = 51;
            t = 3;
            length = p.Width / n;
            form = f;
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

            matrix[n / 2 + 1, n / 2 + 1] = 1;
            matrix[n / 2, n / 2] = 1;
            matrix[n / 2 + 2, n / 2] = 1;
            matrix[n / 2, n / 2 + 2] = 1;
            matrix[n / 2 + 2, n / 2 + 2] = 1;

            for (int i = 1; i < 10; i++)
                ChangeColor(i, colors[i]);
            Afisare();
        }

        public static void Step()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
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

        public static void ChangeColor(int i, Color c)
        {
            selectedIndex = i;
            selectedColor = c;
            colors[i] = c;
            switch (i)
            {
                case 1: form.color1.BackColor = c; break;
                case 2: form.color2.BackColor = c; break;
                case 3: form.color3.BackColor = c; break;
                case 4: form.color4.BackColor = c; break;
                case 5: form.color5.BackColor = c; break;
                case 6: form.color6.BackColor = c; break;
                case 7: form.color7.BackColor = c; break;
                case 8: form.color8.BackColor = c; break;
                case 9: form.color9.BackColor = c; break;
            }
        }

        public static void Afisare()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                    pbMatrix[i - 1, j - 1].BackColor = colors[matrix[i, j]];
        }
    }
}

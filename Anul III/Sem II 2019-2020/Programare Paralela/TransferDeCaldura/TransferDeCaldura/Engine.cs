using System.Drawing;
using System.Windows.Forms;

namespace TransferDeCaldura
{
    public static class Engine
    {
        public static Color[] colors = new Color[101];
        public static Form1 form;
        public static PictureBox[,] pbMatrix;
        public static float[,] matrix, temp;
        public static int n, length, state = 0, iterations = 1;

        public static void Init(Form1 f)
        {
            int r = 0, g = 0, b = 250;
            for (int i = 0; i < 25; i++)
                colors[i] = Color.FromArgb(r, g += 10, b);

            for (int i = 25; i < 50; i++)
                colors[i] = Color.FromArgb(r, g, b -= 10);

            for (int i = 50; i < 75; i++)
                colors[i] = Color.FromArgb(r += 10, g, b);

            for (int i = 75; i < 100; i++)
                colors[i] = Color.FromArgb(r, g -= 10, b);
            colors[100] = Color.FromArgb(255, 0, 0);

            form = f;
            n = 50;
            length = f.pictureBox1.Width / n;

            pbMatrix = new PictureBox[n, n];
            matrix = new float[n, n];
            temp = new float[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    pbMatrix[i, j] = new PictureBox();
                    pbMatrix[i, j].Parent = f.pictureBox1;
                    pbMatrix[i, j].Size = new Size(length, length);
                    pbMatrix[i, j].Location = new Point(i * length, j * length);
                }

            InitialValues();
        }

        public static void InitialValues()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = 0;

            switch (state)
            {
                case 0:
                    for (int i = 0; i < n / 2; i++)
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = 25;
                            matrix[n - 1 - i, j] = 75;
                        }
                    break;
                case 1:
                    for (int i = n / 3; i < 2 * n / 3; i++)
                        for (int j = n / 3; j < 2 * n / 3; j++)
                            matrix[i, j] = 100;
                    break;
            }
            EternalValues();
            Afisare();
        }

        public static void EternalValues()
        {
            switch (state)
            {
                case 2:
                    matrix[n / 2, n / 2] = 100;
                    break;
                case 3:
                    for (int i = 0; i < n - 1; i++)
                    {
                        matrix[i + 1, 0] = 100;
                        matrix[i, n - 1] = 100;
                        matrix[n - 1, i + 1] = 0;
                        matrix[0, i] = 50;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void Step()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    float s = 0, nr = 0;
                    if (i - 1 >= 0)
                    {
                        s += matrix[i - 1, j];
                        nr++;
                    }
                    if (j - 1 >= 0)
                    {
                        s += matrix[i, j - 1];
                        nr++;
                    }
                    if (j + 1 < n)
                    {
                        s += matrix[i, j + 1];
                        nr++;
                    }
                    if (i + 1 < n)
                    {
                        s += matrix[i + 1, j];
                        nr++;
                    }
                    temp[i, j] = s / nr;
                    if (temp[i, j] < 0) temp[i, j] = 0;
                    if (temp[i, j] > 100) temp[i, j] = 100;
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = temp[i, j];
                    temp[i, j] = 0;
                }

            EternalValues();
        }

        public static void Afisare()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    pbMatrix[i, j].BackColor = colors[(int)matrix[i, j]];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RegresieLiniara
{
    public static class Engine
    {
        public static Matrix W, X, Y, C;
        public static Random random = new Random();

        public static void Init()
        {
            string buffer = File.ReadAllText(@"../../data.txt");
            string[] examples = buffer.Split('\n');

            X = new Matrix(examples.Length, 2);
            Y = new Matrix(1, examples.Length);
            W = new Matrix(2, 1);
            W[0, 0] = random.NextDouble();
            W[1, 0] = random.NextDouble();

            for (int i=0; i<examples.Length; i++)
            {
                X[i, 0] = 1;
                X[i, 1] = double.Parse(examples[i].Split(',')[0]);
                Y[i, 0] = double.Parse(examples[i].Split(',')[1]);
            }
        }
    }
}

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
        public static int nrOfIterations = 1000;
        public static double learningRate = 0.005;
        public static Random random = new Random();

        public static void Init()
        {
            string buffer = File.ReadAllText(@"../../data.txt");
            string[] examples = buffer.Split('\n');

            X = new Matrix(examples.Length, 2);
            Y = new Matrix(examples.Length, 1);
            W = new Matrix(2, 1);
            W[0, 0] = random.NextDouble();
            W[1, 0] = random.NextDouble();

            for (int i = 0; i < examples.Length; i++)
            {
                X[i, 0] = 1;
                X[i, 1] = double.Parse(examples[i].Split(',')[0]);
                Y[i, 0] = double.Parse(examples[i].Split(',')[1]);
            }
        }

        public static void GradientDescent()
        {
            Matrix Hx = X * W;
            int m = X.GetLength(0);
            Matrix delta = (Hx - Y) / m;
            Matrix deltaW = delta.GetTranspose() * X;

            W = W - deltaW.GetTranspose()/(1/learningRate);
        }

        public static double FAdec()
        {
            Matrix Hx = X * W;
            C = (Hx - Y).ElementMultiplication(Hx - Y);
            int m = X.GetLength(0);
            C = C / (2 * m);

            double sumaErorilor = 0;
            for (int i = 0; i < C.GetLength(0); i++)
                sumaErorilor += C[i, 0];
            return sumaErorilor;
        }
    }
}

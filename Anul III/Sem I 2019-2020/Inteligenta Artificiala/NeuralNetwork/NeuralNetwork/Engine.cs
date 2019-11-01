using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public static class Engine
    {
        public static List<Layer> layers = new List<Layer>();

        public static Random random = new Random();

        public static void Initialization(Matrix input, Matrix expectedValues, int[] neurons)
        {
            layers.Add(new Layer());
            layers[0].a = input;
            layers[0].w = Matrix.InitRandom(neurons[0], neurons[1]);
            layers[0].b = new Matrix(1, neurons[0]);

            for (int i = 1; i < neurons.Length - 1; i++)
            {
                layers.Add(new Layer());
                layers[i].w = Matrix.InitRandom(neurons[i], neurons[i + 1]);
                layers[i].b = new Matrix(1, neurons[i]);
            }
        }

        public static void ForwardPropagation()
        {
            for(int i=1; i<layers.Count; i++)
            {

            }
        }

        public static Matrix SigmoidMatrix(Matrix z)
        {
            Matrix toReturn = new Matrix(z.GetLength(0), z.GetLength(1));
            for(int i=0; i<z.GetLength(0); i++)
                for(int j=0; j< z.GetLength(1); j++)
                    toReturn[i, j] = Sigmoid(z[i, j]);
            return toReturn;
        }

        public static double Sigmoid(double x)
        {
            return 1.0 / (1 + Math.Exp(-x));
        }
    }
}

using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public static class Engine
    {
        public static List<Layer> layers = new List<Layer>();
        public static Matrix expectedValues, input;
        public static Random random = new Random();
        public static double learningRate = 0.5;
        public static int epochs = 2000, batchDimension = 100;

        public static void Initialization(Matrix input, Matrix expectedValues, int[] neurons)
        {
            Engine.expectedValues = expectedValues;
            Engine.input = input;
            layers.Add(new Layer());
            layers[0].w = Matrix.InitRandom(neurons[0], neurons[1]);
            layers[0].b = new Matrix(1, neurons[0]);

            for (int i = 1; i < neurons.Length - 1; i++)
            {
                layers.Add(new Layer());
                layers[i].w = Matrix.InitRandom(neurons[i], neurons[i + 1]);
                layers[i].b = new Matrix(1, neurons[i]);
            }
        }

        public static void BatchGradientDescent()
        {
            for (int i = 0; i < epochs; i++)
            {
                for (int j = 0; j < input.GetLength(0) / batchDimension; j++)
                {
                    Matrix batch = new Matrix(batchDimension, input.GetLength(1));
                    for (int k = j * batchDimension; k < (j + 1) * batchDimension; k++)
                        for (int l = 0; l < input.GetLength(1); l++)
                            batch[k - j * batchDimension, l] = input[k, l];
                    layers[0].a = batch;
                    ForwardPropagation();
                    BackPropagation();
                }
                input.Shuffle(expectedValues);
            }
        }

        public static void ForwardPropagation()
        {
            for(int i=1; i<layers.Count; i++)
            {
                layers[i].z = layers[i - 1].a * layers[i - 1].w;
                layers[i].z = layers[i].z.RowAdding(layers[i].b);
                layers[i].a = SigmoidMatrix(layers[i].z);
            }
        }

        public static void BackPropagation()
        {
            layers[layers.Count - 1].d = (layers[layers.Count-1].a - expectedValues)
                .ElementMultiplication(SigmoidD(layers[layers.Count - 1].a));

            for (int i = layers.Count - 2; i > 0; i--)
            {
                layers[i].d = (layers[i + 1].d * layers[i].w.GetTranspose())
                    .ElementMultiplication(SigmoidD(layers[i].a));
            }

            for(int i=0; i<layers.Count - 1; i++)
            {
                layers[i].dw = layers[i].a * layers[i + 1].d;
            }

            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].w -= layers[i].dw / (1 / learningRate);
            }

            for (int i = 1; i < layers.Count; i++)
            {
                layers[i].b -= layers[i].d.ColumnAverage() / (1 / learningRate);
            }
        }

        public static Matrix SigmoidMatrix(Matrix z)
        {
            Matrix toReturn = new Matrix(z.GetLength(0), z.GetLength(1));
            for (int i = 0; i < z.GetLength(0); i++)
                for (int j = 0; j < z.GetLength(1); j++)
                    toReturn[i, j] = Sigmoid(z[i, j]);
            return toReturn;
        }

        public static double Sigmoid(double x)
        {
            return 1.0 / (1 + Math.Exp(-x));
        }

        public static Matrix SigmoidD(Matrix a)
        {
            return a.ElementMultiplication(new Matrix(a.GetLength(0), a.GetLength(1), 1) - a);
        }

        public static Matrix Cost()
        {
            return (layers[layers.Count - 1].a - expectedValues)
                .ElementMultiplication(layers[layers.Count - 1].a - expectedValues) / 2;
        }
    }
}

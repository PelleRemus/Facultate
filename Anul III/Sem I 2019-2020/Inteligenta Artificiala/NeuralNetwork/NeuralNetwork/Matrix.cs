namespace NeuralNetwork
{
    public class Matrix
    {
        double[,] matrix;
        static MatrixHelper helper = new MatrixHelper();

        public Matrix(int n, int m)
        {
            matrix = new double[n, m];
        }

        public Matrix(int n, int m, double element)
        {
            matrix = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = element;
        }

        public static Matrix InitRandom(int n, int m)
        {
            Matrix newMatrix = new Matrix(n, m);
            for(int i=0; i<n; i++)
                for(int j=0; j<m; j++)
                    newMatrix[i, j] = Engine.random.NextDouble() - 0.5;
            return newMatrix;
        }

        public Matrix ElementMultiplication(Matrix toMultiply)
        {
            Matrix toReturn = new Matrix(this.GetLength(0), this.GetLength(1));
            for (int i = 0; i < this.GetLength(0); i++)
                for (int j = 0; j < this.GetLength(1); j++)
                {
                    toReturn[i, j] = toMultiply[i, j] * matrix[i, j];
                }
            return toReturn;
        }

        public Matrix RowAdding(Matrix toAdd)
        {
            Matrix toReturn = new Matrix(this.GetLength(0), this.GetLength(1));
            for (int i = 0; i < this.GetLength(0); i++)
                for (int j = 0; j < this.GetLength(1); j++)
                {
                    toReturn[i, j] = toAdd[0, j] + matrix[i, j];
                }
            return toReturn;
        }

        public Matrix ColumnAverage()
        {
            Matrix toReturn = new Matrix(1, GetLength(1));
            for (int j = 0; j < GetLength(1); j++)
            {
                for (int i = 0; i < GetLength(0); i++)
                    toReturn[0, j] += matrix[i, j];
                toReturn[0, j] /= GetLength(0);
            }
            return toReturn;
        }

        public void Shuffle(Matrix expValues)
        {
            for (int i = GetLength(0) - 1; i > 0; i--)
            {
                int index = Engine.random.Next(i - 1);
                for (int j = 0; j < GetLength(1); j++)
                {
                    double aux = matrix[i, j];
                    matrix[i, j] = matrix[index, j];
                    matrix[index, j] = aux;
                }
                for(int j=0; j<expValues.GetLength(1); j++)
                {
                    double aux = expValues[i, j];
                    expValues[i, j] = expValues[index, j];
                    expValues[index, j] = aux;
                }
            }
        }

        public Matrix GetTranspose()
        {
            return helper.Transpose(matrix);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return helper.Substraction(a, b);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return helper.MatrixMultiplication(a, b);
        }

        public static Matrix operator /(Matrix a, double m)
        {
            return helper.Divide(a, m);
        }

        public int GetLength(int n)
        {
            return matrix.GetLength(n);
        }

        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
    }
}

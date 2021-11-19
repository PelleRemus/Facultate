using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatoriVectori
{
    public class Vector
    {
        public int[] value;

        public Vector(int n)
        {
            value = new int[n];
            for (int i = 0; i < n; i++)
                value[i] = Program.rnd.Next(10);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (a.value.Length != b.value.Length)
                return false;
            for (int i = 0; i < a.value.Length; i++)
                if (a.value[i] != b.value[i])
                    return false;
            return true;
        }
        public static bool operator !=(Vector a, Vector b)
        {
            if (a == b)
                return false;
            return true;
        }

        public static bool operator <(Vector a, Vector b)
        {
            int n = a.value.Length, m = b.value.Length;
            for (int i = 0; i < Math.Min(n, m); i++)
            {
                if (a.value[i] < b.value[i])
                    return true;
                if (a.value[i] > b.value[i])
                    return false;
            }
            if (n < m)
                return true;
            return false;
        }

        public static bool operator >(Vector a, Vector b)
        {
            if (a < b || a == b)
                return false;
            return true;
        }
    }

    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
        }
    }
}

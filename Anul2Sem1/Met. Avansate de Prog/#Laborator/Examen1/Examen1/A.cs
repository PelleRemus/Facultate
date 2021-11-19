using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    public class A
    {
        public int[] v;
        public int n;

        public A()
        {
            n = 0;
            v = new int[n];
        }

        public void addRND(int value)
        {
            n++;
            int[] t = new int[n];
            Random r = new Random();
            int index = r.Next(n);
            for (int i = 0; i < index; i++)
                t[i] = v[i];
            t[index] = value;
            for (int i = index + 1; i < n; i++)
                t[i] = v[i - 1];
            v = t;
        }

        public void addUniq(int value)
        {
            for (int i = 0; i < n; i++)
                if (v[i] == value)
                    return;
            n++;
            int[] t = new int[n];
            t[0] = value;
            for (int i = 1; i < n; i++)
                t[i] = v[i - 1];
            v = t;
        }

        int[] MinMax()
        {
            int[] m = { 1000, -1000 };
            for (int i = 0; i < n; i++)
            {
                if (m[0] > v[i])
                    m[0] = v[i];
                if (m[1] < v[i])
                    m[1] = v[i];
            }
            return m;
        }

        int[] Caracteristic()
        {
            int min = MinMax()[0], max = MinMax()[1];
            int[] c = new int[max - min + 1];

            for (int i = 0; i < n; i++)
                c[v[i] - min]++;
            return c;
        }

        public void Sort()
        {
            int min = MinMax()[0], max = MinMax()[1];
            int[] c = Caracteristic();

            int count = 0;
            for(int i=0; i<max-min+1; i++)
                if(c[i]!=0)
                    while(c[i]>0)
                    {
                        v[count] = i + min;
                        count++;
                        c[i]--;
                    }
        }

        public void Concat(A toConcat)
        {
            int[] V = toConcat.v;
            int N = toConcat.n;
            int[] t = new int[n + N];
            for (int i = 0; i < n; i++)
                t[i] = v[i];
            for (int i = n; i < n + N; i++)
                t[i] = V[i - n];
            n = n + N;
            v = t;
        }

        public void Uniq()
        {
            int min = MinMax()[0], max = MinMax()[1];
            int[] c = Caracteristic();
            int[] t = new int[n];

            int count = 0;
            for (int i = 0; i < max - min + 1; i++)
                if (c[i] != 0)
                {
                    t[count] = i + min;
                    count++;
                }

            n = count;
            v = new int[n];
            for (int i = 0; i < n; i++)
                v[i] = t[i];
        }

        public void Del(int value)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
                if (v[i] == value)
                    count++;
            n = n - count;
            int[] t = new int[n];
            count = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == value)
                    continue;
                t[count] = v[i];
                count++;
            }
            v = t;
        }
    }
}

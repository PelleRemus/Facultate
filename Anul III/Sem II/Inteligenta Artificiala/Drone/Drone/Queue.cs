using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class Data
    {
        public int x, y, v;

        public Data()
        {

        }

        public Data(int x, int y, int v)
        {
            this.x = x;
            this.y = y;
            this.v = v;
        }
    }

    public class Queue
    {
        public Data[] v;
        public int n;

        public Queue()
        {
            n = 0;
            v = new Data[n];
        }

        public void Add(Data add)
        {
            n++;
            Data[] t = new Data[n];
            for (int i = 0; i < n - 1; i++)
                t[i + 1] = v[i];
            t[0] = add;
            v = t;
        }

        public Data Del()
        {
            Data ret = v[n - 1];
            n--;
            Data[] t = new Data[n];
            for (int i = 0; i < n; i++)
                t[i] = v[i];
            v = t;
            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrafCosturiDesen
{
    public class Solution
    {
        public PointF[] values;

        public float FAdec()
        {
            float s = 0;
            for (int i=0; i<Engine.n; i++)
                for(int j=0; j<Engine.n; j++)
                {
                    if (Engine.ma[i, j] > 0)
                        s += (float)Math.Abs(Engine.k * Engine.D(values[i], values[j]) - Engine.ma[i, j]);
                }
            return s;
        }

        public string View()
        {
            string s = "";
            for (int i = 0; i < Engine.n; i++)
                s += values[i].ToString();
            s += FAdec().ToString();
            return s;
        }

        public Solution()
        {
            values = new PointF[Engine.n];
            for (int i = 0; i < Engine.n; i++)
                values[i] = new PointF(Engine.r.Next(Engine.resx), Engine.r.Next(Engine.resy));
        }
    }
}

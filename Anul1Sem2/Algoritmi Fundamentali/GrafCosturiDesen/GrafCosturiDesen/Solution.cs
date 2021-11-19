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
        public Color color;

        public float FAdec()
        {
            float s = 0;
            for (int i=0; i<Engine.n; i++)
                for(int j=0; j<Engine.n; j++)
                {
                    if (Engine.ma[i, j] > 0)
                        s += (float)Math.Abs(Engine.D(values[i], values[j]) / Engine.k - Engine.ma[i, j]);
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

        public void Draw()
        {
            for (int i = 0; i < Engine.n; i++)
            {
                Engine.grp.FillEllipse(new SolidBrush(color), values[i].X - 3, values[i].Y - 3, 7, 7);
                Engine.grp.DrawEllipse(Pens.Black, values[i].X - 3, values[i].Y - 3, 7, 7);
            }

            for (int i = 0; i < Engine.n - 1; i++)
                for (int j = i + 1; j < Engine.n; j++)
                    if (Engine.ma[i, j] > 0)
                        Engine.grp.DrawLine(new Pen(color, 3), values[i], values[j]);

        }

        public Solution()
        {
            values = new PointF[Engine.n];
            for (int i = 0; i < Engine.n; i++)
                values[i] = new PointF(Engine.r.Next(Engine.resx), Engine.r.Next(Engine.resy));
            color = Color.FromArgb(Engine.r.Next(256), Engine.r.Next(256), Engine.r.Next(256));
        }
    }
}

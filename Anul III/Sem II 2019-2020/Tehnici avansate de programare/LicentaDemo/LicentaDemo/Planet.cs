using System;
using System.Collections.Generic;
using System.Drawing;

namespace LicentaDemo
{
    public class Planet
    {
        public Point location;
        public Color fillColor;
        public int size;
        public string name;
        public Player owner;
        public List<Fleet> fleets;

        public Planet(string data)
        {
            fleets = new List<Fleet>();

            string[] t = data.Split(new char[] { '[', ']' });
            string[] local = t[3].Split(',');
            location = new Point(int.Parse(local[0]), int.Parse(local[1]));
            size = int.Parse(local[2]);
            name = t[5];

            local = t[9].Split(',');
            fillColor = Color.FromArgb(int.Parse(local[0]), int.Parse(local[1]), int.Parse(local[2]));
        }

        public void Draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(fillColor), (location.X - size) * Engine.zoomX, (location.Y - size) * Engine.zoomY, (2 * size + 1) * Engine.zoomX, (2 * size + 1) * Engine.zoomY);
            Engine.grp.DrawString(name, new Font("Arial", 20, FontStyle.Bold), new SolidBrush(Color.Green), new Point((int)(location.X * Engine.zoomX), (int)(location.Y * Engine.zoomY)));

            float d = 2 * size;
            float alpha = 2 * (float)Math.PI / fleets.Count;
            int fleetSize = 5;
            Engine.grp.DrawEllipse(new Pen(fillColor), (location.X - d) * Engine.zoomX, (location.Y - d) * Engine.zoomY, 2 * d + 1, 2 * d + 1);

            for (int i=0; i<fleets.Count; i++)
            {
                float x = location.X + d * (float)Math.Cos(i * alpha);
                float y = location.Y + d * (float)Math.Sin(i * alpha);
                Engine.grp.FillEllipse(new SolidBrush(fleets[i].owner.fillColor), (x - fleetSize) * Engine.zoomX, (y - fleetSize) * Engine.zoomY, (2 * fleetSize + 1) * Engine.zoomX, (2 * fleetSize + 1) * Engine.zoomY);
            }
        }
    }
}

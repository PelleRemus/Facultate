using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaDemo
{
    public class Paragraph
    {
        public List<string> content;

        public Paragraph()
        {
            content = new List<string>();
        }

        public void Add(string toAdd)
        {
            string[] local = toAdd.Split('\n');
            foreach (string s in local)
                content.Add(s);
        }

        public void Clear()
        {
            content.Clear();
        }
    }
}

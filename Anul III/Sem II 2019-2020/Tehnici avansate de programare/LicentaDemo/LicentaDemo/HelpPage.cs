using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaDemo
{
    public class HelpPage
    {
        public string title;
        public List<Paragraph> content;

        public HelpPage()
        {
            content = new List<Paragraph>();
        }

        public void AddParagraph(Paragraph p)
        {
            content.Add(p);
        }
    }
}

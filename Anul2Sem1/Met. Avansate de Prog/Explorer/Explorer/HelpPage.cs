using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Explorer
{
    public class HelpPage
    {
        public List<string> help;

        public HelpPage(string fileName)
        {
            help = new List<string>();
            TextReader dl = new StreamReader(fileName);
            string buffer;
            while ((buffer = dl.ReadLine()) != null)
                help.Add(buffer);
        }
    }
}

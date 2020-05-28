using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Explorer
{
    public static class Engine
    {
        public static string[] files;
        public static List<Ctrl> thumbs;
        public static string transfer;
        public static List<HelpPage> help;
        public static int index = 0;

        public static void LoadFromFile()
        {
            string[] files = Directory.GetFiles(@"D:\\Help");
            help = new List<HelpPage>();
            foreach (string f in files)
            {
                help.Add(new HelpPage(f));
            }
        }
    }
}

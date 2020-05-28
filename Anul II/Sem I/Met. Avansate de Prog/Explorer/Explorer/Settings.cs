using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public static class Settings
    {
        public static int thumbW;
        public static int thumbH;

        public static void Default()
        {
            thumbW = 200;
            thumbH = 200;
        }
    }
}

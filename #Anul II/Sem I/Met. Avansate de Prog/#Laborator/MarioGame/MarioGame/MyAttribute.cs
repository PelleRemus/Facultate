using System;

namespace MarioGame
{
    internal class MyAttribute : Attribute
    {
        internal string tag;

        internal MyAttribute(string t)
        {
            tag = t;
        }
    }
}

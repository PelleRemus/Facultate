using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
    public enum unitType
    {
        [UnitAttribute(5, 5, 50)]
        human,

        [UnitAttribute(10, 5, 70)]
        orc,

        [UnitAttribute(7, 3, 40)]
        troll,

        [UnitAttribute(17, 1, 60)]
        wizard
    }
}

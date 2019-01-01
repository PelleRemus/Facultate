namespace MarioGame
{
    internal enum blocks
    {
        [MyAttribute("land")]
        land,

        [MyAttribute("brick")]
        brick,

        [MyAttribute("questionMark ")]
        questionMark,

        [MyAttribute("disabledQ")]
        disabledQ,

        [MyAttribute("pipe")]
        pipe,

        [MyAttribute("flag")]
        flag
    }
    internal enum enemies
    {
        [MyAttribute("goomba")]
        goomba,

        [MyAttribute("turtle")]
        turtle
    }
    internal enum bonus
    {
        [MyAttribute("mushroom")]
        mushroom,

        [MyAttribute("flower")]
        flower,

        [MyAttribute("star")]
        star,

        [MyAttribute("oneUp")]
        oneUp
    }
}

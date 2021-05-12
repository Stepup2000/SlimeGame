using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Tile : Box
    {
        public Tile(int index, bool isMovable = false, bool isClippable = false) : base("Tiles.png", 32, 32, isMovable, isClippable)
        {
            initializeAnimFrames(width / 64, height / 64);
            SetFrame(index);
            SetOrigin(width / 2, height / 2);
        }
    }
}

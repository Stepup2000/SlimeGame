﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Tile : Box
    {
        public Tile(bool isMovable = false, bool isClippable = false) : base("checkers.png", 32, 32, isMovable, isClippable)
        {

        }
    }
}
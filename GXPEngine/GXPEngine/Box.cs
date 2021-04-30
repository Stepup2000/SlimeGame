using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Box : Body
    {
        public float halfWidth;
        public float halfHeight;
        public Box(string filename, float pHalfWidth, float pHalfHeight) : base(filename)
        {
            halfWidth = pHalfWidth;
            halfHeight = pHalfHeight;
        }
    }
}

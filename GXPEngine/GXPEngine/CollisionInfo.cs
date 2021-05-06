using System;
namespace GXPEngine
{
    public class CollisionInfo
    {
        public float overlap;
        public Vec2 normal;
        public bool isFloored;

        public CollisionInfo(Vec2 normal, float overlap, bool isFloored = false)
        {
            this.normal = normal;
            this.overlap = overlap;
            this.isFloored = isFloored;
        }
    }
}

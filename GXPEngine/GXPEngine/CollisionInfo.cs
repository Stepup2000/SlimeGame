using System;
namespace GXPEngine
{
    public class CollisionInfo
    {
        public float overlap;
        public Vec2 normal;

        public CollisionInfo(Vec2 normal, float overlap)
        {
            this.normal = normal;
            this.overlap = overlap;
        }
    }
}

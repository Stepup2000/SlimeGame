using System;
namespace GXPEngine
{
    public class Circle : Body
    {
        public float radius;

        public Circle(string filename, float radius) : base(filename)
        {
            this.radius = radius;
        }

        private CollisionInfo GetCircleOverlap(Circle other)
        {
            Vec2 separation = other.position - this.position;
            Vec2 normal = separation.NewNormalized();
            float distance = separation.Dot(normal) - radius - other.radius;
            return new CollisionInfo(normal, distance);
        }

        private CollisionInfo GetBoxOverlap(Box other)
        {
            Vec2 circlePoint = new Vec2(Mathf.Clamp(position.x, other.x - other.halfWidth, other.x + other.halfWidth),
                                        Mathf.Clamp(position.y, other.y - other.halfHeight, other.y + other.halfHeight));
            Vec2 distance = circlePoint - this.position;
            if (distance.Length() < radius)
            {
                return new CollisionInfo(distance.NewNormalized(), -(radius - distance.Length()));
            }
            return null;
        }


        public override CollisionInfo GetOverlap(Body other)
        {
            if (other is Circle)
            {
                return GetCircleOverlap(other as Circle);
            }
            if (other is Box)
            {
                return GetBoxOverlap(other as Box);
            }
            return null;
        }
    }
}

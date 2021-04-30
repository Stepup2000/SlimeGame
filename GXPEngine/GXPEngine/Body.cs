using System;
namespace GXPEngine
{
    public class Body : AnimationSprite
    {

        public Vec2 position;
        public Vec2 velocity;
        public Vec2 acceleration = new Vec2(0, 0);

        public Body(string filename) : base(filename, 1, 1)
        {
            position = new Vec2(0f, 0f);
            velocity = new Vec2(0f, 0f);

            SetOrigin(width * 0.5f, height * 0.5f);
        }

        public void SetPosition(float x, float y)
        {
            position.x = x;
            position.y = y;
        }

        public virtual CollisionInfo GetOverlap(Body other)
        {
            return new CollisionInfo(new Vec2(0f, 0f), 0f);
        }

        public void Step()
        {
            velocity += acceleration;
            position += velocity;

            x = position.x;
            y = position.y;
        }
    }
}

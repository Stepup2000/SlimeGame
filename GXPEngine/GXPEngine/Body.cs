using System;
namespace GXPEngine
{
    public class Body : AnimationSprite
    {
        public World world
        {
            get
            {
                return World.main;
            }
        }

        public Vec2 position = new Vec2(0f, 0f);
        public Vec2 velocity;
        public Vec2 acceleration;
        public bool movable;

        public Body(string filename, bool pMovable = false) : base(filename, 1, 1)
        {
            movable = pMovable;
            //initializeAnimFrames(width / spriteSize, height / spriteSize);

            if (movable)
            {
                velocity = new Vec2(0f, 0f);
                acceleration = new Vec2(0f, 0.1f);
            }

            SetOrigin(width * 0.5f, height * 0.5f);
        }

        public void SetPosition(float tempX, float tempY)
        {
            position.x = tempX;
            position.y = tempY;

            x = position.x;
            y = position.y;
        }

        public virtual CollisionInfo GetOverlap(Body other)
        {
            return new CollisionInfo(new Vec2(0f, 0f), 0f);
        }

        public virtual void Step()
        {
            velocity += acceleration;
            position += velocity;

            x = position.x;
            y = position.y;
        }
    }
}

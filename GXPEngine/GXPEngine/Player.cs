using System;
namespace GXPEngine
{
    public class Player : Circle
    {
        public Player(Vec2 pVelocity) : base("circle.png", 32f)
        {
            velocity = pVelocity;
        }

    }


}

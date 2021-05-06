using System;
namespace GXPEngine
{
    public class Player : Box
    {
        // TEST player class, abiding by code conventions in coll-related
        // classes here, but NOT related to game functionality except movement
        public Player(Vec2 pVelocity) : base("circle.png", 32f, 32f, true, false)
        {
            velocity = pVelocity;
        }

        private void Update()
        {
            if (Input.GetKey(Key.A))
            {
                velocity += new Vec2(-0.5f, 0);
            }
            if (Input.GetKey(Key.D))
            {
                velocity += new Vec2(0.5f, 0);
            }
            if (Input.GetKeyDown(Key.W))
            {
                velocity += new Vec2(0, -8f);
            }
            if (Mathf.Abs(velocity.x) > 3f)
            {
                velocity.x = Mathf.Sign(velocity.x) * 3f;
            }
        }   
    }
}

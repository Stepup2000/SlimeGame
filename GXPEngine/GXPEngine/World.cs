using System;
using System.Collections.Generic;

namespace GXPEngine
{
    public class World : Canvas
    {

        private List<Body> bodies = new List<Body>();

        public World() : base(800, 600)
        {
        }

        public void AddBody(Body body)
        {
            bodies.Add(body);
            AddChild(body);
        }

        public void RemoveBody(Body body)
        {
            RemoveChild(body);
            bodies.Remove(body);
        }

        public void Step()
        {
            HandleIntegration();
            HandleOverlaps();
        }

        private void HandleIntegration() {
            foreach (Body body in bodies)
            {
                //if (body.movable)
                //{
                    body.Step();
                //}
            }
        }

        private void HandleOverlaps()
        {
            for (int i = 0; i < bodies.Count; i++)
            {
                for (int j = i + 1; j < bodies.Count; j++)
                {
                    CollisionInfo info = bodies[i].GetOverlap(bodies[j]);
                    if (info != null) 
                    {
                        if (info.overlap < 32f)
                        {
                            ResolveOverlap(bodies[i], bodies[j], info.normal, info.overlap, info.isFloored);
                        }
                    }
                }
            }
        }

        private void ResolveOverlap(Body body1, Body body2, Vec2 normal, float distance, bool floored)
        {
            // works BETTER if all bodies are Boxes.

            Vec2 separation = normal * distance /** 0.5f*/;

            if (body1 is Player1 /*|| body1 is Player2*/ && floored)
            {
                (body1 as Player1).canJump = true;
            }

            /*if (body1 is Player && body2 is Player)         // funny player bounciness
            {
                bounceBalls((Circle)body1, (Circle)body2, normal);
            }
            else*/ if (body1 is Player1 && body2 is Rock) 
            {
                (body2 as Rock).Delete();
                RemoveBody(body2);
            }
            /*else if (body1 is Player && body2 is Exit)
            {
                gotoendscene
            }*/
            else if (body2.movable && normal.y == 0)
            {
                body2.position -= separation;
            }

            else if (body2 is Box && (body2 as Box).clippable && normal.y == 0)
            {
                body1.position.y = body2.position.y - (body2 as Box).halfHeight - (body1 as Box).halfHeight;
            }

            body1.position += separation;
            if (normal.x == 0) body1.velocity.y = 0;
            if (normal.y == 0) body1.velocity.x = 0;
        }
    }
}

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
            //TODO
        }

        public void Step()
        {
            HandleIntegration();
            HandleOverlaps();
        }

        private void HandleIntegration() {
            foreach (Body body in bodies)
            {
                body.Step();
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
                            ResolveOverlap(bodies[i], bodies[j], info.normal, info.overlap);
                        }
                    }
                }
            }
        }

        private void ResolveOverlap(Body body1, Body body2, Vec2 normal, float distance)
        {
            // very simple sample overlap resolve by Bram, both objects pushed.
            // TODO: adapt for immovables (like floor)
            Vec2 separation = normal * distance /** 0.5f*/;
            body1.position += separation;
            body1.velocity = new Vec2(0, 0);
            //body2.position -= separation;
        }

    }
}

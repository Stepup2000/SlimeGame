using System;
using System.Collections.Generic;

namespace GXPEngine
{
    public class World : Canvas
    {
        public static World main { get; private set; }

        private List<Body> bodies = new List<Body>();
        private List<Body> waitList = new List<Body>();

        public World() : base(800, 600)
        {
            if (main == null)
            {
                main = this;
                game.AddChild(main);
            }
        }

        public void AddBody(Body body)
        {
            waitList.Add(body);
            AddChild(body);
        }

        public void RemoveBody(Body body)
        {
            RemoveChild(body);
            bodies.Remove(body);
        }

        private void addNewBodies()
        {
            for (int i = 0; i < waitList.Count; i++)
            {
                bodies.Add(waitList[i]);
            }
            waitList.Clear();
        }

        public void Step()
        {
            addNewBodies();
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

            // currently BUG: on clippable in edge cases body1 will remain in body2
            // and therefore clip downward and through the floor.

            Vec2 separation = normal * distance /** 0.5f*/;

            // restore jump on floor:
            if (body1 is Player1 /*|| body1 is Player2*/ && floored)
            {
                (body1 as Player1).canJump = true;
            }

            // trigger static crystal light beam on other light beam:
            if (body1 is LightBeam && body2 is StaticCrystal)
            {
                StaticCrystal b = body2 as StaticCrystal;
                // comment out distance if visual BS
                if (distance == b.halfWidth && b.activated == false)
                {
                    b.activated = true;
                    b.OnLightBeam();
                }
            }

            // crush rocks: (TODO: check player scale)
            if (body1 is Player1 && body2 is Rock) 
            {
                (body2 as Rock).Delete();
                RemoveBody(body2);
            }

            // change scene on exit:
            /*else if ((body1 is Player1 || body1 is Player2) && body2 is Exit)
            {
                gotoendscene
            }*/

            // move movable body together with pusher:
            else if (body2.movable && normal.y == 0)
            {
                if (normal.x < 0)
                {
                    body2.position -= separation * body1.velocity.x;
                    body1.position += separation * body1.velocity.x;
                }
                else if (normal.x > 0)
                {
                    body2.position += separation * body1.velocity.x;
                    body1.position -= separation * body1.velocity.x;
                }
                return;
            }

            // clip on top of clippable:
            else if (body2 is Box && (body2 as Box).clippable && normal.y == 0)
            {
                body1.position.y = body2.position.y - (body2 as Box).halfHeight - (body1 as Box).halfHeight;
                return;
            }

            // apply separation (main collision resolve) and kill relevant velocity:
            body1.position += separation;
            if (normal.x == 0) body1.velocity.y = 0;
            if (normal.y == 0) body1.velocity.x = 0;
        }
    }
}

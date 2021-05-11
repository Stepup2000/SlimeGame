using System;
using System.Collections.Generic;

namespace GXPEngine
{
    public class World : GameObject
    {
        public static World main { get; private set; }

        private List<Body> bodies = new List<Body>();
        private List<Body> waitList = new List<Body>();
        private float _beamTimer = 0;
        private const float TIME_BEFORE_REMOVEBEAM = 120;

        public World() : base()
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
            body.LateDestroy();
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
            handleIntegration();
            handleOverlaps();
            getPlayerDistToCrystal();
            handleBeamTiles();
        }

        private void handleIntegration() {
            foreach (Body body in bodies)
            {
                body.Step();
            }
        }

        private void handleOverlaps()
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
                            resolveOverlap(bodies[i], bodies[j], info.normal, info.overlap, info.isFloored);
                        }
                    }
                }
            }
        }

        private void getPlayerDistToCrystal()
        {
            for (int i = 0; i < bodies.Count; i++)
            {
                for (int j = i + 1; j < bodies.Count; j++)
                {
                    if ((bodies[i] is Player1 || bodies[i] is Player2) && bodies[j] is StaticCrystal)
                    {
                        float distance = (bodies[i].position - bodies[j].position).Length();
                        if (distance < 96f)
                        {
                            if (Input.GetKeyDown(Key.SPACE) || Input.GetKeyDown(Key.L))
                            {
                                (bodies[j] as StaticCrystal).rotation += 30;
                                (bodies[j] as StaticCrystal)._reflectAngle -= 30;
                            }
                        }
                    }
                }
            }
        }

        private void resolveOverlap(Body body1, Body body2, Vec2 normal, float distance, bool floored)
        {
            Vec2 separation = normal * distance /** 0.5f*/;

            // ignore collisions with static light beam tiles:
            if ((body1 is LightBeam && (body1 as LightBeam)._speed == 0) ||
                (body2 is LightBeam && (body2 as LightBeam)._speed == 0))
            {
                return;
            }

            // ignore any possible collision between Player1 and Player2:
            if (body1 is Player1 && body2 is Player2)
            {
                return;
            }

            // ignore player-sapling collisions (aesthetics):
            if ((body1 is Player1 || body1 is Player2) && body2 is Sapling)
            {
                return;
            }

            // ignore any collision between light beams and the object shooting them:
            if (body2 is LightBeam)
            {
                if (body1 == (body2 as LightBeam).plOwner)
                {
                    return;
                }
            }

            // ignore collisions between gates and tiles (do not push tiles with gates behind them):
            if (body1 is Gate && body2 is Tile)
            {
                return;
            }

            // stop light beam from advancing on non-Player2 surfaces
            // and return (skip actual resolve checks to emulate non-solid):
            if (body1 is Player2 == false && body2 is LightBeam)
            {
                LightBeam b = body2 as LightBeam;
                resolveLightOverlap(b, body1, b.travelDist);
                return;
            }

            // BUTTON collision:
            // on collision (after clipping) between seed/slime and ground
            // button, destroy gate that button is linked to:
            if (body2 is Button)
            {
                Button button = body2 as Button;
                if (button.isActivated == false) 
                {
                    if (button._buttonType == (int)Button.bType.SEED)
                    {
                        if (body1 is Seed)
                        {
                            button.isActivated = true;
                            for (int i = bodies.Count; i > 0; i--)
                            {
                                if (bodies[i - 1] is Gate && (bodies[i - 1] as Gate)._activateID == button._activateID)
                                {
                                    // play sound here I guess
                                    bodies[i - 1].LateDestroy();
                                    Smoke smoke = new Smoke(bodies[i - 1].x, bodies[i - 1].y, 2);
                                    game.AddChild(smoke);
                                    RemoveBody(body1);
                                    RemoveBody(bodies[i - 1]);
                                }
                            }
                        }
                    }
                    if (button._buttonType == (int)Button.bType.SLIME)
                    {
                        if (body1 is Player1)
                        {
                            button.isActivated = true;
                            #region REMOVE GATE (DISABLED)
                            /*for (int i = bodies.Count; i > 0; i--)
                            {
                                if (bodies[i - 1] is Gate && (bodies[i - 1] as Gate)._activateID == button._activateID)
                                {
                                    // play sound here I guess
                                    RemoveBody(bodies[i - 1]);
                                    bodies[i - 1].LateDestroy();
                                }
                            }*/
                            #endregion
                            // spawn sapling instead
                            Sapling s = new Sapling(99);
                            s.rotation = 270;
                            AddBody(s);
                            s.SetPosition(384, 576);
                        }
                    }
                }
            }

            // restore jump on floor:
            if (body1 is Player1 && floored)
            {
                (body1 as Player1).canJump = true;
            }
            if (body1 is Player2 && floored)
            {
                (body1 as Player2).canJump = true;
            }

            // crush rocks:
            if (body1 is Player1 && (body1 as Player1)._scale > 1 && body2 is Rock) 
            {
                StaticCrystal crystal = new StaticCrystal(false, true, 90, 1);
                crystal.SetPosition(body2.position.x, body2.position.y);
                crystal.acceleration = new Vec2(0, 0);
                AddBody(crystal);
                (body2 as Rock).Delete();
                RemoveBody(body2);
            }

            // change scene on exit:
            else if ((body1 is Player1 || body1 is Player2) && body2 is Exit)
            {
                // TODO: End game SOMEHOW
                return;
            }

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

            // clip on top of clippable only from movement from the side:
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

        private void resolveLightOverlap(LightBeam body1, Body body2, float distance)
        {
            for (int i = 0; i < distance + (int)body1.halfWidth * 4; i += (int)body1.halfWidth * 4)
            {
                LightBeam beamTile = new LightBeam(body1.plOwner, (int)body1.velocity.GetAngleDegrees());
                beamTile.rotation = body1.velocity.GetAngleDegrees();
                beamTile.x = body1.plOwner.x + body1.velocity.x / body1._speed * i;
                beamTile.y = body1.plOwner.y + body1.velocity.y / body1._speed * i;
                AddBody(beamTile);
            }
            RemoveBody(body1);

            if (body2 is StaticCrystal)
            {
                StaticCrystal c = body2 as StaticCrystal;
                c.OnLightBeam();
            }

            if (body2 is Sapling && (body2 as Sapling).isActivated == false)
            {
                Sapling s = body2 as Sapling;
                s.isActivated = true;
                for (int i = bodies.Count; i > 0; i--)
                {
                    if (bodies[i - 1] is Gate && (bodies[i - 1] as Gate)._activateID == s._activateID)
                    {
                        Gate g = bodies[i - 1] as Gate;
                        // play sound here I guess
                        Smoke smoke = new Smoke(g.x, g.y, 2);
                        game.AddChild(smoke);
                        RemoveBody(g);
                    }
                }
            }
            _beamTimer = TIME_BEFORE_REMOVEBEAM;
        }

        private void handleBeamTiles()
        {
            _beamTimer--;
            if (_beamTimer < 0)
            {
                _beamTimer = 0;
                for (int i = bodies.Count; i > 0; i--)
                {
                    if (bodies[i-1] is LightBeam && (bodies[i-1] as LightBeam)._speed == 0)
                    {
                        RemoveBody(bodies[i-1]);
                    }
                }
                foreach (Body b in bodies)
                {
                    if (b is StaticCrystal)
                    {
                        if ((b as StaticCrystal)._activated == true) (b as StaticCrystal)._activated = false;
                    }
                }
            }
        }
    }
}

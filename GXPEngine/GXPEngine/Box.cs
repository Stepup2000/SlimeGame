namespace GXPEngine
{
    public class Box : Body
    {
        public float halfWidth;
        public float halfHeight;
        public bool clippable;
        public Box(string filename, float pHalfWidth, float pHalfHeight,
            bool pMovable = false, bool pClippable = false) : base(filename, pMovable)
        {
            halfWidth = pHalfWidth;
            halfHeight = pHalfHeight;
            clippable = pClippable;
        }

        protected void RescaleBox(int targetSize)
        {
            RescaleBox(targetSize, targetSize);
        }

        protected void RescaleBox(int targetX, int targetY)
        {
            scaleX /= width / targetX;
            scaleY /= height / targetY;

            halfWidth *= scaleX;
            halfHeight *= scaleY;
        }

        private CollisionInfo GetCircleOverlap(Circle other)
        {
            return other.GetOverlap(this);
        }

        private CollisionInfo GetBoxOverlap(Box other)
        {
            // TODO: optimize using sign?
            float overlap_h = -1;
            float overlap_v = -1;
            if (this.position.x <= other.position.x)
            {
                overlap_h = this.position.x + this.halfWidth - (other.position.x - other.halfWidth);
                if (overlap_h <= 0) return null;
            }
            else if (this.position.x > other.position.x)
            {
                overlap_h = other.position.x + other.halfWidth - (this.position.x - this.halfWidth);
                if (overlap_h <= 0) return null;
            }
            if (this.position.y <= other.position.y)
            {
                overlap_v = this.position.y + this.halfHeight - (other.position.y - other.halfHeight);
                if (overlap_v <= 0) return null;
            }
            else if (this.position.y > other.position.y)
            {
                overlap_v = other.position.y + other.halfHeight - (this.position.y - this.halfHeight);
                if (overlap_v <= 0) return null;
            }

            if (overlap_h > overlap_v) 
                // reverse logic because the bigger overlap actually happens from the INVERSE direction
            {
                if (this.position.y <= other.position.y)
                {
                    // true = isFloored (for velocity reset)
                    return new CollisionInfo(new Vec2(-other.halfWidth, 0).UnitNormal(), overlap_v, acceleration.y > 0 ? true : false);
                }
                else
                {
                    return new CollisionInfo(new Vec2(other.halfWidth, 0).UnitNormal(), overlap_v, acceleration.y < 0 ? true : false);
                }
            }
            else if (overlap_h < overlap_v)
            {
                if (this.position.x <= other.position.x)
                {
                    return new CollisionInfo(new Vec2(0, other.halfHeight).UnitNormal(), overlap_h);
                }
                else
                {
                    return new CollisionInfo(new Vec2(0, -other.halfHeight).UnitNormal(), overlap_h);
                }
            }
            return null;
        }

        public override CollisionInfo GetOverlap(Body other)
        {
            if (other is Box)
            {
                return GetBoxOverlap(other as Box);
            }
            else if (other is Circle)
            {
                return GetCircleOverlap(other as Circle);
            }
            return null;
        }
    }
}

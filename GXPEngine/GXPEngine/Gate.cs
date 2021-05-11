namespace GXPEngine
{
    public class Gate : Box
    {
        public int _activateID { get; set; }

        // define custom filename, halfWidth, halfHeight as there are different sized gaps
        public Gate(float pHalfWidth, float pHalfHeight, int id)
            : base("square.png", pHalfWidth, pHalfHeight, false, false)
        {
            if (pHalfWidth > pHalfHeight)
            {
                rotation = 90;
            }

            //RescaleBox(spriteSize, 64);
            //initializeAnimFrames(width / spriteSize, height / spriteSize);
            
            _activateID = id;
        }
    }
}

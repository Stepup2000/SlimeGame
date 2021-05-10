namespace GXPEngine
{
    public class Gate : Box
    {
        public int _activateID { get; set; }

        // define custom filename, halfWidth, halfHeight as there are different sized gaps
        public Gate(string filename, float pHalfWidth, float pHalfHeight, int id, int spriteSize)
            : base(filename, pHalfWidth, pHalfHeight, false, false)
        {
            RescaleBox(spriteSize, 64);
            //initializeAnimFrames(width / spriteSize, height / spriteSize);
            
            _activateID = id;
        }
    }
}

namespace GXPEngine
{
    public class Gate : Box
    {
        private int _activateID;

        // define custom halfWidth and halfHeight as there are different sized gaps
        public Gate(string filename, float pHalfWidth, float pHalfHeight, int id)
            : base(filename, pHalfWidth, pHalfHeight, false, false)
        {
            _activateID = id;
        }
    }
}

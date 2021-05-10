namespace GXPEngine
{
    public class Gate : Box
    {
        public int _activateID { get; set; }

        // define custom filename, halfWidth, halfHeight as there are different sized gaps
        public Gate(string filename, float pHalfWidth, float pHalfHeight, int id)
            : base(filename, pHalfWidth, pHalfHeight, false, false)
        {
            _activateID = id;
        }
    }
}

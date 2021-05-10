namespace GXPEngine
{
    public class Seed : Box
    {
        private int _activateID;

        public Seed(int id) : base("triangle.png", 32f, 32f, true, false)
        {
            _activateID = id;
        }
    }
}

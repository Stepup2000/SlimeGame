namespace GXPEngine
{
    public class Sapling : Box
    {
        private int _activateID;

        public Sapling(int id) : base("barry.png", 32f, 32f, false, false)
        {
            _activateID = id;
        }
    }
}

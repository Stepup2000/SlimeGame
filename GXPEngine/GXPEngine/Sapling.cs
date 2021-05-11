namespace GXPEngine
{
    public class Sapling : Box
    {
        public bool isActivated { get; set; }
        public int _activateID { get; set; }

        public Sapling(int id) : base("Sapling.png", 32f, 32f, false, false)
        {
            _activateID = id;
        }
    }
}

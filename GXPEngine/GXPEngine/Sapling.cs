namespace GXPEngine
{
    public class Sapling : Box
    {
        public bool isActivated { get; set; }
        public int _activateID { get; set; }

        public Sapling(int id, int spriteSize) : base("barry.png", 32f, 32f, spriteSize, false, false)
        {
            _activateID = id;
        }
    }
}

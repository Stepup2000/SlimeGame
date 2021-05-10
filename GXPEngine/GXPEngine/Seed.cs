namespace GXPEngine
{
    public class Seed : Box
    {
        public int _activateID { get; set; }

        public Seed(int id, int spriteSize) : base("triangle.png", 32f, 32f, true, false)
        {
            _activateID = id;
        }
    }
}

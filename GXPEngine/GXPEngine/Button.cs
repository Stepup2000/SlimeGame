namespace GXPEngine
{
    public class Button : Box
    {
        private int _activateID;

        public Button(int id) : base("triangle.png", 32f, 32f, false, true)
        {
            _activateID = id;
        }
    }
}

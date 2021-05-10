namespace GXPEngine
{
    public class Button : Box
    {
        public bool isActivated { get; set; }
        public int _buttonType { get; }
        public int _activateID { get; set; }

        public enum bType : int
        {
            SEED,
            SLIME
        }

        public Button(int id, int type) : base("triangle.png", 32f, 32f, false, true)
        {
            _activateID = id;
            _buttonType = type;
        }
    }
}

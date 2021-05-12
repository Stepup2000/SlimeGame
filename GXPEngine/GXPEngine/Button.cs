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

        public Button(int id, int type, string name) : base(name, 16f, 8f, false, true)
        {
            _activateID = id;
            _buttonType = type;
            initializeAnimFrames(width / 64, height / 64);
            if (name == "Button.png")
            {
                changeOrigin(-width / 2);
            }
            else
            {
                changeOrigin(width / 3);
            }
        }
        private void changeOrigin(int amount)
        {
            SetOrigin(width / 2, amount);
        }
    }
}
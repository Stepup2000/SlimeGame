namespace GXPEngine
{
    public class MenuButton : Sprite
    {
        public string mainString;
        public string highlightString;
        public MenuButton(string mainSprite, string highlightSprite) : base(mainSprite)
        {
            mainString = mainSprite;
            highlightString = highlightSprite;
        }

        public void ReinitSprite()
        {
            initializeFromTexture(GXPEngine.Core.Texture2D.GetInstance(name, false));
            SetOrigin(width / 2, height / 2);
        }
    }
}

namespace GXPEngine
{
    public class Exit : Box
    {
		public Exit() : base("circle.png", 32, 32, false, false)
		{
			SetOrigin(width / 2, height / 2);
		}
	}
}

namespace GXPEngine
{
	public class StaticCrystal : Box
	{
		//Private fields
		public int _reflectAngle { get; set; }
		private bool _activated = false;

		//----------------------------------------------------\\
		//						Constructor					  \\
		//----------------------------------------------------\\
		public StaticCrystal(int newReflectAngle, float newScale = 1, bool isMovable = false) : base("square.png", 32f, 32f, isMovable)
		{
			if (newScale != 1)
            {
				halfWidth *= newScale;
				halfHeight *= newScale;
				scale *= newScale;
			}
			SetOrigin(width / 2, height / 2);
			_reflectAngle = newReflectAngle;
		}

		//----------------------------------------------------\\
		//						OnLightBeam					  \\
		//----------------------------------------------------\\
		public void OnLightBeam()
		{
			if (_activated == false)
            {
				_activated = true;
				LightBeam lightBeam = new LightBeam(this, _reflectAngle, 16);
				world.AddBody(lightBeam);
			}
		}
	}
}
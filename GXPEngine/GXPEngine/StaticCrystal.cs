using GXPEngine;

namespace GXPEngine
{
	public class StaticCrystal : Box
	{
		//Private fields
		private int _reflectAngle;
		private bool _activated = false;

		//----------------------------------------------------\\
		//						Constructor					  \\
		//----------------------------------------------------\\
		public StaticCrystal(int newReflectAngle) : base("square.png", 32f, 32f)
		{
			SetOrigin(width / 2, height / 2);
			_reflectAngle = newReflectAngle;
		}

		//----------------------------------------------------\\
		//						collision					  \\
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
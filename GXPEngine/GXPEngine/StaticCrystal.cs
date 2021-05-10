﻿namespace GXPEngine
{
	public class StaticCrystal : Box
	{
		//Private fields
		public int _reflectAngle { get; set; }
		public bool _activated { get; set; }

		//----------------------------------------------------\\
		//						Constructor					  \\
		//----------------------------------------------------\\
		public StaticCrystal(int newReflectAngle, int spriteSize, float newScale = 1) : base("square.png", 32f, 32f, spriteSize)
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
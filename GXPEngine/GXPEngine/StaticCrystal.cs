using GXPEngine;

namespace GXPEngine
{
	public class StaticCrystal : Box
	{
		//Private fields
		private int _reflectAngle;
		public bool activated { get; set; }

		//----------------------------------------------------\\
		//						Constructor					  \\
		//----------------------------------------------------\\
		public StaticCrystal(int newReflectAngle) : base("checkers.png", 32f, 32f)
		{
			SetOrigin(width / 2, height / 2);
			_reflectAngle = newReflectAngle;
		}

		//----------------------------------------------------\\
		//						collision					  \\
		//----------------------------------------------------\\
		public void OnLightBeam()
		{
			//insert collision stuff and destroy lightbeam
			LightBeam lightBeam = new LightBeam(x, y, _reflectAngle);
			world.AddBody(lightBeam);
		}
	}
}
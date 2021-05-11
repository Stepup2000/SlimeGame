using GXPEngine;
using System;

class RotatingCrystal : Box
{
	//Private fields
	private MyGame _myGame;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public RotatingCrystal(float newX, float newY) : base("Diamond.png", 32, 32, true)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(newX, newY);
		_myGame = (MyGame)game;
	}

	//----------------------------------------------------\\
	//						collision					  \\
	//----------------------------------------------------\\
	private void collision()
	{
		//insert collision stuff
		//Get ID of old lightBeam
		//LightBeam lightBeam = new LightBeam(x, y, oldLightBeamDirection + rotation);
		//game.AddChild(lightBeam);
		//Destroy old lightbeam
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		collision();
	}
}

using GXPEngine;
using System;

class StaticCrystal : AnimationSprite
{
	//Private fields
	int _reflectAngle;
	private MyGame _myGame;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public StaticCrystal(float newX, float newY, int newReflectAngle) : base("checkers.png", 1, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(newX, newY);
		_reflectAngle = newReflectAngle;
		_myGame = (MyGame)game;
	}

	//----------------------------------------------------\\
	//						collision					  \\
	//----------------------------------------------------\\
	private void collision()
	{
		//insert collision stuff and destroy lightbeam
		LightBeam lightBeam = new LightBeam(x, y, _reflectAngle);
		game.AddChild(lightBeam);
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		collision();
	}
}

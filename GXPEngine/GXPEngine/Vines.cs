using GXPEngine;
using System;

class Vines : AnimationSprite
{
	//Private fields
	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Vines(float newX, float newY) : base("checkers.png", 1, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(newX, newY);
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
	}
}

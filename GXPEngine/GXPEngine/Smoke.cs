using GXPEngine;
using System;

class Smoke : AnimationSprite
{
	//Private fields

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Smoke(float newX, float newY, float size) : base("checkers", 1, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(newX, newY);
		scaleX = size;
		scaleY = size;
	}

	//----------------------------------------------------\\
	//						animationEnd				  \\
	//----------------------------------------------------\\
	private void animationEnd()
    {
		if (currentFrame == 0)
        {
			LateDestroy();
        }
    }

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		animationEnd();
	}
}

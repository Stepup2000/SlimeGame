using GXPEngine;
using System;

class Smoke : AnimationSprite
{
	//Private fields

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Smoke(float newX, float newY, float size) : base("Smoke.png", 3, 3)
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
		if (currentFrame == 8)
        {
			LateDestroy();
        }
    }

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		Animate();
		animationEnd();
	}
}

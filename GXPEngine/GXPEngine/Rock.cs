using GXPEngine;
using System;

class Rock : Box
{
	//Private fields
	private MyGame _myGame;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Rock(int spriteSize) : base("colors.png", 32, 64, false, false)
	{
		SetOrigin(width/2, height/2);
		
		_myGame = (MyGame)game;
	}

	//----------------------------------------------------\\
	//						checkCollision				  \\
	//----------------------------------------------------\\
	private void checkCollision()
    {
    }

	//----------------------------------------------------\\
	//						delete						  \\
	//----------------------------------------------------\\
	public void Delete()
	{
		createSmoke();
		LateDestroy();
	}

	//----------------------------------------------------\\
	//						createSmoke					  \\
	//----------------------------------------------------\\
	private void createSmoke()
	{
		Smoke smoke = new Smoke(x, y, 1);
		AddChild(smoke);
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		checkCollision();
	}
}

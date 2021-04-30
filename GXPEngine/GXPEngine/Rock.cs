using GXPEngine;
using System;

class Rock : Sprite
{
	//Private fields
	private MyGame _myGame;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Rock(float newX, float newY) : base("checkers")
	{
		SetOrigin(width/2, height/2);
		SetXY(newX, newY);
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
	private void delete()
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
		AddChild(game);
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		checkCollision();
	}
}

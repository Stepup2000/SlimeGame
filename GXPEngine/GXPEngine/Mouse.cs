using GXPEngine;
using System;

class Mouse : Sprite
{
	//Private fields

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public Mouse() : base("Mouse.png")
	{
		SetOrigin(width / 2, height / 2);
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		SetXY(Input.mouseX,Input.mouseY);

		if(Input.GetMouseButtonUp(0) || Input.GetKey(Key.P))
        {
			Mouse _mouse = new Mouse();
			game.AddChild(_mouse);
			LateDestroy();
        }
	}
}

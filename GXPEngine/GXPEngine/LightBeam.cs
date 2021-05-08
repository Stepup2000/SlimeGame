using GXPEngine;

class LightBeam : Box
{
	public Box plOwner { get; set; }

	public bool hitSomething { get; set; }

	//Private fields
	private int _speed = 20;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public LightBeam(Box pOwner, int newDirection) : base("checkers.png", 1, 1)
	{
		plOwner = pOwner;
		SetOrigin(plOwner.x, plOwner.y);
		position.x = plOwner.x + ((newDirection - 90) / 90) * plOwner.halfWidth;
		position.y = plOwner.y;
		changeDirection(newDirection);
	}

	//----------------------------------------------------\\
	//						changeDirection()			  \\
	//----------------------------------------------------\\
	private void changeDirection(int direction)
    {
		//velocity = Vec2.GetUnitVectorDeg(direction);

		switch (direction)
        {
			case 0:
				velocity = new Vec2(1, 0);
				break;
			case 180:
				velocity = new Vec2(-1, 0);
				break;
        }
	}

    public override void Step()
    {
		rotation = velocity.GetAngleDegrees();

		if (hitSomething == false)
		{
			scaleX += Mathf.Sign(velocity.x) * 0.06f;
		}

		/*velocity += acceleration;
		position += velocity;

		x = position.x;
		y = position.y;*/
	}
}

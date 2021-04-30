using GXPEngine;
using System;

class LightBeam : AnimationSprite
{
	//Private fields
	private int _speed = 20;

	public Vec2 position
	{
		get
		{
			return _position;
		}
	}

	public Vec2 velocity;
	private Vec2 _position;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public LightBeam(float newX, float newY, int newDirection) : base("checkers", 1, 1)
	{
		SetOrigin(width / 2, height / 2);
		SetXY(newX, newY);
		changeDirection(newDirection);
	}

	//----------------------------------------------------\\
	//						changeDirection()			  \\
	//----------------------------------------------------\\
	private void changeDirection(int direction)
    {
		velocity = Vec2.GetUnitVectorDeg(direction);
	}

	//----------------------------------------------------\\
	//						applyVelocity				  \\
	//----------------------------------------------------\\
	private void applyVelocity()
	{
		velocity.NormalizeThis();
		_position += velocity * _speed;
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		applyVelocity();
	}
}

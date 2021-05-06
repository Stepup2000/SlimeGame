using GXPEngine;
using System;

class LightBeam : Box
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
	public LightBeam(float px, float py, int newDirection) : base("checkers.png", 1, 1)
	{
		SetOrigin(width / 2, height / 2);
		_position.x = px;
		_position.y = py;
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
		//velocity.NormalizeThis();
		_position += velocity * _speed;
	}

	//----------------------------------------------------\\
	//						updateScreenPosition		  \\
	//----------------------------------------------------\\
	private void updateScreenPosition()
	{
		x = _position.x;
		y = _position.y;
	}

	//----------------------------------------------------\\
	//						Update						  \\
	//----------------------------------------------------\\
	public void Update()
	{
		applyVelocity();
		updateScreenPosition();
	}
}

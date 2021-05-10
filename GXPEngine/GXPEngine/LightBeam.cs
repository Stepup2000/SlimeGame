using GXPEngine;

public class LightBeam : Box
{
	public Box plOwner { get; set; }
	public float travelDist { get; private set; }
	public int _speed { get; private set; }

	//Private fields
	private Vec2 _spawnPos;
	private const float _deviation = 0.001f;

	//----------------------------------------------------\\
	//						Constructor					  \\
	//----------------------------------------------------\\
	public LightBeam(Box pOwner, int newDirection, int pSpeed = 0) : base("circle.png", 8f, 8f)
	{
		_speed = pSpeed;
		plOwner = pOwner;
		SetOrigin(width / 2, height / 2);
		//position.x = plOwner.x + ((newDirection - 90) / 90) * plOwner.halfWidth;
		position.x = plOwner.x;
		position.y = plOwner.y;
		if (_speed != 0) _spawnPos = new Vec2(position.x, position.y);
		changeDirection(newDirection);

	}

	//----------------------------------------------------\\
	//						changeDirection()			  \\
	//----------------------------------------------------\\
	private void changeDirection(int direction)
    {
		velocity = Vec2.GetUnitVectorDeg(-direction) * _speed;
		if (Mathf.Abs(velocity.x) < _deviation) velocity.x = 0;
		if (Mathf.Abs(velocity.y) < _deviation) velocity.y = 0;
	}

    public override void Step()
    {
		if (_speed != 0)
        {
			position += velocity;

			x = position.x;
			y = position.y;

			travelDist = (position - _spawnPos).Length();
		}

	}
}

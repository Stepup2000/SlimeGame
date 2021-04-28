using GXPEngine;

public class Player : EasyDraw
{
    // public fields & properties:
    public Vec2 position
    {
        get
        {
            return _position;
        }
    }

    public Vec2 velocity;

    public int _radius;

    //private fields:
    private Vec2 _position;

    private float _speed;
    private float _maxSpeed = 3;
    private float _speedIncrease = 0.15f;

    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player(float px, float py, int radius) : base(radius * 2 + 1, radius * 2 + 1)
    {
        _radius = radius;
        SetOrigin(_radius, _radius);
        _position.x = px;
        _position.y = py;
    }

    //----------------------------------------------------\\
    //						controls					  \\
    //----------------------------------------------------\\
    private void controls()
    {
        WASDInput();
    }

    //----------------------------------------------------\\
    //						WSInput 					  \\
    //----------------------------------------------------\\
    private void WASDInput()
    {
        //Move to the right
        if (Input.GetKey(Key.D) && _speed < _maxSpeed)
        {
            velocity += new Vec2(0.1f, 0);
            _speed += _speedIncrease;
        }

        //Move to the left
        if (Input.GetKey(Key.A) && _speed > -_maxSpeed)
        {
            velocity += new Vec2(-0.1f, 0);
            _speed -= _speedIncrease;
        }
    }

    //----------------------------------------------------\\
    //						deceleration				  \\
    //----------------------------------------------------\\
    private void deceleration()
    {
        //Decelerate when no button is pressed
        if (!Input.GetKey(Key.LEFT) && !Input.GetKey(Key.RIGHT))
        {
            _speed *= 0.95f;
        }

        if (_speed > -0.05f && _speed < 0.05f)
        {
            _speed = 0;
        }
    }

    //----------------------------------------------------\\
    //						changeVelocity				  \\
    //----------------------------------------------------\\
    private void changeVelocity()
    {
        velocity = Vec2.GetUnitVectorDeg(rotation);
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
    //						updateScreenPosition		  \\
    //----------------------------------------------------\\
    private void updateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }

    //----------------------------------------------------\\
    //						draw    					  \\
    //----------------------------------------------------\\
    private void draw()
    {
        Fill(193, 80, 80);
        Stroke(193, 80, 80);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    //----------------------------------------------------\\
    //						Update  					  \\
    //----------------------------------------------------\\
    public void Update()
    {
        controls();
        deceleration();
        changeVelocity();
        applyVelocity();
        updateScreenPosition();
        draw();
    }
}

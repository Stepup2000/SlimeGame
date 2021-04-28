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
    private Vec2 _acceleration = new Vec2(0, 0.1f);

    private float _maxSpeed = 3;
    private float _speedIncrease = 0.05f;
    private float _jumpStrength = 10;
    private float _jumpTimer = -1;
    private float _jumpCooldown = 30;

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
        spaceInput();
    }

    //----------------------------------------------------\\
    //						WSInput 					  \\
    //----------------------------------------------------\\
    private void WASDInput()
    {
        //Move to the left
        if (Input.GetKey(Key.A) && velocity.x > -_maxSpeed)
        {
            velocity += new Vec2(-_speedIncrease, 0);
        }

        //Move to the right
        if (Input.GetKey(Key.D) && velocity.x < _maxSpeed)
        {
            velocity += new Vec2(_speedIncrease, 0);
        }
    }

    //----------------------------------------------------\\
    //						SpaceInput 					  \\
    //----------------------------------------------------\\
    private void spaceInput()
    {
        if (Input.GetKey(Key.SPACE) && canJump() == true)
        {
            velocity += new Vec2(0, -_jumpStrength);
            _jumpTimer = _jumpCooldown;
        }
    }

    //----------------------------------------------------\\
    //						CanJump 					  \\
    //----------------------------------------------------\\
    private bool canJump()
    {
        //Do boundary check stuff
        if (_jumpTimer == -1)
        {
            return true;
        }
        else return false;
    }

    //----------------------------------------------------\\
    //						deceleration				  \\
    //----------------------------------------------------\\
    private void deceleration()
    {
        //Decelerate when D and A are not pressed
        if (!Input.GetKey(Key.D) && !Input.GetKey(Key.A))
        {
            velocity.x *= 0.95f;
        }

        if (velocity.x > -0.05f && velocity.x < 0.05f)
        {
            velocity.x = 0;
        }
    }

    //----------------------------------------------------\\
    //						applyVelocity				  \\
    //----------------------------------------------------\\
    private void applyVelocity()
    {
        velocity += _acceleration;
        _position += velocity;
    }

    //----------------------------------------------------\\
    //						timers      				  \\
    //----------------------------------------------------\\
    private void timers()
    {
        if (_jumpTimer > -1)
        {
            _jumpTimer -= 1;
        }
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
        applyVelocity();
        timers();
        updateScreenPosition();
        draw();
    }
}

using GXPEngine;

public class Player1 : AnimationSprite
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
    private Vec2 _acceleration = new Vec2(0, 0f);

    
    private readonly float _maxSpeed = 3;
    private readonly float _speedIncrease = 0.05f;
    private readonly float _jumpStrength = 10;
    private readonly float _jumpCooldown = 30;
    private readonly float _abilityCooldown = 30;

    private float _scale = 1;
    private float _jumpTimer = -1;
    private float _abilityTimer = -1;
    

    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player1(float px, float py) : base("Barry.png", 7, 1)
    {
        SetOrigin(width/2, height/2);
        _position.x = px;
        _position.y = py;
    }

    //----------------------------------------------------\\
    //						controls					  \\
    //----------------------------------------------------\\
    private void controls()
    {
        WASDInput();
        QEInput();
    }

    //----------------------------------------------------\\
    //						WASDInput 					  \\
    //----------------------------------------------------\\
    private void WASDInput()
    {
        //Jump
        if (Input.GetKey(Key.W) && canJump() == true)
        {
            velocity += new Vec2(0, -_jumpStrength);
            _jumpTimer = _jumpCooldown;
        }

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
    //						QEInput 					  \\
    //----------------------------------------------------\\
    private void QEInput()
    {
        if (Input.GetKey(Key.Q) && _abilityTimer == -1)
        {
            shrink();
            _abilityTimer = _abilityCooldown;
        }

        if (Input.GetKey(Key.E) && _abilityTimer == -1)
        {
            grow();
            _abilityTimer = _abilityCooldown;
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
    //						grow        				  \\
    //----------------------------------------------------\\
    private void grow()
    {
        if (_scale < 1.5f)
        {
            _scale += 0.5f;
            changeAnimationCycle();
        }
    }

    //----------------------------------------------------\\
    //						shrink        				  \\
    //----------------------------------------------------\\
    private void shrink()
    {
        if (_scale > 0.5f)
        {
            _scale -= 0.5f;
            changeAnimationCycle();
        }
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

        if (_abilityTimer > -1)
        {
            _abilityTimer -= 1;
        }
    }

    //----------------------------------------------------\\
    //						changeAnimationCycle		  \\
    //----------------------------------------------------\\
    private void changeAnimationCycle()
    {
        switch(_scale)
        {
            //Small
            case 0.5f:
                SetCycle(1, 1, 0);
                SetFrame(1);
                break;

            //Medium
            case 1:
                SetCycle(2, 2, 0);
                SetFrame(2);
                break;

            //Big
            case 1.5f:
                SetCycle(3, 3, 0);
                SetFrame(3);
                break;
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
    //						Update  					  \\
    //----------------------------------------------------\\
    public void Update()
    {
        controls();
        deceleration();
        applyVelocity();
        timers();
        updateScreenPosition();
        System.Console.WriteLine(_scale);
    }
}

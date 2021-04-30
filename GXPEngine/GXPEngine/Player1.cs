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
    private Vec2 _acceleration = new Vec2(0, 0.1f);

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
    public Player1(float px, float py) : base("RockySlimeSpritesheet.png", 8, 3)
    {
        SetOrigin(width / 2, height);
        SetCycle(1, 7, 10);
        changeScale();
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
            velocity.y /= 2;
            velocity += new Vec2(0, -_jumpStrength);
            _jumpTimer = _jumpCooldown;
        }

        //Move to the left
        if (Input.GetKey(Key.A) && velocity.x > -_maxSpeed)
        {
            velocity += new Vec2(-_speedIncrease, 0);
            Mirror(true, false);
        }

        //Move to the right
        if (Input.GetKey(Key.D) && velocity.x < _maxSpeed)
        {
            velocity += new Vec2(_speedIncrease, 0);
            Mirror(false, false);
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
            changeScale();
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
            changeScale();
        }
    }

    //----------------------------------------------------\\
    //						shoot        				  \\
    //----------------------------------------------------\\
    private void shoot()
    {
        if (_abilityTimer == -1)
        {
            _abilityTimer = _abilityCooldown;
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

        if (velocity.x != 0 && velocity.y == 0)
        {
            SetCycle(1, 7, 10);
            if (velocity.x > 0)
            {
                Mirror(false, false);
            }

            if (velocity.x < 0)
            {
                Mirror(true, false);
            }
        }
        else
        {
            SetFrame(0);
        }
    }

    //----------------------------------------------------\\
    //						changeScale         		  \\
    //----------------------------------------------------\\
    private void changeScale()
    {
        scaleX = _scale / 2;
        scaleY = _scale / 2;
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
        changeAnimationCycle();
        timers();
        updateScreenPosition();
        Animate();
    }
}

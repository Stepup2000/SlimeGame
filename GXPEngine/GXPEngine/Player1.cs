using GXPEngine;

public class Player1 : Box
{
    // public fields & properties:
    /*public Vec2 position
    {
        get
        {
            return _position;
        }
    }

    public Vec2 velocity;*/

    public bool canJump { get; set; }

    //private fields:
    private readonly float _maxSpeed = 3;
    private readonly float _speedIncrease = 0.05f;
    private readonly float _jumpStrength = 4;
    private readonly float _abilityCooldown = 30;

    private float _scale = 1;
    private float _abilityTimer = -1;
    private string _orientation = "Right";


    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player1() : base("colors.png", 32f, 32f, true, false)
    {
        halfWidth = width / 2 * _scale;
        halfHeight = height / 2 * _scale;
        SetOrigin(width / 2, height);
        SetCycle(1, 7, 10);
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
        if (Input.GetKeyDown(Key.W) && canJump == true)
        {
            velocity.y /= 2;
            velocity += new Vec2(0, -_jumpStrength);
            canJump = false;
        }

        //Move to the left
        if (Input.GetKey(Key.A) && velocity.x > -_maxSpeed)
        {
            velocity += new Vec2(-_speedIncrease, 0);
            Mirror(true, false);
            _orientation = "Left";
        }

        //Move to the right
        if (Input.GetKey(Key.D) && velocity.x < _maxSpeed)
        {
            velocity += new Vec2(_speedIncrease, 0);
            Mirror(false, false);
            _orientation = "Right";
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
        if (Input.GetKey(Key.R) && _abilityTimer == -1)
        {
            shoot();
        }

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
            if (_orientation == "Right")
            {
                LightBeam lightBeam = new LightBeam(x, y, 0);
                game.AddChild(lightBeam);
            }

            if (_orientation == "Left")
            {
                LightBeam lightBeam = new LightBeam(x, y, 180);
                game.AddChild(lightBeam);
            }
            _abilityTimer = _abilityCooldown;
        }
    }

    //----------------------------------------------------\\
    //						timers      				  \\
    //----------------------------------------------------\\
    private void timers()
    {

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
        scaleX = _scale;
        scaleY = _scale;

        halfWidth = width / 2;
        halfHeight = height / 2;
    }

    //----------------------------------------------------\\
    //						Step                 		  \\
    //----------------------------------------------------\\
    public override void Step()
    {
        controls();
        deceleration();
        changeAnimationCycle();
        timers();
        Animate();

        velocity += acceleration;
        position += velocity * (1 / _scale);

        x = position.x;
        y = position.y + height / 2;
    }
}

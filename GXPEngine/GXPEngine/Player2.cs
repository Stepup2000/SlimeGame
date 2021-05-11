using GXPEngine;

public class Player2 : Box
{
    // public fields & properties:

    public bool canJump { get; set; }

    public bool isBeamActivated { get; set; }

    //private fields:
    private readonly float _maxSpeed = 3;
    private readonly float _speedIncrease = 0.05f;
    private readonly float _jumpStrength = 4;
    private readonly float _abilityCooldown = 30;

    private float _abilityTimer = -1;
    private int _lastDirection;

    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player2() : base("colors.png", 32f, 32f, true, false)
    {
        initializeAnimFrames(width / 64, height / 64);
        //initializeAnimFrames(width / spriteSize, height / spriteSize);
        halfWidth = width / 2;
        halfHeight = height / 2;
        SetOrigin(width / 2, height / 2);
        SetCycle(1, 7, 10);
    }

    //----------------------------------------------------\\
    //						controls					  \\
    //----------------------------------------------------\\
    private void controls()
    {
        arrowsInput();
        if (Input.GetKeyDown(Key.K) && _abilityTimer == -1)
        {
            shoot();
        }
        if (Input.GetKeyDown(Key.I) && _abilityTimer == -1)
        {
            acceleration.y = -acceleration.y;
            Mirror(false, true);
            canJump = false;
            _abilityTimer = _abilityCooldown;
        }
    }

    //----------------------------------------------------\\
    //						WASDInput 					  \\
    //----------------------------------------------------\\
    private void arrowsInput()
    {
        //Jump
        if (Input.GetKeyDown(Key.UP) /*&& canJump == true*/)
        {
            velocity.y /= 2;
            velocity += new Vec2(0, -_jumpStrength);
            canJump = false;
        }

        if (Input.GetKeyDown(Key.DOWN) && canJump == true)
        {
            velocity.y /= 2;
            velocity += new Vec2(0, _jumpStrength);
            canJump = false;
        }

        //Move to the left
        if (Input.GetKey(Key.LEFT) && velocity.x > -_maxSpeed)
        {
            velocity += new Vec2(-_speedIncrease, 0);
            Mirror(true, false);
            _lastDirection = Key.LEFT;
        }

        //Move to the right
        if (Input.GetKey(Key.RIGHT) && velocity.x < _maxSpeed)
        {
            velocity += new Vec2(_speedIncrease, 0);
            Mirror(false, false);
            _lastDirection = Key.RIGHT;
        }
    }

    //----------------------------------------------------\\
    //						deceleration				  \\
    //----------------------------------------------------\\
    private void deceleration()
    {
        //Decelerate when D and A are not pressed
        if (!Input.GetKey(Key.RIGHT) && !Input.GetKey(Key.LEFT))
        {
            velocity.x *= 0.95f;
        }

        if (velocity.x > -0.05f && velocity.x < 0.05f)
        {
            velocity.x = 0;
        }
    }

    //----------------------------------------------------\\
    //						shoot        				  \\
    //----------------------------------------------------\\
    private void shoot()
    {
        if (/*canJump &&*/ _abilityTimer == -1)
        {
            isBeamActivated = true;
            switch (_lastDirection)
            {
                case Key.RIGHT:
                default:
                    LightBeam rightBeam = new LightBeam(this, 0, 16);
                    world.AddBody(rightBeam);
                    break;
                case Key.LEFT:
                    LightBeam leftBeam = new LightBeam(this, 180, 16);
                    world.AddBody(leftBeam);
                    break;
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
        position += velocity;

        x = position.x;
        y = position.y;
    }
}

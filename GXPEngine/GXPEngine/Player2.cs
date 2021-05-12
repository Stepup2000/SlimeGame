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
    private readonly float _abilityCooldown = 90;

    private bool _invertGravity = false;
    private bool _invertSprite = false;
    public float _abilityTimer { get; private set; }
    private int _lastDirection;

    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player2() : base("LightSpriteSmall.png", 32f, 32f, true, false)
    {
        _abilityTimer = -1;
        initializeAnimFrames(width / 64, height / 128);
        //initializeAnimFrames(width / spriteSize, height / spriteSize);
        //halfWidth = width / 2;
        //halfHeight = height / 2;
        SetOrigin(width / 2, height / 2);
        SetCycle(1, 7, 10);
    }

    //----------------------------------------------------\\
    //						controls					  \\
    //----------------------------------------------------\\
    private void controls()
    {
        arrowsInput();
        if (Input.GetKeyDown(Key.J) && _abilityTimer == -1)
        {
            shoot();
        }
        if (Input.GetKeyDown(Key.K) && _abilityTimer == -1)
        {
            acceleration.y = -acceleration.y;
            _invertGravity = !_invertGravity;
            canJump = false;
            _abilityTimer = _abilityCooldown;
            changeAnimationCycle();
        }
    }

    //----------------------------------------------------\\
    //						WASDInput 					  \\
    //----------------------------------------------------\\
    private void arrowsInput()
    {
        //Jump
        if (Input.GetKeyDown(Key.UP) && canJump == true)
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
            _invertSprite = true;
            _lastDirection = Key.LEFT;
        }

        //Move to the right
        if (Input.GetKey(Key.RIGHT) && velocity.x < _maxSpeed)
        {
            velocity += new Vec2(_speedIncrease, 0);
            _invertSprite = false;
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
        if (canJump && _abilityTimer == -1)
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
            new Sound("LightBeam.wav", false).Play();
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
        }
        else
        {
            SetCycle(1, 7, 100);
            SetFrame(0);
        }
        Mirror(_invertSprite, _invertGravity);
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
        y = position.y - Mathf.Sign(acceleration.y) * height/4;
    }
}

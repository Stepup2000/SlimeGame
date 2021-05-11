using GXPEngine;

public class Player1 : Box
{
    // public fields & properties:

    public bool canJump { get; set; }

    //private fields:
    private readonly float _maxSpeed = 3;
    private readonly float _speedIncrease = 0.05f;
    private readonly float _jumpStrength = 5;
    private readonly float _abilityCooldown = 30;

    public float _scale { get; private set; }
    private float _abilityTimer = -1;

    //----------------------------------------------------\\
    //						Constructor					  \\
    //----------------------------------------------------\\
    public Player1() : base("RockySpriteSmall.png", 32f, 32f, true, false)
    {
        initializeAnimFrames(width / 64, height / 64);
        //initializeAnimFrames(width / spriteSize, height / spriteSize);
        _scale = 1;
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

        if (velocity.x != 0 && velocity.y <= 0.1f && velocity.y >= 0)
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
            SetCycle(1, 7, 100);
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
        //position += velocity * (1 / _scale);
        position.x += velocity.x * (1 / _scale);
        position.y += velocity.y;

        x = position.x;
        y = position.y + height / 2;
    }
}

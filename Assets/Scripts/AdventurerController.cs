using UnityEngine;
using System.Collections;

public class AdventurerController : MonoBehaviour
{
    public float jumpSpeed;

    public float fallMultiplier = 5.0f;

    public float lowJumpMultiplier = 3.0f;

    public float horizontalSpeed = 10;

    public LayerMask whatIsGround;

    public Transform groundcheck;

    public Transform headcheck;

    private float groundRadius = 0.5f;

    private float headRadius = 0.3f;

    private bool grounded;

    public bool platformOverHead;

    private bool jump;

    private bool duck;

    bool facingRight = true;

    private float hAxis;

    private Rigidbody2D theRigidBody;

    private Animator theAnimator;

    private bool attack;

    public KeyCode attackButton;


    void Start()
    {
        jump = false;
        grounded = false;
        duck = false;
        attack = false;

        theRigidBody = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        

        hAxis = Input.GetAxis("Horizontal");

        theAnimator.SetFloat("hspeed", Mathf.Abs(hAxis));

        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        grounded = (bool)colliderWeCollidedWith;

        theAnimator.SetBool("ground", grounded);

        float yVelocity = theRigidBody.velocity.y;

        theAnimator.SetFloat("vspeed", yVelocity);


        duck = Input.GetButton("Fire1");

        attack = Input.GetKey("l");

        if (attack)
        {
            theAnimator.SetBool("attacking", true);
            grounded = false;
            //grounded false here makes it so you can't jump or move when attacking
            theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);
        }
        else
        {
            theAnimator.SetBool("attacking", false);
            grounded = true;
        }

        if (duck)
        {
            theAnimator.SetBool("Duck", true);
        }
        else
        {

            platformOverHead = false;

            if (grounded)
            {
                platformOverHead = Physics2D.OverlapCircle(headcheck.position, headRadius, whatIsGround);
            }

            theAnimator.SetBool("Duck", platformOverHead);
        }



        if (grounded)
        {
            if ((hAxis > 0) && (facingRight == false))
            {
                Flip();
            }
            else if ((hAxis < 0) && (facingRight == true))
            {
                Flip();
            }
        }

    }

    void FixedUpdate()
    {
        jump = Input.GetKeyDown(KeyCode.Space);

        if (grounded && !jump)
        {
                theRigidBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigidBody.velocity.y);
        }
        else if (grounded && jump)
        {
            theRigidBody.velocity = new Vector2(theRigidBody.velocity.x, jumpSpeed);
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

}

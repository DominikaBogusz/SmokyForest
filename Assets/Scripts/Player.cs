using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 10f;

    private bool facingRight = true;

    private bool grounded = false;
    [SerializeField]
    private Transform groundCheck;
    private float groundRadius = 0.2f;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float jumpForce = 300;
    

    private bool doubleJump = false;

    private Animator animator;

    [SerializeField]
    private Button moveLeft;
    [SerializeField]
    private Button moveRight;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("grounded", grounded);

        if (grounded)
        {
            doubleJump = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        //float move = Input.GetAxis("Horizontal");
        float move;
        if (moveLeft.GetComponent<CanvasRenderer>().GetColor() == moveLeft.GetComponent<Button>().colors.pressedColor * moveLeft.GetComponent<Button>().colors.colorMultiplier)
        {
            move = -1;
        }
        else if(moveRight.GetComponent<CanvasRenderer>().GetColor() == moveRight.GetComponent<Button>().colors.pressedColor * moveRight.GetComponent<Button>().colors.colorMultiplier)
        {
            move = 1;
        }
        else
        {
            move = 0;
        }
        animator.SetFloat("speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    //void Update()
    //{
    //    if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        animator.SetBool("grounded", false);
    //        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    //        //GetComponent<AudioSource>().Play();

    //        if (!doubleJump && !grounded)
    //        {
    //            doubleJump = true;
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fire")
        {
            GameMaster.Instance.EndGame();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump()
    {
        if ((grounded || !doubleJump))
        {
            animator.SetBool("grounded", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            //GetComponent<AudioSource>().Play();

            if (!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
    }
}

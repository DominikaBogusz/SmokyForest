using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 10f;

    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 300;

    bool doubleJump = false;

    Animator animator;

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

        float move = Input.GetAxis("Horizontal");
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

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
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
}

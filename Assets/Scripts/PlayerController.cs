using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;

    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 300;
    //GameObject[] planks;

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
        }

        //animator.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

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

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            gameObject.layer = 13;
        }
        else
        {
            gameObject.layer = 9;
        }

        //planks = GameObject.FindGameObjectsWithTag("Wall") as GameObject[];
        //foreach (GameObject plank in planks)
        //{
        //    if (plank.transform.position.y <= gameObject.transform.position.y)
        //    {
        //        plank.GetComponent<Collider2D>().enabled = true;
        //        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //        Debug.Log("Bam");
        //    }
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Die();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Die()
    {
        //// Save the Highscore to PlayerPrefs if higher than existing.
        //if (PlayerPrefs.GetInt("highscore") < m_GameController.getScore())
        //{
        //    PlayerPrefs.SetInt("highscore", m_GameController.getScore());
        //}
        //PlayerPrefs.Save();
        //PlayerPrefs.SetInt("score", m_GameController.getScore());

        //Application.LoadLevel("Menu");
    }
}

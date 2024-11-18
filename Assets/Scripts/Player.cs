using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    public bool doubleJump;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)

        {
        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3 (0f,0f,0f);
        }

        
        if(Input.GetAxis("Horizontal") < 0f)
        
        {
        anim.SetBool("Walk", true);
        transform.eulerAngles = new Vector3 (0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        
        {
        anim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.layer == 6)
         {
            isJumping = true;
         }
    }
}





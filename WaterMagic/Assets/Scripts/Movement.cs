using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterControl controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    int jump=0;
    bool crouch;

    bool allow=true;
    public bool outwater=true,inwater;
    public bool moveallow = true;

    public Animator animator;

    public Rigidbody2D rid;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButton("Horizontal") && !Input.GetButtonDown("Fire1"))
            {
                if (horizontalMove > 0)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else if (horizontalMove < 0)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
            }
            verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (inwater == false)
            {
                if (allow == true)
                {
                    if (jump < 2)
                    {
                        if (Input.GetButtonDown("Jump"))
                        {
                            jump++;
                            Debug.Log(jump);
                        }
                    }
                }

                if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
                {
                    crouch = true;
                }
                else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
                {
                    crouch = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {
            inwater = true;
            animator.SetBool("IsJumping", false);
            outwater =false;
            rid.drag = 5f;
            rid.angularDrag = 5f;
            rid.mass = 0.00001f;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {
            outwater = true;
            rid.drag = 0f;
            rid.angularDrag = 0.5f;
            rid.mass = 0.6359639f;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if(((int)gameObject.transform.position.y - (int)col.transform.position.y)>=0.4999f)
            {
                animator.SetBool("IsJumping", false);
            } 
            else
            {
                animator.SetBool("IsJumping", false);
                if (Input.GetButtonDown("Jump"))
                {
                    animator.SetBool("IsJumping", true);
                    jump = 2;
                    allow = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
         if (col.gameObject.layer == 9)
        {
            gameObject.GetComponent<CharacterControl>().m_Grounded = true;
            gameObject.GetComponent<CharacterControl>().OnLandEvent.Invoke();
        }
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = 0;
        allow = true;
        crouch = false;
        if (outwater == true)
        {
            outwater = true;
            inwater = false;
        }
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
            
    }

    void FixedUpdate()
    {
        if (moveallow)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump, inwater, outwater);
        }
        if (jump == 2)
        {
            jump = 0;
            allow = false;
        }
    }
}
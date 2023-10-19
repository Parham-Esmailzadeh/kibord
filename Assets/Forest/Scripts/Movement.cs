using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public bool jump = false;

    public Animator animator;

    public bool disabledJump = false;

    //public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Log()
    {
        Debug.Log("Landed");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            if ( !disabledJump )
            {
                animator.SetBool("Jump", true);
                disabledJump = true;
                jump = true;
            }
        }
    }
    public void Landed()
    {
        disabledJump = false;
        jump = false;
    }
    public void Jump()
    {
        jump = true;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        // in balaye male paridane
        // jump = false;
        animator.SetBool("Jump", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 30f;
    bool jump = false;
    bool crouch = false;
    //public float crouchSpeed = 10f;

    public Animator animator;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Run", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("JumpTrigger", true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("CrouchTrigger", true);
        }

        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("CrouchTrigger", false);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("JumpTrigger", false);
    }

    public void OnCroughing(bool isCroughing)
    {
        animator.SetBool("CrouchTrigger", isCroughing);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float movementSpeed;
    public float turnSpeed;
    public float jumpSpeed;

    bool isGrounded = false;
    float jump = 0f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        animator.SetFloat("ForwardandBack", vertical);
        animator.SetFloat("LeftandRight", horizontal);
        animator.SetBool("Jumping", false);


        Vector3 direction = new Vector3(horizontal, 0f, vertical); ;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = jumpSpeed;
            animator.SetBool("Jumping", true);
        }


        if(!isGrounded)
        {
            jump += .5f * Physics.gravity.y * Time.deltaTime;
        }

        direction.y = jump;

        transform.Rotate(0f, mouseX, 0f);
        direction = transform.rotation * direction;
        controller.Move(direction * movementSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            isGrounded = true;
        }
        else
        {

            isGrounded = false;
        }
    }
}

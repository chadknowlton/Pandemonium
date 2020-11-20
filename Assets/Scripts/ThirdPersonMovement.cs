using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpSpeed;

    private float shiftSpeed;
    private float xInvert;

    public bool isGrounded = false;
    float jump = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        movementSpeed = PlayerData.GetMovementSpeed();
        jumpSpeed = PlayerData.GetJumpSpeed();

        shiftSpeed = GameSetting.XAXISSENTITITY;
        xInvert = GameSetting.IsXInsert_f();

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * shiftSpeed * xInvert;

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

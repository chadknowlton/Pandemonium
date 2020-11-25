using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{

    private float shiftSpeed;
    private float invert;

    private float yCameraLimit1 = 30;
    private float yCameraLimit2 = 80;

    private ThirdPersonMovement movement;
    private float yCameraLimit;

    void Start()
    {
        shiftSpeed = GameSetting.YAXISSENTITITY;
        invert = GameSetting.IsYInsert_f();

        movement = GetComponentInParent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!GameManager.isPaused && !PlayerStatus.isDead)
        {
            float mouseY = Input.GetAxis("Mouse Y") * shiftSpeed * invert;

            transform.Rotate(mouseY, 0f, 0f);
            Vector3 rotation = transform.localRotation.eulerAngles;

            if (rotation.x > 180)
            {
                rotation.x -= 360;
            }

            if (movement.isGrounded)
            {
                yCameraLimit = yCameraLimit1;
            }
            else
            {
                yCameraLimit = yCameraLimit2;
            }

            rotation.x = Mathf.Clamp(rotation.x, (-1 * yCameraLimit), yCameraLimit);
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}

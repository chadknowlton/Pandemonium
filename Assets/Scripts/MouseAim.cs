using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{

    public float turnSpeed;
    private float yCameraLimit = 30;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed * -1;

        transform.Rotate(mouseY, 0f, 0f);
        Vector3 rotation = transform.localRotation.eulerAngles;

        if(rotation.x > 180)
        {
            rotation.x -= 360;
        }

        rotation.x = Mathf.Clamp(rotation.x,(-1 * yCameraLimit), yCameraLimit);
        transform.localRotation = Quaternion.Euler(rotation);
    }
}

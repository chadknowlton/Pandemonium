using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class MouseAim : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject moveCamera;
    public GameObject aimCamera;
    public GameObject deathCamera;

    public GameObject reticle1;
    public GameObject reticle2;

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
        aimCamera.SetActive(false);
        deathCamera.SetActive(false);
        reticle2.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(PlayerStatus.isDead)
        {
            aimCamera.SetActive(false);
            moveCamera.SetActive(false);
            deathCamera.SetActive(true);
            reticle1.SetActive(false);
            reticle2.SetActive(false);

            mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 3f;
            Vector3 dcPos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            deathCamera.transform.position = dcPos;
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                aimCamera.SetActive(true);
                moveCamera.SetActive(false);
                reticle1.SetActive(false);
                reticle2.SetActive(true);
            }
            else
            {
                aimCamera.SetActive(false);
                moveCamera.SetActive(true);
                reticle1.SetActive(true);
                reticle2.SetActive(false);
            }


            if (!GameManager.isPaused)
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
}
